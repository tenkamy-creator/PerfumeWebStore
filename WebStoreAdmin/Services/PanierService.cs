using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class PanierService
    {
        private readonly ApplicationDbContext _context;

        public PanierService(ApplicationDbContext context)
        {
            _context = context;
        }

        //=========================================================
        // CLIENT CONNECTÉ
        //=========================================================
        public async Task<Client?> GetClientConnecteAsync(
            ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return null;

            return await _context.Clients
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        //=========================================================
        // PANIER COMPLET
        //=========================================================
        public async Task<Panier?> GetPanierAsync(
            ClaimsPrincipal user)
        {
            var client = await GetClientConnecteAsync(user);

            if (client == null)
                return null;

            var panier = await _context.Paniers
                .Include(p => p.Lignes)
                    .ThenInclude(l => l.Parfum)
                        .ThenInclude(p => p.Images)
                .FirstOrDefaultAsync(p => p.ClientId == client.Id);

            if (panier == null)
            {
                panier = new Panier
                {
                    ClientId = client.Id,
                    Lignes = new List<LignePanier>()
                };

                _context.Paniers.Add(panier);
                await _context.SaveChangesAsync();
            }

            return panier;
        }

        //=========================================================
        // AJOUTER AU PANIER
        //=========================================================
        public async Task<bool> AjouterProduitAsync(
            ClaimsPrincipal user,
            int parfumId)
        {
            var panier = await GetPanierAsync(user);

            if (panier == null)
                return false;

            var parfum = await _context.Parfums
                .FirstOrDefaultAsync(p => p.Id == parfumId);

            if (parfum == null)
                return false;

            if (parfum.Stock <= 0)
                return false;

            var ligne = panier.Lignes
                .FirstOrDefault(l => l.ParfumId == parfumId);

            if (ligne == null)
            {
                panier.Lignes.Add(new LignePanier
                {
                    ParfumId = parfum.Id,
                    PrixUnitaire = parfum.Prix,
                    Quantite = 1
                });
            }
            else
            {
                if (ligne.Quantite >= parfum.Stock)
                    return false;

                ligne.Quantite++;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        //=========================================================
        // MODIFIER QUANTITÉ
        //=========================================================
        public async Task<bool> ModifierQuantiteAsync(
            ClaimsPrincipal user,
            int lignePanierId,
            int quantite)
        {
            var client = await GetClientConnecteAsync(user);

            if (client == null)
                return false;

            var ligne = await _context.LignesPanier
                .Include(l => l.Panier)
                .Include(l => l.Parfum)
                .FirstOrDefaultAsync(l => l.Id == lignePanierId);

            if (ligne == null)
                return false;

            if (ligne.Panier.ClientId != client.Id)
                return false;

            if (quantite <= 0)
            {
                _context.LignesPanier.Remove(ligne);
            }
            else
            {
                if (quantite > ligne.Parfum.Stock)
                    return false;

                ligne.Quantite = quantite;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        //=========================================================
        // RETIRER UN ARTICLE
        //=========================================================
        public async Task<bool> RetirerProduitAsync(
            ClaimsPrincipal user,
            int lignePanierId)
        {
            var client = await GetClientConnecteAsync(user);

            if (client == null)
                return false;

            var ligne = await _context.LignesPanier
                .Include(l => l.Panier)
                .FirstOrDefaultAsync(l => l.Id == lignePanierId);

            if (ligne == null)
                return false;

            if (ligne.Panier.ClientId != client.Id)
                return false;

            _context.LignesPanier.Remove(ligne);

            await _context.SaveChangesAsync();

            return true;
        }

        //=========================================================
        // VIDER LE PANIER
        //=========================================================
        public async Task<bool> ViderPanierAsync(
            ClaimsPrincipal user)
        {
            var panier = await GetPanierAsync(user);

            if (panier == null)
                return false;

            if (panier.Lignes.Any())
            {
                _context.LignesPanier.RemoveRange(panier.Lignes);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        //=========================================================
        // NOMBRE D'ARTICLES
        //=========================================================
        public async Task<int> NombreArticlesAsync(
            ClaimsPrincipal user)
        {
            var panier = await GetPanierAsync(user);

            if (panier == null)
                return 0;

            return panier.Lignes.Sum(x => x.Quantite);
        }

        //=========================================================
        // TOTAL DU PANIER
        //=========================================================
        public async Task<double> TotalPanierAsync(
            ClaimsPrincipal user)
        {
            var panier = await GetPanierAsync(user);

            if (panier == null)
                return 0;

            return panier.Lignes.Sum(x => x.SousTotal);
        }
    }
}