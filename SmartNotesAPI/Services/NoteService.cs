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
        public Note GetNotesById(int id)
        {
            foreach (var note in notes)
            {
                if (note.Id == id)
                {
                    return note;
                }
            }
            return null;
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

        public Note UpdateNote(int id, requestNotes note)
        {
            

            int updateNoteId = id;
            foreach (var n in notes)
            {
                if (n.Id == updateNoteId)
                {
                    n.Title = note.Title;
                    n.Content = note.Content;
                    return n;


                }


            }
            return null;

        }

        public Note AddNote(requestNotes note)
        {
            
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
            newnote.CategoryId = note.CategoryId;

            notes.Add(newnote);
            return newnote;
        }

        public string CountNotes()
        {
            return notes.Count.ToString();
        }
    }
}
