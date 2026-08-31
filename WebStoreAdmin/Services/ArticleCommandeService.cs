using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class ArticleCommandeService(Data.ApplicationDbContext context)
    {
        public async Task<List<ArticleCommande>> AfficherArticleCommandeAsync()
        {
            return await context.ArticlesCommande
                .Include(x => x.Parfum)
                .Include(x => x.Commande)
                .ToListAsync();
        }
        public async Task<int> AjoutArticlesCommande(Parfum parfum)
        {
            context.Parfums.Add(parfum);
            return await context.SaveChangesAsync();
        }
        public async Task<ArticleCommande?> ChecherArticleParfumAsync(int id)
        {
            return await context.ArticlesCommande.Include(c => c.Parfum).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<ArticleCommande?> ChercherArticleCommandeAsync(int id)
        {
            return await context.ArticlesCommande.Include(ac => ac.Commande)
                .FirstOrDefaultAsync(ac => ac.Id == id);

        }

        public async Task<IEnumerable<ArticleCommande>> GetArticlesCommandeByIdsAsync(IEnumerable<int> ids)
        {
            return await context.ArticlesCommande
                .Where(ac => ids.Contains(ac.Id))
                .ToListAsync();
        }

        public async Task<int> SupprimerArticleCommande(ArticleCommande articleCommande)
        {
            context.ArticlesCommande.Remove(articleCommande);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierArticleCommande(Parfum parfum)
        {
            context.Parfums.Update(parfum);
            return await context.SaveChangesAsync();
        }

        //public async Task<bool> ArticleCommandeExiste(string nom)
        //{
        //    return await context.ArticlesCommande.AnyAsync(c => c.Nom.ToLower() == nom.ToLower());
        //}
    }
}
