using WebStoreAdmin.Models;

namespace WebStoreAdmin.ViewModels.Clients
{
    public class ClientsDetailsVM
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Nom { get; set; } = string.Empty;

        public string Prenom { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int NombreCommandes { get; set; }

        public List<Commande> Commandes { get; set; } = new();
    }
}
