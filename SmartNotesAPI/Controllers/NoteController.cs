using Microsoft.AspNetCore.Mvc;
using SmartNotesAPI.Models;
using SmartNotesAPI.Services;



namespace SmartNotesAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class NoteController : ControllerBase
    {

        static NoteService service = new NoteService();

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
           
           var response_notes = service.GetNotes();//ogic to retrieve notes from the database or any data source
           
            return Ok(response_notes);
        }


        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {

            
            Note result_note = service.GetNotesById(id);
            if (result_note is null) return NotFound("Id not exist");
            return Ok(result_note);

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {

           
            bool response = service.DeleteNote(id);
            if (response) return NoContent();
            return NotFound();

        }

        

        [HttpPut("{id}")]

        public IActionResult UpdateNote(int id, requestNotes note)
        {
            bool category_exists = CategoryService.Categories.Any(c => c.Id == note.CategoryId) ;

            if (!category_exists) return BadRequest("Category id does not exist!");

            Note updated_note = service.UpdateNote(id, note);
            if (updated_note is null) return BadRequest("Note id does not exist!");
            return Ok(updated_note);

        }

        [HttpPost]
        public IActionResult AddNote(requestNotes note)
        {
            bool category_exists = CategoryService.Categories.Any(c => c.Id == note.CategoryId);

            if (!category_exists) return BadRequest();

          
            Note newnote = service.AddNote(note);
            
            return CreatedAtAction(nameof(GetNoteById), new { id = newnote.Id }, newnote);
        }

        [HttpGet("count")]
        public IActionResult CountNotes()
        {
          
            string total_notes = service.CountNotes();
            return Ok(total_notes);



        }
    }
}
