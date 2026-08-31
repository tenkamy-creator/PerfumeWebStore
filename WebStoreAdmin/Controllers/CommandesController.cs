using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Commandes;

namespace WebStoreAdmin.Controllers
{
    [Authorize]
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CommandeService _commandeService;
        private readonly ClientsService _clientsService;

        public CommandesController(
            ApplicationDbContext context,
            CommandeService commandeService,
            ClientsService clientsService)
        {
            _context = context;
            _commandeService = commandeService;
            _clientsService = clientsService;
        }

        public async Task<IActionResult> Index()
        {
            var commandes = await _context.Commandes
                .Include(c => c.Client)
                .ThenInclude(c => c.ApplicationUser)
                .Include(c => c.Lignes)
                .ToListAsync();

            var vm = commandes.Select(c => new CommandesIndexVM
            {
                Id = c.Id,
                DateCommande = c.DateCommande,
                NomClient =
                    $"{c.Client.ApplicationUser.Prenom} {c.Client.ApplicationUser.Nom}",
                NombreArticles = c.Lignes.Sum(l => l.Quantite),
                Total = c.Total,
                Statut = c.Statut
            });

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var commande = await _commandeService.ChercherCommandeAsync(id);

            if (commande == null)
                return NotFound();

            var vm = new CommandesDetailsVM
            {
                Id = commande.Id,
                DateCommande = commande.DateCommande,
                Total = commande.Total,
                Statut = commande.Statut,
                NomClient =
        $"{commande.Client.ApplicationUser.Prenom} {commande.Client.ApplicationUser.Nom}",
                EmailClient = commande.Client.ApplicationUser.Email!,
                Lignes = commande.Lignes
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreerDepuisPanier()
        {
            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (client == null)
                return Unauthorized();

            var clientId = client.Id;
            var panier = await _context.Paniers
                .Include(p => p.Lignes)
                .ThenInclude(l => l.Parfum)
                .FirstOrDefaultAsync(p => p.ClientId == clientId);

            if (panier == null || !panier.Lignes.Any())
            {
                TempData["Erreur"] = "Le panier est vide.";
                return RedirectToAction("Index", "Panier");
            }

            var commande = new Commande
            {
                ClientId = clientId,
                DateCommande = DateTime.Now,
                Statut = StatutsCommande.Payee,
                Total = (decimal)panier.Lignes.Sum(x => x.SousTotal),

                Lignes = panier.Lignes.Select(x =>
                    new LigneCommande
                    {
                        ParfumId = x.ParfumId,
                        NomParfum = x.Parfum.Nom,
                        PrixUnitaire = x.PrixUnitaire,
                        Quantite = x.Quantite
                    }).ToList()
            };

            _context.Commandes.Add(commande);

            foreach (var ligne in panier.Lignes)
            {
                ligne.Parfum.Stock -= ligne.Quantite;
            }

            _context.LignesPanier.RemoveRange(panier.Lignes);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details),
                new { id = commande.Id });
        }

        [HttpGet]
        [Authorize(Roles = Roles.Administrateur + "," + Roles.Gestionnaire)]
        public async Task<IActionResult> Modifier(int id)
        {
            var commande = await _commandeService.ChercherCommandeAsync(id);

            if (commande == null)
                return NotFound();

            var clients = await _clientsService.AfficherClientAsync();

            var vm = new CommandesModifierVM
            {
                Id = commande.Id,
                DateCommande = commande.DateCommande,
                Total = commande.Total,
                ClientId = commande.ClientId,
                Statut = commande.Statut,

                Clients = clients.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.ApplicationUser.Prenom} {c.ApplicationUser.Nom}"
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur + "," + Roles.Gestionnaire)]
        public async Task<IActionResult> Modifier(CommandesModifierVM vm)
        {
            if (!ModelState.IsValid)
            {
                var clients = await _clientsService.AfficherClientAsync();

                vm.Clients = clients.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.ApplicationUser.Prenom} {c.ApplicationUser.Nom}"
                }).ToList();

                return View(vm);
            }

            var commande = await _commandeService.ChercherCommandeAsync(vm.Id);

            if (commande == null)
                return NotFound();

            commande.DateCommande = vm.DateCommande;
            commande.Total = vm.Total;
            commande.ClientId = vm.ClientId;
            commande.Statut = vm.Statut;

            await _commandeService.ModifierCommande(commande);

            TempData["info"] = "Commande modifiée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Roles.Administrateur + "," + Roles.Gestionnaire)]
        [HttpPost]
        public async Task<IActionResult> ChangerStatut(
            int id,
            string statut)
        {
            var commande = await _context.Commandes
                .FindAsync(id);

            if (commande == null)
                return NotFound();

            var statutsValides = new[]
                {
                    StatutsCommande.EnAttente,
                    StatutsCommande.Payee,
                    StatutsCommande.Preparation,
                    StatutsCommande.Expediee,
                    StatutsCommande.Livree,
                    StatutsCommande.Annulee
                };

            if (!statutsValides.Contains(statut))
            {
                TempData["erreur"] = "Statut invalide.";
                return RedirectToAction(nameof(Details), new { id });
            }

            commande.Statut = statut;

            await _context.SaveChangesAsync();

            TempData["info"] = "Statut mis à jour avec succès.";

            return RedirectToAction(nameof(Details), new
            {
                id
            });
        }

        [HttpGet]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(int id)
        {
            var commande = await _commandeService.ChercherCommandeAsync(id);

            if (commande == null)
                return NotFound();

            var vm = new CommandesSupprimerVM
            {
                Id = commande.Id,
                DateCommande = commande.DateCommande,
                Total = commande.Total,
                Statut = commande.Statut,
                NomClient =
                    $"{commande.Client.ApplicationUser.Prenom} {commande.Client.ApplicationUser.Nom}",
    //            ImageUrl = commande.Parfum.Images
    //.FirstOrDefault(i => i.ImagePrincipale)
    //?.Url
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(CommandesSupprimerVM vm)
        {
            var commande = await _commandeService.ChercherCommandeAsync(vm.Id);

            if (commande == null)
                return NotFound();

            await _commandeService.SupprimerCommande(commande);

            TempData["info"] = "Commande supprimée avec succès.";

            return RedirectToAction(nameof(Index));
        }
    }
}