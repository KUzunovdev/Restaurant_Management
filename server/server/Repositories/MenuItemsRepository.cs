using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repositories
{
    public class MenuItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem));

            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();

            return menuItem;
        }

        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.Include(mi=>mi.Category).ToList();

        }

        public MenuItem GetMenuItemById(int menuItemId)
        {
            return _context.MenuItems.Include(mi => mi.Category).FirstOrDefault(mi => mi.MenuItemId == menuItemId);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
                throw new ArgumentNullException(nameof(menuItem));

            var existingMenuItem = _context.MenuItems
                .FirstOrDefault(mi => mi.MenuItemId == menuItem.MenuItemId);

            if (existingMenuItem == null)
                throw new InvalidOperationException("Menu item not found");

            existingMenuItem.Price = menuItem.Price;
            existingMenuItem.Description = menuItem.Description;

            _context.SaveChanges();
        }

        public void DeleteMenuItem(int menuItemId)
        {
            var menuItemToDelete = _context.MenuItems.FirstOrDefault(mi=>mi.MenuItemId == menuItemId);

            if(menuItemToDelete == null)
            {
                throw new InvalidOperationException("Menu item was not found");
            }

            // Remove the MenuItem from the MenuItems DbSet and save changes
            _context.MenuItems.Remove(menuItemToDelete);
            _context.SaveChanges();
        }
    }
}
