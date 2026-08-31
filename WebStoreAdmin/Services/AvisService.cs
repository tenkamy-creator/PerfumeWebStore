using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;
using System.Threading.Tasks;

namespace WebStoreAdmin.Services
{
    public class AvisService(Data.ApplicationDbContext context)
    {
        public async Task<List<Avis>> Index()
        {
            return await context.Avis.ToListAsync();
        }

        public async Task<int> AjoutAvis(Avis avis)
        {
            context.Avis.Add(avis);
            return await context.SaveChangesAsync();
        }

        public async Task<Avis?> Details(int id)
        {
            return await context.Avis
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Avis?> ChercherAvisAsync(int id)
        {
            return await context.Avis.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<int> SupprimerAvis(Avis avis)
        {
            context.Avis.Remove(avis);
            return await context.SaveChangesAsync();
        }

        //private async Task<bool> AvisExiste(string nom)
        //{
        //    return await context.Avis.AnyAsync(e => e.Id == id);
        //}

        public async Task<int> ModifierProduit(Avis avis)
        {
            context.Avis.Update(avis);
            return await context.SaveChangesAsync();
        }
    }
}
