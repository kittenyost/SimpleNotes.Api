using SimpleNotes.Api.Interfaces;
using SimpleNotes.Api.Models;

namespace SimpleNotes.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new();
        private int _nextId = 1;

        public IEnumerable<Note> GetAll() => _notes;

        public Note? GetById(int id) => _notes.FirstOrDefault(n => n.Id == id);

        public Note Add(Note note)
        {
            note.Id = _nextId++;
            _notes.Add(note);
            return note;
        }
        public Note? Update(Note note)
        {
            var existingNote = GetById(note.Id);
            if (existingNote != null)
            {
                existingNote.Content = note.Content;
                return existingNote;
            }

            return null; // Handle case when note was not found
        }

        public bool Delete(int id)
        {
            var note = GetById(id);
            if (note == null) return false;
            _notes.Remove(note);
            return true;
        }
    }
}