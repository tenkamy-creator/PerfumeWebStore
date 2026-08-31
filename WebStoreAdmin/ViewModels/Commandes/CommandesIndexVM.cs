using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Commandes
{
    public class CommandesIndexVM
    {
        public int Id { get; set; }

        public DateTime DateCommande { get; set; }

        public decimal Total { get; set; }

        public string Statut { get; set; } = string.Empty;

        public string NomClient { get; set; } = string.Empty;

        public string EmailClient { get; set; } = string.Empty;

        public int NombreArticles { get; set; }

        public string? ImageUrl { get; set; }

        public List<LigneCommande> Lignes { get; set; }
            = new();
    }
}
