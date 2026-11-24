using Microsoft.AspNetCore.Mvc;
using System.Collections;
using SmartNotesAPI.Models;
namespace SmartNotesAPI.Services
{
    public interface ICategoryService
    {

        IEnumerable<Category> GetCategories();
        IEnumerable<Note> GetNotesByCategoryId(int categoryId);
        bool DeleteCategory(int id);
        IEnumerable<Category> UpdateCategory(int id, Category category);
        IEnumerable<Category> AddCategory(Category category);
        string CountCategories();

    }
}
