using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class ClientsService(ApplicationDbContext context)
    {
        public async Task<List<Client>> AfficherClientAsync()
        {
            return await context.Clients
                .Include(x => x.Commandes)
                .Include(x => x.ApplicationUser)
                .ToListAsync();
        }
        public async Task<int> AjoutClient(Client client)
        {
            context.Clients.Add(client);
            return await context.SaveChangesAsync();
        }
        public async Task<Client?> ChecherCommandesClientAsync(int id)
        {
            return await context.Clients.Include(c => c.Commandes)
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Client?> ChercherClientAsync(int id)
        {
            return await context.Clients.Include(c => c.Commandes)
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        //public async Task<IEnumerable<Parfum>> GetParfumsByIdsAsync(IEnumerable<int> ids)
        //{
        //    return await context.Parfums
        //        .Where(p => ids.Contains(p.Id))
        //        .ToListAsync();
        //}

        public async Task<int> SupprimerClient(Client client)
        {
            context.Clients.Remove(client);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierClient(Client client)
        {
            context.Clients.Update(client);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> ClientExiste(string nom)
        {
            return await context.Clients.AnyAsync(c => c.ApplicationUser.Nom.ToLower() == nom.ToLower());
        }
    }
}
