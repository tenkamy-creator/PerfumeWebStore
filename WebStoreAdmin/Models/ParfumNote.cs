namespace WebStoreAdmin.Models
{
    public class ParfumNote
    {
        public int Id { get; set; }

        public int ParfumId { get; set; }
        public Parfum Parfum { get; set; } = null!;

        public int NoteOlfactiveId { get; set; }
        public NoteOlfactive NoteOlfactive { get; set; } = null!;

        public TypeNote Type { get; set; }
    }
}
