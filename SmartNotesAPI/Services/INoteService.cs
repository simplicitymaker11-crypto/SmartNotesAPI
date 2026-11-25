using SmartNotesAPI.Models;

namespace SmartNotesAPI.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotes();
        Note GetNotesById(int id);
        bool DeleteNote(int id);
        Note UpdateNote(int id, requestNotes note);
        Note AddNote(requestNotes note);
        string CountNotes();
    }
}
