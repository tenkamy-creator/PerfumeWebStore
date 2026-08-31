namespace WebStoreAdmin.Models
{
    public class Panier
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public List<LignePanier> Lignes { get; set; }
            = new List<LignePanier>();

        public double Total =>
            Lignes.Sum(x => x.SousTotal);
    }
}