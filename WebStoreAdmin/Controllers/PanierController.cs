using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreAdmin.Extensions;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Panier;
using WebStoreAdmin.ViewModels.Parfums;

namespace WebStoreAdmin.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        private readonly PanierService _panierService;
        private readonly ParfumsService _parfumService;

        public PanierController(PanierService panierService, ParfumsService parfumService)
        {
            _panierService = panierService;
            _parfumService = parfumService;
        }

        //=========================================
        // AFFICHER LE PANIER
        //=========================================
        public async Task<IActionResult> Index()
        {
            var panier = await _panierService.GetPanierAsync(User);
            if (panier == null)
                return Challenge();

            var vm = new PanierVM
            {
                PanierId = panier.Id,
                Lignes = panier.Lignes.Select(l => new PanierLigneItemVM
                {
                    Id = l.Id,
                    ParfumId = l.ParfumId,
                    Nom = l.Parfum.Nom,
                    PrixUnitaire = l.PrixUnitaire,
                    Quantite = l.Quantite,
                    ImageUrl = l.Parfum.Images
                        .FirstOrDefault(i => i.ImagePrincipale)?.Url,
                    StockDisponible = l.Parfum.Stock
                }).ToList()
            };

            // Parfums récemment consultés
            var idsRecents = HttpContext.Session
                .GetObjectFromJson<List<int>>("PARFUMS_RECENTS")
                ?? new List<int>();

            var parfumsRecents = await _parfumService.GetParfumsRecentsAsync(idsRecents);

            vm.RecemmentConsultes = parfumsRecents
                .Where(p => !panier.Lignes.Any(l => l.ParfumId == p.Id)) // exclure ceux déjà dans le panier
                .Select(p => new ParfumIndexVM
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Marque = p.Marque,
                    Description = p.Description,
                    Prix = p.Prix,
                    Stock = p.Stock,
                    Volume = p.Volume,
                    Genre = p.Genre,
                    CategorieId = p.CategorieId,
                    Categorie = p.Categorie,
                    Images = p.Images,
                }).ToList();

            return View(vm);
        }

        //=========================================
        // AJOUTER UN PRODUIT
        //=========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ajouter(int parfumId)
        {
            var resultat = await _panierService
                .AjouterProduitAsync(User, parfumId);

            if (!resultat)
            {
                TempData["erreur"] =
                    "Impossible d'ajouter ce produit au panier.";
            }
            else
            {
                TempData["info"] =
                    "Produit ajouté au panier.";
            }

            return RedirectToAction(nameof(Index));
        }

        //=========================================
        // MODIFIER LA QUANTITÉ
        //=========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierQuantite(
            int lignePanierId,
            int quantite)
        {
            var resultat = await _panierService
                .ModifierQuantiteAsync(
                    User,
                    lignePanierId,
                    quantite);

            if (!resultat)
            {
                TempData["erreur"] =
                    "Impossible de modifier la quantité.";
            }
            else
            {
                TempData["info"] =
                    "Panier mis à jour avec succès.";
            }

            return RedirectToAction(nameof(Index));
        }

        //=========================================
        // RETIRER UN ARTICLE
        //=========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Retirer(
            int lignePanierId)
        {
            var resultat = await _panierService
                .RetirerProduitAsync(
                    User,
                    lignePanierId);

            if (!resultat)
            {
                TempData["erreur"] =
                    "Impossible de retirer cet article.";
            }
            else
            {
                TempData["info"] =
                    "Article retiré du panier.";
            }

            return RedirectToAction(nameof(Index));
        }

        //=========================================
        // VIDER LE PANIER
        //=========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vider()
        {
            var resultat = await _panierService
                .ViderPanierAsync(User);

            if (!resultat)
            {
                TempData["erreur"] =
                    "Impossible de vider le panier.";
            }
            else
            {
                TempData["info"] =
                    "Panier vidé avec succès.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}