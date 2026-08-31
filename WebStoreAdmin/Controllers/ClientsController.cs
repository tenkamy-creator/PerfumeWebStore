
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Clients;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Data;
 
namespace WebStoreAdmin.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsService _clientsService;
        private readonly CommandeService _commandesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientsController(
            ClientsService clientsService,
            CommandeService commandeService,
            UserManager<ApplicationUser> userManager)
        {
            _clientsService = clientsService;
            _commandesService = commandeService;
            _userManager = userManager;
        }

        [Authorize(Roles = Roles.Administrateur)]
        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _clientsService.AfficherClientAsync();

            var vm = clients.Select(c => new ClientsIndexVM
            {
                Id = c.Id,
                NomComplet = $"{c.ApplicationUser.Prenom} {c.ApplicationUser.Nom}",
                Email = c.ApplicationUser.Email!,
                NombreCommandes = c.Commandes.Count
            });

            return View(vm);
        }

        // GET: Clients/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientsService.ChercherClientAsync(id.Value);

            if (client == null)
            {
                return NotFound();
            }

            var vm = new ClientsDetailsVM
            {
                Id = client.Id,
                Nom = client.ApplicationUser.Nom,
                Prenom = client.ApplicationUser.Prenom,
                Email = client.ApplicationUser.Email,
                NombreCommandes = client.Commandes.Count,
                Commandes = client.Commandes.ToList()
            };


            return View(vm);
        }

        // GET: Clients/Create
        [HttpGet, ActionName("Create")]
        [Authorize(Roles = Roles.Administrateur)]
        public IActionResult Ajouter()
        {
            return View(new ClientsAjouterVM());
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Ajouter(ClientsAjouterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                Prenom = vm.Prenom,
                Nom = vm.Nom,
                // Le compte est créé directement par un admin (pas d'auto-inscription
                // ni de flux d'envoi d'e-mail de confirmation) : on le marque confirmé
                // pour ne pas bloquer le client à la connexion, comme le fait déjà le seeder.
                EmailConfirmed = true
            };

            var result =
                await _userManager.CreateAsync(user, vm.MotDePasse);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(vm);
            }

            var client = new Client
            {
                UserId = user.Id,
                Commandes = new List<Commande>()
            };

            await _clientsService.AjoutClient(client);

            TempData["info"] = "Client créé avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Clients/Edit/5
        [HttpGet, ActionName("Edit")]
        [Authorize]
        public async Task<IActionResult> Modifier(int id)
        {
            var client = await _clientsService.ChercherClientAsync(id);

            if (client == null)
                return NotFound();

            var vm = new ClientsModifierVM
            {
                Id = client.Id,
                Prenom = client.ApplicationUser.Prenom,
                Nom = client.ApplicationUser.Nom,
                Email = client.ApplicationUser.Email!
            };

            return View(vm);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Modifier(ClientsModifierVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var client = await _clientsService.ChercherClientAsync(vm.Id);

            if (client == null)
                return NotFound();

            client.ApplicationUser.Prenom = vm.Prenom;
            client.ApplicationUser.Nom = vm.Nom;
            client.ApplicationUser.Email = vm.Email;
            client.ApplicationUser.UserName = vm.Email;

            //await _clientsService.SaveChangesAsync();
            await _userManager.UpdateAsync(client.ApplicationUser);

            TempData["info"] = "Client modifié avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Clients/Delete/5
        [HttpGet]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(int id)
        {
            var client = await _clientsService.ChercherClientAsync(id);

            if (client == null)
                return NotFound();

            var vm = new ClientsSupprimerVM
            {
                Id = client.Id,
                NomComplet =
                    $"{client.ApplicationUser.Prenom} {client.ApplicationUser.Nom}",
                Email = client.ApplicationUser.Email!,
                NombreCommandes = client.Commandes.Count
            };

            return View(vm);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(ClientsSupprimerVM vm)
        {
            var client = await _clientsService.ChercherClientAsync(vm.Id);

            if (client == null)
                return NotFound();

            await _userManager.DeleteAsync(client.ApplicationUser);

            await _clientsService.SupprimerClient(client);

            //await _clientsService.SaveChangesAsync();

            TempData["info"] = "Client supprimé avec succès.";

            return RedirectToAction(nameof(Index));
        }
    }
}

