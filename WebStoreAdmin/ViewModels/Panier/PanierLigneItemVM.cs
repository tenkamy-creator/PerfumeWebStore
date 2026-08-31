namespace WebStoreAdmin.ViewModels.Panier
{
    public class PanierLigneItemVM
    {
        public int Id { get; set; }
        public int ParfumId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public double PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public string? ImageUrl { get; set; }
        public int StockDisponible { get; set; }

        public double SousTotal => PrixUnitaire * Quantite;
    }
}