using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Employes;

namespace WebStoreAdmin.Controllers
{
    public class EmployesController : Controller
    {
        private readonly EmployesService _employesService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        private static readonly string[] ExtensionsPhotoAutorisees = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long TaillePhotoMaxOctets = 5 * 1024 * 1024; // 5 Mo

        public EmployesController(
            EmployesService employesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            _employesService = employesService;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Employes
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Index()
        {
            var employes = await _employesService.AfficherEmployesAsync();

            var vm = employes.Select(e => new EmployesIndexVM
            {
                Id = e.Id,
                NomComplet = $"{e.ApplicationUser.Prenom} {e.ApplicationUser.Nom}",
                Email = e.ApplicationUser.Email!,
                Poste = e.Poste,
                Departement = e.Departement,
                DateEmbauche = e.DateEmbauche,
                PhotoUrl = e.PhotoUrl
            });
            return View(vm);
        }

        // GET: Employes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var employe = await _employesService.ChercherEmployeAsync(id);

            if (employe == null)
                return NotFound();

            var vm = new EmployesDetailsVM
            {
                Id = employe.Id,
                Prenom = employe.ApplicationUser.Prenom,
                Nom = employe.ApplicationUser.Nom,
                Email = employe.ApplicationUser.Email!,
                Poste = employe.Poste,
                Departement = employe.Departement,
                DateEmbauche = employe.DateEmbauche,
                PhotoUrl = employe.PhotoUrl
            };

            return View(vm);
        }

        // GET: Employes/Create
        [HttpGet, ActionName("Create")]
        [Authorize(Roles = Roles.Administrateur)]
        public IActionResult Ajouter()
        {
            var vm = new EmployesAjouterVM
            {
                Roles = ObtenirRoles()
            };

            return View(vm);
        }

        // POST: Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Ajouter(EmployesAjouterVM vm)
        {
            if (vm.Photo != null && vm.Photo.Length > 0)
            {
                var erreurPhoto = ValiderPhoto(vm.Photo);
                if (erreurPhoto != null)
                    ModelState.AddModelError("Photo", erreurPhoto);
            }

            if (!ModelState.IsValid)
            {
                vm.Roles = ObtenirRoles();
                return View(vm);
            }

            var user = new ApplicationUser
            {
                Prenom = vm.Prenom,
                Nom = vm.Nom,
                Email = vm.Email,
                UserName = vm.Email
            };

            var result = await _userManager.CreateAsync(user, vm.MotDePasse);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                // Bug corrigé : la liste des rôles n'était pas repeuplée ici, ce qui
                // faisait apparaître le menu déroulant vide si la création du compte
                // Identity échouait (ex. e-mail déjà utilisé).
                vm.Roles = ObtenirRoles();
                return View(vm);
            }

            var employe = new Employe
            {
                UserId = user.Id,
                Poste = vm.Poste,
                Departement = vm.Departement,
                DateEmbauche = vm.DateEmbauche
            };

            if (vm.Photo != null && vm.Photo.Length > 0)
            {
                employe.PhotoUrl = await EnregistrerPhotoAsync(vm.Photo);
            }

            await _userManager.AddToRoleAsync(user, vm.Role);
            await _employesService.AjoutEmploye(employe);
            TempData["info"] = "Employé créé avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Employes/Edit/5
        [HttpGet, ActionName("Edit")]
        [Authorize]
        public async Task<IActionResult> Modifier(int id)
        {
            var employe = await _employesService.ChercherEmployeAsync(id);

            if (employe == null)
                return NotFound();

            var vm = new EmployesModifierVM
            {
                Id = employe.Id,
                Prenom = employe.ApplicationUser.Prenom,
                Nom = employe.ApplicationUser.Nom,
                Email = employe.ApplicationUser.Email!,
                Poste = employe.Poste,
                Departement = employe.Departement,
                DateEmbauche = employe.DateEmbauche,
                PhotoUrlActuelle = employe.PhotoUrl
            };

            return View(vm);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Modifier(EmployesModifierVM vm)
        {
            if (vm.Photo != null && vm.Photo.Length > 0)
            {
                var erreurPhoto = ValiderPhoto(vm.Photo);
                if (erreurPhoto != null)
                    ModelState.AddModelError("Photo", erreurPhoto);
            }

            if (!ModelState.IsValid)
            {
                var employeErreur = await _employesService.ChercherEmployeAsync(vm.Id);
                vm.PhotoUrlActuelle = employeErreur?.PhotoUrl;
                return View(vm);
            }

            var employe = await _employesService.ChercherEmployeAsync(vm.Id);

            if (employe == null)
                return NotFound();

            employe.ApplicationUser.Prenom = vm.Prenom;
            employe.ApplicationUser.Nom = vm.Nom;
            employe.ApplicationUser.Email = vm.Email;
            employe.ApplicationUser.UserName = vm.Email;
            employe.Poste = vm.Poste;
            employe.Departement = vm.Departement;
            employe.DateEmbauche = vm.DateEmbauche;

            if (vm.Photo != null && vm.Photo.Length > 0)
            {
                // Remplacement de la photo : l'ancien fichier N'EST PAS supprimé du disque.
                // Seule la suppression complète de l'employé (Supprimer, plus bas) supprime des fichiers.
                employe.PhotoUrl = await EnregistrerPhotoAsync(vm.Photo);
            }

            await _employesService.ModifierEmploye(employe);

            TempData["info"] = "Employé modifié avec succès.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Employes/Delete/5
        [HttpGet]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(int id)
        {

            var employe = await _employesService.ChercherEmployeAsync(id);

            if (employe == null)
                return NotFound();

            var vm = new EmployesSupprimerVM
            {
                Id = employe.Id,
                NomComplet = $"{employe.ApplicationUser.Prenom} {employe.ApplicationUser.Nom}",
                Email = employe.ApplicationUser.Email!,
                Poste = employe.Poste,
                Departement = employe.Departement
            };
            return View(vm);
        }

        // POST: Employes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrateur)]
        public async Task<IActionResult> Supprimer(EmployesSupprimerVM vm)
        {

            var employe = await _employesService.ChercherEmployeAsync(vm.Id);

            if (employe == null)
                return NotFound();

            if (!string.IsNullOrEmpty(employe.PhotoUrl))
            {
                var chemin = Path.Combine(
                    _environment.WebRootPath,
                    employe.PhotoUrl.TrimStart('/'));

                if (System.IO.File.Exists(chemin))
                    System.IO.File.Delete(chemin);
            }

            await _employesService.SupprimerEmploye(employe);

            TempData["info"] = "Employé supprimé avec succès.";

            return RedirectToAction(nameof(Index));
        }

        private static List<SelectListItem> ObtenirRoles() => new()
        {
            new() { Value = Roles.Administrateur, Text = "Administrateur" },
            new() { Value = Roles.Gestionnaire, Text = "Gestionnaire" },
            new() { Value = Roles.Vendeur, Text = "Vendeur" }
        };

        private static string? ValiderPhoto(IFormFile photo)
        {
            var extension = Path.GetExtension(photo.FileName).ToLowerInvariant();

            if (!ExtensionsPhotoAutorisees.Contains(extension))
                return "Formats acceptés pour la photo : JPG, PNG, WEBP.";

            if (photo.Length > TaillePhotoMaxOctets)
                return "La photo ne doit pas dépasser 5 Mo.";

            return null;
        }

        private async Task<string> EnregistrerPhotoAsync(IFormFile photo)
        {
            var nom = Guid.NewGuid() + Path.GetExtension(photo.FileName);

            var dossier = Path.Combine(_environment.WebRootPath, "images", "employes");
            Directory.CreateDirectory(dossier);

            var chemin = Path.Combine(dossier, nom);

            using var stream = new FileStream(chemin, FileMode.Create);
            await photo.CopyToAsync(stream);

            return "/images/employes/" + nom;
        }
    }
}