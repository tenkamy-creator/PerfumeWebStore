using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class FamilleOlfactiveService(ApplicationDbContext context)
    {
        public async Task<List<FamilleOlfactive>> AfficherFamillesAsync()
        {
            return await context.FamillesOlfactives
                .Include(f => f.Notes)
                .OrderBy(f => f.Nom)
                .ToListAsync();
        }

        public async Task<FamilleOlfactive?> ChercherFamilleAsync(int id)
        {
            return await context.FamillesOlfactives
                .Include(f => f.Notes)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        // excludeId permet d'exclure l'enregistrement courant lors d'une modification,
        // pour ne pas se déclarer soi-même en doublon.
        public async Task<bool> FamilleExiste(string nom, int? excludeId = null)
        {
            return await context.FamillesOlfactives
                .AnyAsync(f => f.Nom.ToLower() == nom.ToLower()
                             && (excludeId == null || f.Id != excludeId));
        }

        public async Task<int> AjoutFamille(FamilleOlfactive famille)
        {
            context.FamillesOlfactives.Add(famille);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierFamille(FamilleOlfactive famille)
        {
            context.FamillesOlfactives.Update(famille);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SupprimerFamille(FamilleOlfactive famille)
        {
            context.FamillesOlfactives.Remove(famille);
            return await context.SaveChangesAsync();
        }
    }
}