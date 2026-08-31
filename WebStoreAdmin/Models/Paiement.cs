namespace WebStoreAdmin.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public string Methode { get; set; }
        public DateTime DatePaiement { get; set; }
        public bool Statut { get; set; }

        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
    }
}
