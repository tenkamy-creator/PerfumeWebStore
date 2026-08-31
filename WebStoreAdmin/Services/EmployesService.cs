using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class EmployesService(ApplicationDbContext context)
    {
        public async Task<List<Employe>> AfficherEmployesAsync()
        {
            return await context.Employes
                .Include(x => x.ApplicationUser)
                .ToListAsync();
        }
        public async Task<int> AjoutEmploye(Employe employe)
        {
            context.Employes.Add(employe);
            return await context.SaveChangesAsync();
        }
       
        public async Task<Employe?> ChercherEmployeAsync(int id)
        {
            return await context.Employes
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        //public async Task<IEnumerable<Parfum>> GetParfumsByIdsAsync(IEnumerable<int> ids)
        //{
        //    return await context.Parfums
        //        .Where(p => ids.Contains(p.Id))
        //        .ToListAsync();
        //}

        public async Task<int> SupprimerEmploye(Employe employe)
        {
            context.Employes.Remove(employe);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierEmploye(Employe employe)
        {
            context.Employes.Update(employe);
            return await context.SaveChangesAsync();
        }

        //public async Task<bool> ClientExiste(string nom)
        //{
        //    return await context.Clients.AnyAsync(c => c.ApplicationUser.Nom.ToLower() == nom.ToLower());
        //}
    }
}
