namespace WebStoreAdmin.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public List<Parfum> Parfums { get; set; }
    }
}
