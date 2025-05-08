namespace SimpleNotes.Api.Models
{
    public class Note
    {
        public int Id { get; set; }          // Unique identifier for the note
        public string Title { get; set; } = string.Empty;  // Title of the note
        public string Content { get; set; } = string.Empty; // Body/content of the note
    }
}