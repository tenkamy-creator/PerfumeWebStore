using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Data;
using WebStoreAdmin.Extensions;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Parfums;
using X.PagedList.Extensions;

namespace WebStoreAdmin.Controllers
{
    public class ParfumsController : Controller
    {
        private readonly ParfumsService _parfumService;
        private readonly CategoriesService _categoriesService;
        private readonly IWebHostEnvironment _environment;

        private const string CleSessionRecents = "PARFUMS_RECENTS";
        private const int NombreMaxRecents = 6;

        private void AjouterAuxRecemmentConsultes(int parfumId)
        {
            var recents = HttpContext.Session
                .GetObjectFromJson<List<int>>(CleSessionRecents)
                ?? new List<int>();

            recents.Remove(parfumId); // évite les doublons
            recents.Insert(0, parfumId); // le plus récent en premier

            if (recents.Count > NombreMaxRecents)
            {
                recents = recents.Take(NombreMaxRecents).ToList();
            }

            HttpContext.Session.SetObjectAsJson(CleSessionRecents, recents);
        }

        public ParfumsController(ParfumsService parfumService,
            CategoriesService categoriesService, IWebHostEnvironment environment)
        {
            _parfumService = parfumService;
            _categoriesService = categoriesService;
            _environment = environment;
        }

        // GET: Parfums
        public async Task<IActionResult> Index(string sortOrder,
            List<Genres> genre,
            List<int> categories,
            bool enStock = false,
            double? minPrix = null,
            double? maxPrix = null,
            int page = 1
            )
        {
            var parfumsList = await _parfumService.AfficherParfumAsync();

            var parfums = parfumsList.Select(p => new ParfumIndexVM
            {
                Id = p.Id,
                Nom = p.Nom,
                Description = p.Description,
                Prix = p.Prix,
                Stock = p.Stock,
                Volume = p.Volume,
                Marque = p.Marque,
                CategorieId = p.CategorieId,
                Categorie = p.Categorie,
                Genre = p.Genre,
                Images = p.Images,
            });

            if (minPrix > maxPrix)
            {
                var temp = minPrix;
                minPrix = maxPrix;
                maxPrix = temp;
            }

            if (genre != null && genre.Any())
            {
                parfums = parfums.Where(p => genre.Contains(p.Genre));
            }

            if (enStock)
            {
                parfums = parfums.Where(p => p.Stock > 0);
            }

            if (categories != null && categories.Any())
            {
                parfums = parfums.Where(p => categories.Contains(p.CategorieId));
            }

            if (minPrix.HasValue)
            {
                parfums = parfums.Where(p => p.Prix >= minPrix.Value);
            }

            // Prix maximum
            if (maxPrix.HasValue)
            {
                parfums = parfums.Where(p => p.Prix <= maxPrix.Value);
            }

            parfums = sortOrder switch
            {
                "price_asc" => parfums.OrderBy(p => p.Prix),
                "price_desc" => parfums.OrderByDescending(p => p.Prix),
                "name_asc" => parfums.OrderBy(p => p.Nom),
                "name_desc" => parfums.OrderByDescending(p => p.Nom),
                _ => parfums.OrderByDescending(p => p.Id)
            };

            var toutesCategories = await _categoriesService.AfficherCategoriesAsync();

            ViewBag.Categories = toutesCategories;
            ViewBag.SelectedCategories = categories;

            ViewBag.SortOrder = sortOrder;
            ViewBag.SelectedGender = genre;

            ViewBag.EnStock = enStock;

            ViewBag.MinPrix = minPrix ?? 0;
            ViewBag.MaxPrix = maxPrix ?? 500;

            return View(parfums.ToPagedList(page, 9));
        }

        // GET: Parfums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parfum = await _parfumService.ChercherParfumAsync(id.Value);
            if (parfum == null)
            {
                return NotFound();
            }

            AjouterAuxRecemmentConsultes(parfum.Id);

            var vm = new ParfumDetailsVM
            {
                Id = parfum.Id,
                Nom = parfum.Nom,
                Marque = parfum.Marque,
                Description = parfum.Description,
                Prix = parfum.Prix,
                Stock = parfum.Stock,
                Volume = parfum.Volume,
                Genre = parfum.Genre,
                Categorie = parfum.Categorie,
                Images = parfum.Images,
                Notes = parfum.Notes,
                ArticlesCommande = parfum.ArticlesCommande,
            };

            var recommandations = await _parfumService.GetRecommandationsAsync(
                parfum.CategorieId,
                parfum.Genre,
                parfum.Id,
                4);

            vm.Recommandations = recommandations.Select(p => new ParfumIndexVM
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

        // GET: Parfums/Create
        [HttpGet, ActionName("Create")]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Ajouter()
        {
            var categorie = await _categoriesService.AfficherCategoriesAsync();
            var notes = await _parfumService.AfficherNotesDisponiblesAsync();

            var vm = new ParfumAjouterVM
            {
                Categories = categorie.Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList(),

                Genres = Enum.GetValues(typeof(Genres))
                    .Cast<Genres>()
                    .Select(g => new SelectListItem { Text = g.ToString(), Value = g.ToString() }).ToList(),

                NotesDisponibles = ConstruireListeNotes(notes)
            };
            return View(vm);
        }

        // POST: Parfums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Ajouter(
    [Bind("Nom,Marque,Description,Prix,Stock,Genre,CategorieId,Volume,Images,ImagePrincipaleIndex,NotesTeteIds,NotesCoeurIds,NotesFondIds")]
    ParfumAjouterVM vm)
        {
            var categories = await _categoriesService.AfficherCategoriesAsync();

            // Vérification : au moins une image requise
            if (vm.Images == null || !vm.Images.Any())
            {
                ModelState.AddModelError("Images", "Vous devez ajouter au moins une image.");
            }
            else
            {
                // Validation des images (format, poids)
                var erreurs = _parfumService.ValiderImages(vm.Images);

                foreach (var erreur in erreurs)
                {
                    ModelState.AddModelError("Images", erreur);
                }
            }

            // Vérification du nom
            if (await _parfumService.ParfumExiste(vm.Nom))
            {
                ModelState.AddModelError("Nom",
                    "Ce parfum existe déjà.");
            }

            if (!ModelState.IsValid)
            {
                vm.Categories = categories.Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();
                vm.Genres = Enum.GetValues(typeof(Genres)).Cast<Genres>()
                    .Select(g => new SelectListItem { Text = g.ToString(), Value = g.ToString() }).ToList();

                var notes = await _parfumService.AfficherNotesDisponiblesAsync();
                vm.NotesDisponibles = ConstruireListeNotes(notes);

                return View(vm);
            }

            var parfum = new Parfum
            {
                Nom = vm.Nom,
                Marque = vm.Marque,
                Description = vm.Description,
                Prix = vm.Prix,
                Volume = vm.Volume,
                Stock = vm.Stock,
                Genre = vm.Genre,
                CategorieId = vm.CategorieId
            };

            for (int i = 0; i < vm.Images.Count; i++)
            {
                var fichier = vm.Images[i];

                var nom = Guid.NewGuid() +
                          Path.GetExtension(fichier.FileName);

                var dossierImages = Path.Combine(
    _environment.WebRootPath,
    "Images", "Parfums");

                Directory.CreateDirectory(dossierImages); // Ne fait rien si le dossier existe déjà

                var chemin = Path.Combine(dossierImages, nom);

                using var stream = new FileStream(
                    chemin,
                    FileMode.Create);

                await fichier.CopyToAsync(stream);

                parfum.Images.Add(new ImageParfum
                {
                    Url = "/Images/Parfums/" + nom,
                    ImagePrincipale = i == vm.ImagePrincipaleIndex
                });
            }

            AjouterNotes(parfum, vm.NotesTeteIds, TypeNote.Tete);
            AjouterNotes(parfum, vm.NotesCoeurIds, TypeNote.Coeur);
            AjouterNotes(parfum, vm.NotesFondIds, TypeNote.Fond);

            parfum.Categorie = categories.First(c => c.Id == vm.CategorieId);

            await _parfumService.AjoutParfums(parfum);

            TempData["info"] = "Création effectuée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // Méthode utilitaire privée, réutilisée par Ajouter et Modifier
        private static void AjouterNotes(Parfum parfum, List<int> noteIds, TypeNote type)
        {
            if (noteIds == null) return;

            foreach (var noteId in noteIds.Distinct())
            {
                parfum.Notes.Add(new ParfumNote
                {
                    NoteOlfactiveId = noteId,
                    Type = type
                });
            }
        }

        // GET: Parfums/Edit/5
        [HttpGet, ActionName("Edit")]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Modifier(int id)
        {
            var categorie = await _categoriesService.AfficherCategoriesAsync();
            var notes = await _parfumService.AfficherNotesDisponiblesAsync();

            var parfum = await _parfumService.ChercherParfumAsync(id);
            if (parfum == null)
            {
                return NotFound();
            }

            var vm = new ParfumModifierVM
            {
                Id = parfum.Id,
                Nom = parfum.Nom,
                Marque = parfum.Marque,
                Description = parfum.Description,
                Prix = parfum.Prix,
                Stock = parfum.Stock,
                Volume = parfum.Volume,
                Genre = parfum.Genre,
                CategorieId = parfum.CategorieId,

                Categories = categorie.Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList(),

                Genres = Enum.GetValues(typeof(Genres))
                    .Cast<Genres>()
                    .Select(g => new SelectListItem { Text = g.ToString(), Value = g.ToString() }).ToList(),

                ImagesExistantes = parfum.Images,
                ImagePrincipaleId = parfum.Images.FirstOrDefault(i => i.ImagePrincipale)?.Id,

                NotesDisponibles = ConstruireListeNotes(notes),
                NotesTeteIds = parfum.Notes.Where(n => n.Type == TypeNote.Tete).Select(n => n.NoteOlfactiveId).ToList(),
                NotesCoeurIds = parfum.Notes.Where(n => n.Type == TypeNote.Coeur).Select(n => n.NoteOlfactiveId).ToList(),
                NotesFondIds = parfum.Notes.Where(n => n.Type == TypeNote.Fond).Select(n => n.NoteOlfactiveId).ToList(),
            };
            return View(vm);
        }

        // POST: Parfums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Modifier(ParfumModifierVM vm)
        {
            var categories = await _categoriesService.AfficherCategoriesAsync();

            // Validation des images
            var erreurs = _parfumService.ValiderImages(vm.Images);

            foreach (var erreur in erreurs)
            {
                ModelState.AddModelError("Images", erreur);
            }

            if (!ModelState.IsValid)
            {
                vm.Categories = categories.Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();

                vm.Genres = Enum.GetValues(typeof(Genres))
                    .Cast<Genres>()
                    .Select(g => new SelectListItem { Text = g.ToString(), Value = g.ToString() }).ToList();

                var notes = await _parfumService.AfficherNotesDisponiblesAsync();
                vm.NotesDisponibles = ConstruireListeNotes(notes);

                var parfumErreur = await _parfumService.ChercherParfumAsync(vm.Id);
                if (parfumErreur != null)
                {
                    vm.ImagesExistantes = parfumErreur.Images;
                }

                return View(vm);
            }

            var parfum = await _parfumService.ChercherParfumAsync(vm.Id);
            if (parfum == null)
            {
                return NotFound();
            }

            parfum.Nom = vm.Nom;
            parfum.Marque = vm.Marque;
            parfum.Description = vm.Description;
            parfum.Prix = vm.Prix;
            parfum.Stock = vm.Stock;
            parfum.Volume = vm.Volume;
            parfum.Genre = vm.Genre;
            parfum.CategorieId = vm.CategorieId;

            // Si une nouvelle image téléversée a été désignée comme principale,
            // aucune image existante ne doit garder ce statut.
            bool nouvellePrincipaleChoisie = vm.NouvelleImagePrincipaleIndex.HasValue;

            foreach (var image in parfum.Images)
            {
                image.ImagePrincipale =
                    !nouvellePrincipaleChoisie && image.Id == vm.ImagePrincipaleId;
            }

            // Ajouter les nouvelles images
            var dossierImages = Path.Combine(
                _environment.WebRootPath,
                "Images", "Parfums");

            Directory.CreateDirectory(dossierImages);

            for (int i = 0; i < vm.Images.Count; i++)
            {
                var fichier = vm.Images[i];

                var nom = Guid.NewGuid() +
                          Path.GetExtension(fichier.FileName);

                var chemin = Path.Combine(dossierImages, nom);

                using var stream = new FileStream(
                    chemin,
                    FileMode.Create);

                await fichier.CopyToAsync(stream);

                parfum.Images.Add(new ImageParfum
                {
                    Url = "/Images/Parfums/" + nom,
                    ImagePrincipale = nouvellePrincipaleChoisie
                        && i == vm.NouvelleImagePrincipaleIndex.Value
                });
            }

            parfum.Notes.Clear();
            AjouterNotes(parfum, vm.NotesTeteIds, TypeNote.Tete);
            AjouterNotes(parfum, vm.NotesCoeurIds, TypeNote.Coeur);
            AjouterNotes(parfum, vm.NotesFondIds, TypeNote.Fond);

            await _parfumService.ModifierParfum(parfum);

            TempData["info"] = "Modification effectuée avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // POST: Parfums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(int id)
        {
            var parfum = await _parfumService.ChercherParfumAsync(id);
            if (parfum != null)
            {
                foreach (var image in parfum.Images)
                {
                    var chemin = Path.Combine(
                        _environment.WebRootPath,
                        image.Url.TrimStart('/'));

                    if (System.IO.File.Exists(chemin))
                    {
                        System.IO.File.Delete(chemin);
                    }
                }

                await _parfumService.SupprimerParfum(parfum);
                TempData["info"] = "Suppression effectuée avec succès.";
            }

            return RedirectToAction("Index", "Parfums");
        }

        // POST: Parfums/SupprimerImage
        // Bug corrigé : il manquait [Authorize] et [ValidateAntiForgeryToken],
        // ce qui permettait à n'importe qui de supprimer une image sans être admin.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> SupprimerImage(int imageId)
        {
            var image = await _parfumService.ChercherImageAsync(imageId);

            if (image == null)
                return NotFound();

            var chemin = Path.Combine(
                _environment.WebRootPath,
                image.Url.TrimStart('/'));

            if (System.IO.File.Exists(chemin))
                System.IO.File.Delete(chemin);

            await _parfumService.SupprimerImageAsync(image);

            return RedirectToAction(nameof(Modifier),
                new { id = image.ParfumId });
        }

        [HttpPost]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> DefinirImagePrincipale(
    int parfumId,
    int imageId)
        {
            await _parfumService.DefinirImagePrincipaleAsync(
                parfumId,
                imageId);

            TempData["info"] = "Image principale modifiée avec succès.";

            return RedirectToAction(nameof(Modifier), new
            {
                id = parfumId
            });
        }

        private static List<SelectListItem> ConstruireListeNotes(List<NoteOlfactive> notes)
        {
            var groupes = new Dictionary<string, SelectListGroup>();

            return notes.Select(n =>
            {
                var nomFamille = n.FamilleOlfactive?.Nom ?? "Autres";

                if (!groupes.TryGetValue(nomFamille, out var groupe))
                {
                    groupe = new SelectListGroup { Name = nomFamille };
                    groupes[nomFamille] = groupe;
                }

                return new SelectListItem
                {
                    Text = n.Nom,
                    Value = n.Id.ToString(),
                    Group = groupe
                };
            }).ToList();
        }
    }
}