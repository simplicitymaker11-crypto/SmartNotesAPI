using SmartNotesAPI.Models;

namespace SmartNotesAPI.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotes();
        bool DeleteNote(int id);
        bool UpdateNote(int id, requestNotes note);
        IEnumerable<Note> AddNote(Note note);
        string CountNotes();
    }
}
