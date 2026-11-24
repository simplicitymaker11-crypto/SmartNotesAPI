using SmartNotesAPI.Controllers;
using SmartNotesAPI.Models;

namespace SmartNotesAPI.Services
{
    public class NoteService : INoteService
    {
        public static List<Note> notes = new List<Note>
            {
                new Note { Id = 1, Title = "Task.WhenAll", Content = "await rethrows only the first exception", Date = DateTime.Now,CategoryId=1 },
                new Note { Id = 2, Title = "async void", Content = "no Task to hold the exception, so the process crashes", Date = DateTime.Now ,CategoryId=1},
                new Note { Id = 3, Title = "Shared HttpClient", Content = "one per app, to avoid socket exhaustion", Date = DateTime.Now,CategoryId=2}
            };

        public IEnumerable<Note> GetNotes()
        {
            return notes;
        }
        public bool DeleteNote(int id)
        {

            int noteId = id;
            foreach (var note in notes)
            {
                if (note.Id == noteId)
                {
                    notes.Remove(note);
                    return true;
                }

            }
            return false;
        }

        public bool UpdateNote(int id, requestNotes note)
        {
            bool category_exists = CategoryController.Categories.Any(c => c.Id == note.CategoryId) || NoteController.notes.Any(c => c.Id == id);

            if (!category_exists) return false;

            int updateNoteId = id;
            foreach (var n in notes)
            {
                if (n.Id == updateNoteId)
                {
                    n.Title = note.Title;
                    n.Content = note.Content;
                    return true;


                }


            }
            return false;

        }

        public bool AddNote(requestNotes note)
        {
            bool category_exists = CategoryController.Categories.Any(c => c.Id == note.CategoryId);

            if (!category_exists) return true;

            Note newnote = new Note();

            if (notes.Count == 0)
            {

                newnote.Id = 1;

            }

            else
            {

                newnote.Id = notes.Max(n => n.Id) + 1;

            }

            newnote.Title = note.Title;
            newnote.Content = note.Content;
            newnote.Date = DateTime.Now;

            notes.Add(newnote);
            return true;
        }
    }
}
