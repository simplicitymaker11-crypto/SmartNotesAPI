using Microsoft.AspNetCore.Mvc;
using System.Collections;
using SmartNotesAPI.Models;
namespace SmartNotesAPI.Services
{
    public interface ICategoryService
    {

        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        List<Note> GetNotesByCategoryId(int categoryId);
        bool DeleteCategory(int id);
        Category UpdateCategory(int id, Category category);
        Category AddCategory(Category category);
        string CountCategories();

    }
}
