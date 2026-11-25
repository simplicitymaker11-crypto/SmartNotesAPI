using Microsoft.AspNetCore.Mvc;
using SmartNotesAPI.Models;
using SmartNotesAPI.Services;
using System.Linq;

namespace SmartNotesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        static CategoryService service = new CategoryService();
        [HttpGet]
        public IActionResult GetCategories()
        {
            var response_categories = service.GetCategories();
            return Ok(response_categories);
        }

        [HttpGet("{categoryId}/notes")]
        public IActionResult GetNotesByCategoryId(int categoryId)
        {
            bool category_exists = CategoryService.Categories.Any(c => c.Id == categoryId);
            if (!category_exists) return NotFound();
            
           
            List<Note> matching_notes = service.GetNotesByCategoryId(categoryId); 


            return Ok(matching_notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
           
            Category category = service.GetCategoryById(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            
            bool response = service.DeleteCategory(id);
            if (response) return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            bool category_exists = CategoryService.Categories.Any(c => c.Id == id);
            if (!category_exists) return NotFound();

            Category updated_category = service.UpdateCategory(id, category);
            if (updated_category == null) return NotFound();

            return Ok(updated_category);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            
            Category newcategory = service.AddCategory(category);

            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = newcategory.Id },
                newcategory);
        }

        [HttpGet("count")]
        public IActionResult CountCategories()
        {
           
            string total_categories = service.CountCategories();
            return Ok(total_categories);
        }
    }
}
