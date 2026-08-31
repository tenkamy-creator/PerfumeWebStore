namespace WebStoreAdmin.Models
{
    public class Avis
    {
        public int Id { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }
        public int ClientId { get; set; }
        public int ParfumId { get; set; }
    }
}
