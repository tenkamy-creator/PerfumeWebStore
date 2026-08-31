using System.ComponentModel.DataAnnotations;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Parfums
{
    public class ParfumDetailsVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int Stock { get; set; }
        public Genres Genre { get; set; }
        [Display(Name = "Volume")]
        public double Volume { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public ImageParfum? ImagePrincipale
        {
            get
            {
                return Images
                    .FirstOrDefault(i => i.ImagePrincipale);
            }
        }

        public List<ParfumNote> Notes { get; set; } = new();

        public IEnumerable<WebStoreAdmin.Models.NoteOlfactive> NotesTete =>
            Notes.Where(n => n.Type == TypeNote.Tete).Select(n => n.NoteOlfactive);

        public IEnumerable<WebStoreAdmin.Models.NoteOlfactive> NotesCoeur =>
            Notes.Where(n => n.Type == TypeNote.Coeur).Select(n => n.NoteOlfactive);

        public IEnumerable<WebStoreAdmin.Models.NoteOlfactive> NotesFond =>
            Notes.Where(n => n.Type == TypeNote.Fond).Select(n => n.NoteOlfactive);
        public List<ImageParfum> Images { get; set; }
            = new();
        public List<ArticleCommande> ArticlesCommande { get; set; }

        public List<ParfumIndexVM> Recommandations { get; set; } = new();
    }
}
