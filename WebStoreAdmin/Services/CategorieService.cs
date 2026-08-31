using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class CategoriesService(Data.ApplicationDbContext context)
    {

        public async Task<List<Categorie>> AfficherCategoriesAsync()
        {
            return await context.Categories.Include(x => x.Parfums).ToListAsync();
        }
        public async Task<int> AjoutCategories(Categorie categorie)
        {
            context.Categories.Add(categorie);
            return await context.SaveChangesAsync();
        }
        public async Task<Categorie?> ChercherParfumsCategorieAsync(int id)
        {
            return await context.Categories.Include(c => c.Parfums).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Categorie?> ChercherCategorieAsync(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<int> SupprimerCategorie(Categorie categorie)
        {
            context.Categories.Remove(categorie);
            return await context.SaveChangesAsync();
        }
        public async Task<bool> CategorieExiste(string nom)
        {
            return await context.Categories.AnyAsync(c => c.Nom.ToLower() == nom.ToLower());
        }

        public async Task<int> ModifierCategorie(Categorie categorie)
        {
            context.Categories.Update(categorie);
            return await context.SaveChangesAsync();
        }
    }
}
