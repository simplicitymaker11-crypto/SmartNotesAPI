using SmartNotesAPI.Models;

namespace SmartNotesAPI.Services
{
    public class CategoryService
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "C# learning" },
            new Category { Id = 2, Name = "C# learning" }
        };

        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        public Category GetCategoryById(int id)
        {
            foreach (var category in Categories)
            {
                if (category.Id == id)
                {
                    return category;
                }
            }
            return null;
        }

        public bool DeleteCategory(int id)
        {
            int categoryId = id;
            foreach (var category in Categories)
            {
                if (category.Id == categoryId)
                {
                    Categories.Remove(category);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateCategory(int id, Category category)
        {
            int updateCategoryId = id;
            foreach (var c in Categories)
            {
                if (c.Id == updateCategoryId)
                {
                    c.Name = category.Name;
                    return true;
                }
            }
            return false;
        }

        public Category AddCategory(Category category)
        {
            Category newCategory = new Category();

            if (Categories.Count == 0)
            {
                newCategory.Id = 1;
            }
            else
            {
                newCategory.Id = Categories.Max(c => c.Id) + 1;
            }

            newCategory.Name = category.Name;
            Categories.Add(newCategory);
            return newCategory;
        }

        public string CountCategories()
        {
            return Categories.Count.ToString();
        }
    }
}
