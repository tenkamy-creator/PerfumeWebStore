using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Categories
{
    public class CategorieIndexVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public string Description { get; set; } = default!;
        //public List<Parfum> Parfums { get; set; }
        public int NombreParfums { get; set; }
    }
}
