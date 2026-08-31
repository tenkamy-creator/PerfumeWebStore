using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WebStoreAdmin.Models;
using WebStoreAdmin.Services;
using WebStoreAdmin.ViewModels.Parfums;
namespace WebStoreAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ParfumsService _parfumService;
        public HomeController(ParfumsService parfumService)
        {
            _parfumService = parfumService;
        }
        public async Task<IActionResult> Index()
        {
            var parfums = await _parfumService.AfficherTopParfumAsync();
            var vm = parfums.Select(p => new ParfumIndexVM
            {
                Id = p.Id,
                Nom = p.Nom,
                Marque = p.Marque,
                Description = p.Description,
                Prix = p.Prix,
                Stock = p.Stock,
                Categorie = p.Categorie,
                Volume = p.Volume,
                Images = p.Images,
            });

            // Nouveautés : les 3 derniers parfums créés (Id le plus élevé = le plus récent)
            var tousLesParfums = await _parfumService.AfficherParfumAsync();
            var nouveautes = tousLesParfums
                .OrderByDescending(p => p.Id)
                .Take(3)
                .Select(p => new ParfumIndexVM
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Marque = p.Marque,
                    Description = p.Description,
                    Prix = p.Prix,
                    Stock = p.Stock,
                    Categorie = p.Categorie,
                    Volume = p.Volume,
                    Images = p.Images,
                })
                .ToList();

            ViewBag.NewArrivals = nouveautes;

            return View(vm);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}