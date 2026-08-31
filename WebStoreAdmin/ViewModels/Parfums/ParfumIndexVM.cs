using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Parfums
{
    public class ParfumIndexVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int Stock { get; set; }
        public Genres Genre { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public double Volume { get; set; }

        public ImageParfum? ImagePrincipale
        {
            get
            {
                return Images
                    .FirstOrDefault(i => i.ImagePrincipale);
            }
        }
        public List<ImageParfum> Images { get; set; }
            = new();
        //public List<ArticleCommande> ArticlesCommande { get; set; }
    }
}
