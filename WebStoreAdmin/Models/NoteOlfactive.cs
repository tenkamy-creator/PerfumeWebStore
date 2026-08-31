namespace WebStoreAdmin.Models
{
    public class NoteOlfactive
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public int? FamilleOlfactiveId { get; set; }
        public FamilleOlfactive? FamilleOlfactive { get; set; }

        public List<ParfumNote> ParfumNotes { get; set; } = new();
    }
}