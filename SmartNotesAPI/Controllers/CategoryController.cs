using Microsoft.AspNetCore.Mvc;
using SmartNotesAPI.Models; 

namespace SmartNotesAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        public static List<Category> Categories = new List<Category> {
            new Category { Id = 1, Name="C# learning" },
            new Category { Id =2,Name="C# learning" }


        };

   
    [HttpGet]
    public IActionResult GetCategories()
    {

        // Logic to retrieve notes from the database or any data source
        var response_categories = Categories; // Simulating async operation

        return Ok(response_categories);
    }

        [HttpGet("{categoryId}/notes")]
        public IActionResult GetNotesByCategoryId(int categoryId)
        {

            bool category_exists= Categories.Any(c => c.Id == categoryId);

            if (!category_exists) return NotFound();

            var matching_notes = NoteController.notes.Where(note => note.CategoryId == categoryId) .ToList();

            return Ok(matching_notes);
        }

        [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        int categoryId = id;
        foreach (var category in Categories)
        {
            if (category.Id == categoryId)
            {
                return Ok(category);
            }
        }

        return NotFound();
    }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            int categoryId = id;
            foreach (var category in Categories)
            {
                if (category.Id == categoryId)
                {
                    Categories.Remove(category);
                    NoteController.notes.RemoveAll(note => note.CategoryId == categoryId);

                    return NoContent();
                }

            }

            return NotFound();
        }


        [HttpPut("{id}")]

        public IActionResult UpdateCategory(int id, Category category)
        {
            int updateCategoryId = id;
            foreach (var c in Categories)
            {
                if (c.Id == updateCategoryId)
                {
                    c.Name = category.Name;


                    return Ok(c );


                }


            }
            return NotFound();

        }


        [HttpPost]
        public IActionResult AddCategory(Category category)
        {



            Category newcategory = new Category();

            if (Categories.Count == 0)
            {

                newcategory.Id = 1;

            }

            else
            {

                newcategory.Id = Categories.Max(c => c.Id) + 1;

            }

            newcategory.Name = category.Name;

            Categories.Add(newcategory);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newcategory.Id }, newcategory);
        }

        [HttpGet("count")]
        public IActionResult CountCategories()
        {
            string total_categories = Categories.Count.ToString();
            return Ok(total_categories);



        }
    }
}
