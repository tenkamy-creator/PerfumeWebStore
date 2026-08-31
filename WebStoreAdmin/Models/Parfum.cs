using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreAdmin.Models
{
    public class Parfum
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Marque { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Prix { get; set; }
        [Display(Name = "Volume (ml)")]
        public double Volume { get; set; }
        public int Stock { get; set; }
        public Genres Genre { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = default!;
        public List<ParfumNote> Notes { get; set; } = new();
        public List<ImageParfum> Images { get; set; }
            = new();
        public ImageParfum? ImagePrincipale
        {
            get
            {
                return Images
                    .FirstOrDefault(i => i.ImagePrincipale);
            }
        }

        [NotMapped]
        public IEnumerable<NoteOlfactive> NotesTete =>
            Notes.Where(n => n.Type == TypeNote.Tete).Select(n => n.NoteOlfactive);

        [NotMapped]
        public IEnumerable<NoteOlfactive> NotesCoeur =>
            Notes.Where(n => n.Type == TypeNote.Coeur).Select(n => n.NoteOlfactive);

        [NotMapped]
        public IEnumerable<NoteOlfactive> NotesFond =>
            Notes.Where(n => n.Type == TypeNote.Fond).Select(n => n.NoteOlfactive);

        public List<ArticleCommande> ArticlesCommande { get; set; } = new List<ArticleCommande>();
    }
}