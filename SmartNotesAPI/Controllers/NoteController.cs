using Microsoft.AspNetCore.Mvc;
using SmartNotesAPI.Models;
using SmartNotesAPI.Services;



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
            NoteService service = new NoteService();
           var response_notes = service.GetNotes();//ogic to retrieve notes from the database or any data source
           
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

            NoteService service = new NoteService();
            bool response = service.DeleteNote(id);
            if (response) return NoContent();
            return NotFound();

        }

        

        [HttpPut("{id}")]

        public IActionResult UpdateNote(int id, requestNotes note)
        {
            NoteService service = new NoteService();
            bool is_note_updated = service.UpdateNote(id, note);
            if (!is_note_updated) return BadRequest("Catrgory id or Note id nor exists!");
            return Ok();

        }

        [HttpPost]
        public IActionResult AddNote(requestNotes note)
        {
            
            NoteService service = new NoteService();
            bool is_note_added = service.AddNote(note);
            if (!is_note_added) return BadRequest("Catrgory id nor exists!");
            return CreatedAtAction(nameof(GetNoteById), new { id = newnote.Id }, newnote);
        }

        [HttpGet("count")]
        public IActionResult CountNotes()
        {
            string total_notes = notes.Count.ToString();
            return Ok(total_notes);



        }
    }
}
