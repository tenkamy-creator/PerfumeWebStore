namespace WebStoreAdmin.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<Parfum> Parfums { get; set; } = new List<Parfum>();
    }
}