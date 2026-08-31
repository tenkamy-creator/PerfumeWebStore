using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using WebStoreAdmin.Services;

namespace WebStoreAdmin.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly PanierService _panierService;

        public CheckoutController(PanierService panierService)
        {
            _panierService = panierService;
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            var panier = await _panierService.GetPanierAsync(User);

            if (panier == null || !panier.Lignes.Any())
            {
                TempData["erreur"] = "Votre panier est vide.";
                return RedirectToAction("Index", "Panier");
            }

            var domain = "https://localhost:7056";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "/Checkout/Success",
                CancelUrl = domain + "/Checkout/Cancel",
                Mode = "payment",

                LineItems = panier.Lignes.Select(ligne => new SessionLineItemOptions
                {
                    Quantity = ligne.Quantite,

                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "cad",

                        UnitAmount = (long)(ligne.PrixUnitaire * 100),

                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = ligne.Parfum.Nom
                        }
                    }
                }).ToList()
            };

            var service = new SessionService();

            Session session = service.Create(options);

            return Redirect(session.Url);
        }
    }
}