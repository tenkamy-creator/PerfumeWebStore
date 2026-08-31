namespace WebStoreAdmin.Models
{
    public class LignePanier
    {
        public int Id { get; set; }

        public int PanierId { get; set; }
        public Panier Panier { get; set; } = null!;

        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; } = null!;

        public int Quantite { get; set; }

        public double PrixUnitaire { get; set; }

        public double SousTotal => PrixUnitaire * Quantite;
    }
}