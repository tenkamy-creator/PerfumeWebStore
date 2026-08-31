using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class CommandeService(Data.ApplicationDbContext context)
    {
        public async Task<List<Commande>> AfficherCommandesAsync()
        {
            return await context.Commandes
                .Include(c => c.Client)
                .Include(c => c.Lignes)
                .ThenInclude(a => a.Parfum)
                .ToListAsync();
        }
        public async Task<int> AjoutCommandes(Commande commande)
        {
            context.Commandes.Add(commande);
            return await context.SaveChangesAsync();
        }
        public async Task<Commande?> ChecherArticlesCommandeAsync(int id)
        {
            return await context.Commandes
        .Include(c => c.Client)
            .ThenInclude(c => c.ApplicationUser)
        .Include(c => c.Lignes)
            .ThenInclude(l => l.Parfum)
        .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Commande?> ChercherCommandeAsync(int id)
        {
            return await context.Commandes
                .Include(c => c.Client)
                .Include(c => c.Lignes)
                .ThenInclude(a => a.Parfum)
                .FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<IEnumerable<ArticleCommande>> GetArticlesCommandeByIdsAsync(IEnumerable<int> ids)
        {
            return await context.ArticlesCommande
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }
        public async Task<int> SupprimerCommande(Commande commande)
        {
            context.Commandes.Remove(commande);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierCommande(Commande commande)
        {
            context.Commandes.Update(commande);
            return await context.SaveChangesAsync();
        }

        //public async Task<bool> CommandeExiste(string nom)
        //{
        //    return await context.Commandes.AnyAsync(c => c.Nom.ToLower() == nom.ToLower());
        //}
    }
}
