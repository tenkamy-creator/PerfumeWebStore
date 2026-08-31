using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class ParfumsService(Data.ApplicationDbContext context)
    {
        public async Task<List<Parfum>> AfficherParfumAsync()
        {
            return await context.Parfums
                .Include(p => p.Categorie)
                .Include(p => p.Images)
                .ToListAsync();
        }
        public async Task<List<Parfum>> AfficherTopParfumAsync()
        {
            return await context.Parfums
                .Include(p => p.Categorie)
                .Include(p => p.Images)
                .Take(4)
                .ToListAsync();
        }
        public async Task<int> AjoutParfums(Parfum parfum)
        {
            context.Parfums.Add(parfum);
            return await context.SaveChangesAsync();
        }
        public async Task<Parfum?> ChecherParfumArticleAsync(int id)
        {
            return await context.Parfums
                .Include(p => p.Images)
                .Include(p => p.ArticlesCommande)
                .Include(p => p.Notes)
                    .ThenInclude(n => n.NoteOlfactive)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Parfum?> ChercherParfumAsync(int id)
        {
            return await context.Parfums
                .Include(p => p.Categorie)
                .Include(p => p.Images)
                .Include(p => p.Notes)
                    .ThenInclude(n => n.NoteOlfactive)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Parfum>> GetParfumsByIdsAsync(IEnumerable<int> ids)
        {
            return await context.Parfums
                .Include(p => p.Images)
                .Include(p => p.Categorie)
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<int> SupprimerParfum(Parfum parfum)
        {
            context.Parfums.Remove(parfum);
            context.ImagesParfum.RemoveRange(parfum.Images);
            context.ParfumNotes.RemoveRange(parfum.Notes);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierParfum(Parfum parfum)
        {
            context.Parfums.Update(parfum);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> ParfumExiste(string nom)
        {
            return await context.Parfums.AnyAsync(c => c.Nom.ToLower() == nom.ToLower());
        }

        public async Task<int> DefinirImagePrincipaleAsync(
    int parfumId,
    int imageId)
        {
            var images = await context.ImagesParfum
                .Where(i => i.ParfumId == parfumId)
                .ToListAsync();

            foreach (var image in images)
            {
                image.ImagePrincipale = image.Id == imageId;
            }

            return await context.SaveChangesAsync();
        }

        public async Task<ImageParfum?> ChercherImageAsync(int imageId)
        {
            return await context.ImagesParfum
                .FirstOrDefaultAsync(i => i.Id == imageId);
        }

        public async Task<int> SupprimerImageAsync(ImageParfum image)
        {
            context.ImagesParfum.Remove(image);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Parfum>> GetRecommandationsAsync(
    int categorieId,
    Genres genre,
    int excludeId,
    int count = 4)
        {
            var recommandations = await context.Parfums
                .Include(p => p.Categorie)
                .Include(p => p.Images)
                .Where(p => p.Id != excludeId
                         && p.CategorieId == categorieId
                         && p.Genre == genre)
                .Take(count)
                .ToListAsync();

            if (recommandations.Count < count)
            {
                var idsExistants = recommandations.Select(p => p.Id).ToList();
                idsExistants.Add(excludeId);

                var complement = await context.Parfums
                    .Include(p => p.Categorie)
                    .Include(p => p.Images)
                    .Where(p => !idsExistants.Contains(p.Id)
                             && p.CategorieId == categorieId)
                    .Take(count - recommandations.Count)
                    .ToListAsync();

                recommandations.AddRange(complement);
            }

            return recommandations;
        }

        public async Task<List<NoteOlfactive>> AfficherNotesDisponiblesAsync()
        {
            return await context.NotesOlfactives
                .Include(n => n.FamilleOlfactive)
                .OrderBy(n => n.FamilleOlfactive!.Nom)
                .ThenBy(n => n.Nom)
                .ToListAsync();
        }

        public async Task<List<Parfum>> GetParfumsRecentsAsync(List<int> parfumIds)
        {
            if (parfumIds == null || !parfumIds.Any())
                return new List<Parfum>();

            var parfums = await context.Parfums
                .Include(p => p.Categorie)
                .Include(p => p.Images)
                .Where(p => parfumIds.Contains(p.Id))
                .ToListAsync();

            return parfumIds
                .Select(id => parfums.FirstOrDefault(p => p.Id == id))
                .Where(p => p != null)
                .Select(p => p!)
                .ToList();
        }

        private static readonly string[] ExtensionsAutorisees =
{
    ".jpg",
    ".jpeg",
    ".png",
    ".webp",
    ".gif"
};

        public List<string> ValiderImages(IEnumerable<IFormFile>? fichiers)
        {
            var erreurs = new List<string>();

            if (fichiers == null || !fichiers.Any())
                return erreurs;

            foreach (var fichier in fichiers.Where(f => f.Length > 0))
            {
                var extension = Path.GetExtension(fichier.FileName)
                    .ToLowerInvariant();

                if (!ExtensionsAutorisees.Contains(extension))
                    erreurs.Add($"{fichier.FileName} n'est pas une image valide.");

                if (!fichier.ContentType.StartsWith("image/"))
                    erreurs.Add($"{fichier.FileName} n'est pas une image.");

                if (fichier.Length > 5 * 1024 * 1024)
                    erreurs.Add($"{fichier.FileName} dépasse 5 Mo.");
            }

            return erreurs;
        }
    }
}