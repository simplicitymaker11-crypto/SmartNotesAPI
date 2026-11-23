using Microsoft.AspNetCore.Mvc;
using SmartNotesAPI.Models;



namespace SmartNotesAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class NoteController : ControllerBase
    {
        public static List<Note> notes = new List<Note>
            {
                new Note { Id = 1, Title = "Task.WhenAll", Content = "await rethrows only the first exception", Date = DateTime.Now,CategoryId=1 },
                new Note { Id = 2, Title = "async void", Content = "no Task to hold the exception, so the process crashes", Date = DateTime.Now ,CategoryId=1},
                new Note { Id = 3, Title = "Shared HttpClient", Content = "one per app, to avoid socket exhaustion", Date = DateTime.Now,CategoryId=2}
            };

       
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {

            // Logic to retrieve notes from the database or any data source
            var response_notes = await Task.FromResult(notes); // Simulating async operation

            return Ok(response_notes);
        }


        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            int noteId = id;
            foreach (var note in notes)
            {
                if (note.Id == noteId)
                {
                    return Ok(note);
                }
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            int noteId = id;
            foreach (var note in notes)
            {
                if (note.Id == noteId)
                {
                    notes.Remove(note);

                    return NoContent();
                }

            }

            return NotFound();
        }

        
        [HttpPut("{id}")]

        public IActionResult UpdateNote(int id, Note note)
        {
            int updateNoteId = id;
            foreach (var n in notes)
            {
                if (n.Id == updateNoteId)
                {
                    n.Title = note.Title;
                    n.Content = note.Content;
                    n.Date = DateTime.Now;

                    return Ok(n);


                }


            }
            return NotFound();

        }

        [HttpGet("count")]
        public IActionResult CountNotes()
        {
            string total_notes = notes.Count.ToString();
            return Ok(total_notes);



        }
    }
}
