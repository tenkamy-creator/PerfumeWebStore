using Microsoft.AspNetCore.Mvc.Rendering;
using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Commandes
{
    public class CommandesSupprimerVM
    {
        public int Id { get; set; }

        public DateTime DateCommande { get; set; }

        public decimal Total { get; set; }

        public string Statut { get; set; } = "En attente";

        public int ClientId { get; set; }
        public string NomClient { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public List<LigneCommande> Lignes { get; set; }
            = new List<LigneCommande>();
    }
}
