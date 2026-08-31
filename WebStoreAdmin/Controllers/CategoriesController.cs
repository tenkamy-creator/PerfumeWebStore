using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels;
using WebStoreAdmin.ViewModels.Categories;

namespace WebStoreAdmin.Controllers
{
    [Authorize(Roles = Roles.Administrateur)]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;
        private readonly ParfumsService _parfumService;
        public CategoriesController(CategoriesService categoriesService, ParfumsService parfumsService)
        {
            _categoriesService = categoriesService;
            _parfumService = parfumsService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var toutesCategories = await _categoriesService.AfficherCategoriesAsync();

            var vm = toutesCategories.Select(x => new CategorieIndexVM
            {
                Id = x.Id,
                Nom = x.Nom,
                Description = x.Description,

                NombreParfums = x.Parfums.Count(),
            });
            return View(vm);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var categorieDetail = await _categoriesService.ChercherParfumsCategorieAsync(id.Value);
            if (categorieDetail == null)
            {
                return NotFound();
            }
            var vm = new CategoriesDetailsVM
            {
                Id = categorieDetail.Id,
                Nom = categorieDetail.Nom,
                Description = categorieDetail.Description,
                Parfums = categorieDetail.Parfums.ToList(),


            };

            return View(vm);
        }

        // GET: Categories/Create
        [HttpGet, ActionName("Create")]
        public async Task<IActionResult> Ajouter()
        {
            var parfum = await _parfumService.AfficherParfumAsync();
            var vm = new CategoriesAjouterVM
            {
                Parfums = parfum.Select(p => new SelectListItem
                {
                    Text = $"{p.Nom} — {p.Marque}",
                    Value = p.Id.ToString()
                }).ToList()
            };
            return View(vm);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ajouter(CategoriesAjouterVM ajouterVM)
        {
            var parfum = await _parfumService.AfficherParfumAsync();

            var categorie = new Categorie
            {
                Nom = ajouterVM.Nom,
                Description = ajouterVM.Description,
                Parfums = new List<Parfum>()
            };

            if (await _categoriesService.CategorieExiste(categorie.Nom))
            {
                ModelState.AddModelError("Nom", "Ce titre existe déjà.");
            }

            if (ModelState.IsValid)
            {
                // Bug corrigé : ParfumId (unique, potentiellement 0/null) est remplacé
                // par ParfumsIds (liste), pour permettre d'associer plusieurs parfums
                // à la création — sans planter si aucun n'est sélectionné.
                if (ajouterVM.ParfumsIds != null && ajouterVM.ParfumsIds.Any())
                {
                    var parfumsSelectionnes =
                        await _parfumService.GetParfumsByIdsAsync(ajouterVM.ParfumsIds);

                    categorie.Parfums = parfumsSelectionnes.ToList();
                }

                await _categoriesService.AjoutCategories(categorie);
                TempData["info"] = "Création effectuée avec succès.";

                return RedirectToAction("Index", "Categories");
            }

            ajouterVM.Parfums = parfum.Select(p => new SelectListItem
            {
                Text = $"{p.Nom} — {p.Marque}",
                Value = p.Id.ToString(),
                Selected = ajouterVM.ParfumsIds?.Contains(p.Id) ?? false
            }).ToList();

            return View(ajouterVM);
        }

        // GET: Categories/Edit/5
        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var parfum = await _parfumService.AfficherParfumAsync();

            var categorie = await _categoriesService.ChercherParfumsCategorieAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            var vm = new CategorieModifierVM
            {
                Id = categorie.Id,
                Nom = categorie.Nom,
                Description = categorie.Description,
                Parfums = parfum.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList(),
                ParfumsIds = categorie.Parfums.Select(p => p.Id).ToList()
            };

            return View(vm);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modifier(
    CategorieModifierVM categorieVM)
        {
            var parfum = await _parfumService.AfficherParfumAsync();

            if (ModelState.IsValid)
            {
                var categorieModifier =
                    await _categoriesService.ChercherCategorieAsync(
                        categorieVM.Id);

                if (categorieModifier == null)
                    return NotFound();

                categorieModifier.Nom = categorieVM.Nom;
                categorieModifier.Description =
                    categorieVM.Description;

                if (categorieVM.ParfumsIds != null)
                {
                    var parfumsSelectionnes =
                        await _parfumService.GetParfumsByIdsAsync(
                            categorieVM.ParfumsIds);

                    categorieModifier.Parfums =
                        parfumsSelectionnes.ToList();
                }
                else
                {
                    categorieModifier.Parfums =
                        new List<Parfum>();
                }

                await _categoriesService
                    .ModifierCategorie(categorieModifier);

                TempData["info"] =
                    "Modification effectuée avec succès.";

                return RedirectToAction(nameof(Index));
            }

            categorieVM.Parfums = parfum.Select(p =>
                new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nom,
                    Selected =
                        categorieVM.ParfumsIds?.Contains(p.Id)
                        ?? false
                }).ToList();

            return View(categorieVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var categorie = await _categoriesService.ChercherCategorieAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            var vm = new CategoriesSupprimerVM
            {
                Id = categorie.Id,
                Nom = categorie.Nom,
                Description = categorie.Description
            };

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Supprimer(int id)
        {
            var categorie = await _categoriesService.ChercherCategorieAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            await _categoriesService.SupprimerCategorie(categorie);

            TempData["info"] = "Catégorie supprimée avec succès.";

            return RedirectToAction(nameof(Index));
        }
    }
}