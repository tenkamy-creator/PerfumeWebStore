using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.FamilleOlfactive;

namespace WebStoreAdmin.Controllers
{
    [Authorize(Roles = Roles.Administrateur)]
    public class FamilleOlfactivesController : Controller
    {
        private readonly FamilleOlfactiveService _familleService;
        private readonly IWebHostEnvironment _environment;

        private static readonly string[] ExtensionsAutorisees = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long TailleMaxOctets = 5 * 1024 * 1024; // 5 Mo

        public FamilleOlfactivesController(
            FamilleOlfactiveService familleService,
            IWebHostEnvironment environment)
        {
            _familleService = familleService;
            _environment = environment;
        }

        // GET: FamilleOlfactives
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var familles = await _familleService.AfficherFamillesAsync();

            var vm = familles.Select(f => new FamilleOlfactiveIndexVM
            {
                Id = f.Id,
                Nom = f.Nom,
                ImageUrl = f.ImageUrl,
                NombreNotes = f.Notes.Count
            });

            return View(vm);
        }

        // GET: FamilleOlfactives/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new FamilleOlfactiveAjouterVM());
        }

        // POST: FamilleOlfactives/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FamilleOlfactiveAjouterVM vm)
        {
            if (vm.Image != null && vm.Image.Length > 0)
            {
                var erreur = ValiderImage(vm.Image);
                if (erreur != null)
                    ModelState.AddModelError("Image", erreur);
            }

            if (await _familleService.FamilleExiste(vm.Nom))
            {
                ModelState.AddModelError("Nom", "Cette famille olfactive existe déjà.");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var famille = new FamilleOlfactive
            {
                Nom = vm.Nom
            };

            if (vm.Image != null && vm.Image.Length > 0)
            {
                famille.ImageUrl = await EnregistrerImageAsync(vm.Image);
            }

            await _familleService.AjoutFamille(famille);
            TempData["info"] = "Famille olfactive créée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: FamilleOlfactives/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var famille = await _familleService.ChercherFamilleAsync(id);

            if (famille == null)
                return NotFound();

            var vm = new FamilleOlfactiveModifierVM
            {
                Id = famille.Id,
                Nom = famille.Nom,
                ImageUrlActuelle = famille.ImageUrl
            };

            return View(vm);
        }

        // POST: FamilleOlfactives/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FamilleOlfactiveModifierVM vm)
        {
            if (vm.Image != null && vm.Image.Length > 0)
            {
                var erreur = ValiderImage(vm.Image);
                if (erreur != null)
                    ModelState.AddModelError("Image", erreur);
            }

            if (await _familleService.FamilleExiste(vm.Nom, excludeId: vm.Id))
            {
                ModelState.AddModelError("Nom", "Une autre famille olfactive porte déjà ce nom.");
            }

            if (!ModelState.IsValid)
            {
                var familleErreur = await _familleService.ChercherFamilleAsync(vm.Id);
                vm.ImageUrlActuelle = familleErreur?.ImageUrl;
                return View(vm);
            }

            var famille = await _familleService.ChercherFamilleAsync(vm.Id);

            if (famille == null)
                return NotFound();

            famille.Nom = vm.Nom;

            if (vm.Image != null && vm.Image.Length > 0)
            {
                // Remplacement de l'image : l'ancien fichier N'EST PAS supprimé du disque.
                // Seule la suppression complète de la famille (Delete, plus bas) supprime des fichiers.
                famille.ImageUrl = await EnregistrerImageAsync(vm.Image);
            }

            await _familleService.ModifierFamille(famille);
            TempData["info"] = "Famille olfactive modifiée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: FamilleOlfactives/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var famille = await _familleService.ChercherFamilleAsync(id);

            if (famille == null)
                return NotFound();

            var vm = new FamilleOlfactiveSupprimerVM
            {
                Id = famille.Id,
                Nom = famille.Nom,
                ImageUrl = famille.ImageUrl,
                NombreNotes = famille.Notes.Count
            };

            return View(vm);
        }

        // POST: FamilleOlfactives/Delete/5
        // Seule action qui supprime physiquement le fichier : suppression complète de la famille.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var famille = await _familleService.ChercherFamilleAsync(id);

            if (famille == null)
                return NotFound();

            SupprimerFichierSiExiste(famille.ImageUrl);

            await _familleService.SupprimerFamille(famille);
            TempData["info"] = "Famille olfactive supprimée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        private static string? ValiderImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();

            if (!ExtensionsAutorisees.Contains(extension))
                return "Formats acceptés : JPG, PNG, WEBP.";

            if (image.Length > TailleMaxOctets)
                return "L'image ne doit pas dépasser 5 Mo.";

            return null;
        }

        private async Task<string> EnregistrerImageAsync(IFormFile image)
        {
            var nom = Guid.NewGuid() + Path.GetExtension(image.FileName);

            var dossier = Path.Combine(_environment.WebRootPath, "images", "familles-olfactives");
            Directory.CreateDirectory(dossier);

            var chemin = Path.Combine(dossier, nom);

            using var stream = new FileStream(chemin, FileMode.Create);
            await image.CopyToAsync(stream);

            return "/images/familles-olfactives/" + nom;
        }

        private void SupprimerFichierSiExiste(string? url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            var chemin = Path.Combine(_environment.WebRootPath, url.TrimStart('/'));

            if (System.IO.File.Exists(chemin))
                System.IO.File.Delete(chemin);
        }
    }
}