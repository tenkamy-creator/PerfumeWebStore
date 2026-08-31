namespace WebStoreAdmin.Models
{
    public class ImageParfum
    {
        public int Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public bool ImagePrincipale { get; set; }

        public int OrdreAffichage { get; set; }

        public int ParfumId { get; set; }

        public Parfum Parfum { get; set; } = null!;
    }
}
