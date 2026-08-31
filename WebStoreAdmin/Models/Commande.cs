namespace WebStoreAdmin.Models
{
    public class Commande
    {
        public int Id { get; set; }

        public DateTime DateCommande { get; set; }

        public decimal Total { get; set; }

        public string Statut { get; set; } = StatutsCommande.EnAttente;

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public List<LigneCommande> Lignes { get; set; }
            = new List<LigneCommande>();
    }
}