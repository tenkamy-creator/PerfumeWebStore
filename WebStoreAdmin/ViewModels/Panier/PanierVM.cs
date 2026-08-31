using WebStoreAdmin.ViewModels.Parfums;

namespace WebStoreAdmin.ViewModels.Panier
{
    public class PanierVM
    {
        public int PanierId { get; set; }
        public List<PanierLigneItemVM> Lignes { get; set; } = new();

        public double TauxTaxe { get; set; } = 0.15;

        public double Subtotal => Lignes.Sum(l => l.SousTotal);
        public double Taxes => Subtotal * TauxTaxe;
        public double Total => Subtotal + Taxes;
        public int QuantiteArticles => Lignes.Sum(l => l.Quantite);
        public bool EstVide => !Lignes.Any();
        public List<ParfumIndexVM> RecemmentConsultes { get; set; } = new();
    }
}