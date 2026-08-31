using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAdmin.ViewModels.Commandes
{
    public class CommandesModifierVM
    {
        public int Id { get; set; }

        [Display(Name = "Date de commande")]
        public DateTime DateCommande { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public List<SelectListItem> Clients { get; set; }
            = new();

        [Display(Name = "Statut")]
        public string Statut { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }
    }
}