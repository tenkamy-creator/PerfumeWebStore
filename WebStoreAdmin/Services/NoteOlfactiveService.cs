using Microsoft.EntityFrameworkCore;
using WebStoreAdmin.Data;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.Services
{
    public class NoteOlfactiveService(ApplicationDbContext context)
    {
        public async Task<List<NoteOlfactive>> AfficherNotesAsync()
        {
            return await context.NotesOlfactives
                .Include(n => n.FamilleOlfactive)
                .Include(n => n.ParfumNotes)
                .OrderBy(n => n.Nom)
                .ToListAsync();
        }

        public async Task<NoteOlfactive?> ChercherNoteAsync(int id)
        {
            return await context.NotesOlfactives
                .Include(n => n.FamilleOlfactive)
                .Include(n => n.ParfumNotes)
                .Include(n => n.ImageUrl)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<bool> NoteExiste(string nom)
        {
            return await context.NotesOlfactives
                .AnyAsync(n => n.Nom.ToLower() == nom.ToLower());
        }

        public async Task<int> AjoutNote(NoteOlfactive note)
        {
            context.NotesOlfactives.Add(note);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModifierNote(NoteOlfactive note)
        {
            context.NotesOlfactives.Update(note);
            return await context.SaveChangesAsync();
        }

        public async Task<int> SupprimerNote(NoteOlfactive note)
        {
            context.NotesOlfactives.Remove(note);
            return await context.SaveChangesAsync();
        }

        public async Task<int> EnregistrerModificationsAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}