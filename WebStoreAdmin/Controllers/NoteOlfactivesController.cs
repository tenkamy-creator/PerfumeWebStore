using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.NoteOlfactive;

namespace WebStoreAdmin.Controllers
{
    [Authorize(Roles = Roles.Administrateur)]
    public class NoteOlfactivesController : Controller
    {
        private readonly NoteOlfactiveService _noteService;
        private readonly FamilleOlfactiveService _familleService;
        private readonly IWebHostEnvironment _environment;

        private static readonly string[] ExtensionsAutorisees = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long TailleMaxOctets = 5 * 1024 * 1024; // 5 Mo

        public NoteOlfactivesController(
            NoteOlfactiveService noteService,
            FamilleOlfactiveService familleService,
            IWebHostEnvironment environment)
        {
            _noteService = noteService;
            _familleService = familleService;
            _environment = environment;
        }

        // GET: NoteOlfactives
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var notes = await _noteService.AfficherNotesAsync();

            var vm = notes.Select(n => new NoteOlfactiveIndexVM
            {
                Id = n.Id,
                Nom = n.Nom,
                ImageUrl = n.ImageUrl,
                FamilleOlfactiveNom = n.FamilleOlfactive?.Nom,
                NombreParfums = n.ParfumNotes.Count
            });

            return View(vm);
        }

        // GET: NoteOlfactives/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new NoteOlfactiveAjouterVM
            {
                Familles = await ObtenirFamillesAsync()
            };

            return View(vm);
        }

        // POST: NoteOlfactives/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoteOlfactiveAjouterVM vm)
        {
            if (vm.Image != null && vm.Image.Length > 0)
            {
                var erreur = ValiderImage(vm.Image);
                if (erreur != null)
                    ModelState.AddModelError("Image", erreur);
            }

            if (await _noteService.NoteExiste(vm.Nom))
            {
                ModelState.AddModelError("Nom", "Cette note olfactive existe déjà.");
            }

            if (!ModelState.IsValid)
            {
                vm.Familles = await ObtenirFamillesAsync();
                return View(vm);
            }

            var note = new NoteOlfactive
            {
                Nom = vm.Nom,
                FamilleOlfactiveId = vm.FamilleOlfactiveId
            };

            if (vm.Image != null && vm.Image.Length > 0)
            {
                note.ImageUrl = await EnregistrerImageAsync(vm.Image);
            }

            await _noteService.AjoutNote(note);
            TempData["info"] = "Note olfactive créée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: NoteOlfactives/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var note = await _noteService.ChercherNoteAsync(id);

            if (note == null)
                return NotFound();

            var vm = new NoteOlfactiveModifierVM
            {
                Id = note.Id,
                Nom = note.Nom,
                FamilleOlfactiveId = note.FamilleOlfactiveId,
                Familles = await ObtenirFamillesAsync(),
                ImageUrlActuelle = note.ImageUrl
            };

            return View(vm);
        }

        // POST: NoteOlfactives/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NoteOlfactiveModifierVM vm)
        {
            if (vm.Image != null && vm.Image.Length > 0)
            {
                var erreur = ValiderImage(vm.Image);
                if (erreur != null)
                    ModelState.AddModelError("Image", erreur);
            }

            if (!ModelState.IsValid)
            {
                vm.Familles = await ObtenirFamillesAsync();
                var noteErreur = await _noteService.ChercherNoteAsync(vm.Id);
                vm.ImageUrlActuelle = noteErreur?.ImageUrl;
                return View(vm);
            }

            var note = await _noteService.ChercherNoteAsync(vm.Id);

            if (note == null)
                return NotFound();

            note.Nom = vm.Nom;
            note.FamilleOlfactiveId = vm.FamilleOlfactiveId;

            if (vm.Image != null && vm.Image.Length > 0)
            {
                // Remplacement de l'image : l'ancien fichier N'EST PAS supprimé du disque.
                // Seule la suppression complète de la note (Delete, plus bas) supprime des fichiers.
                note.ImageUrl = await EnregistrerImageAsync(vm.Image);
            }

            await _noteService.ModifierNote(note);
            TempData["info"] = "Note olfactive modifiée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: NoteOlfactives/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _noteService.ChercherNoteAsync(id);

            if (note == null)
                return NotFound();

            var vm = new NoteOlfactiveSupprimerVM
            {
                Id = note.Id,
                Nom = note.Nom,
                ImageUrl = note.ImageUrl,
                FamilleOlfactiveNom = note.FamilleOlfactive?.Nom,
                NombreParfums = note.ParfumNotes.Count
            };

            return View(vm);
        }

        // POST: NoteOlfactives/Delete/5
        // Seule action qui supprime physiquement le fichier : suppression complète de la note.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _noteService.ChercherNoteAsync(id);

            if (note == null)
                return NotFound();

            SupprimerFichierSiExiste(note.ImageUrl);

            await _noteService.SupprimerNote(note);
            TempData["info"] = "Note olfactive supprimée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> ObtenirFamillesAsync()
        {
            var familles = await _familleService.AfficherFamillesAsync();

            return familles.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Nom
            }).ToList();
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

            var dossier = Path.Combine(_environment.WebRootPath, "images", "notes-olfactives");
            Directory.CreateDirectory(dossier);

            var chemin = Path.Combine(dossier, nom);

            using var stream = new FileStream(chemin, FileMode.Create);
            await image.CopyToAsync(stream);

            return "/images/notes-olfactives/" + nom;
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