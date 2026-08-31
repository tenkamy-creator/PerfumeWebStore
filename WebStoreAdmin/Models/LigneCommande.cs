namespace WebStoreAdmin.Models
{
    public class LigneCommande
    {
        public int Id { get; set; }

        public int CommandeId { get; set; }
        public Commande Commande { get; set; } = null!;

        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; } = null!;

        public string NomParfum { get; set; } = string.Empty;

        public double PrixUnitaire { get; set; }

        public int Quantite { get; set; }

        public double SousTotal => PrixUnitaire * Quantite;
    }
}