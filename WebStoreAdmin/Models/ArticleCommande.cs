namespace WebStoreAdmin.Models
{
    public class ArticleCommande
    {
        public int Id { get; set; }

        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; }

        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
    }
}
