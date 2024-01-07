/*using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repositories
{
    public class CategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public Category CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public void UpdateCategoryWithMenuItems(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var existingCategory = _context.Categories.Include(c => c.MenuItems).FirstOrDefault(c => c.CategoryId == category.CategoryId);

            if (existingCategory == null)
                throw new InvalidOperationException("Category not found");

            // Update properties of the existingCategory
            existingCategory.Name = category.Name;

            // Update or add MenuItems as needed
            existingCategory.MenuItems = category.MenuItems;

            _context.SaveChanges();
        }

        public void DeleteCategoryWithMenuItems(int categoryId)
        {
            var categoryToDelete = _context.Categories.Include(c => c.MenuItems).FirstOrDefault(c => c.CategoryId == categoryId);

            if (categoryToDelete == null)
                throw new InvalidOperationException("Category not found");

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
        }
    }
}

*/