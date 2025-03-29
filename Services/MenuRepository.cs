using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        // Static list to act as an in-memory data store with 5 sample menus
        private static List<Menu> _menus = new List<Menu>
        {
            new Menu { Id = 1, Name = "Breakfast Menu", Description = "Morning meals", Price = 15.99 },
            new Menu { Id = 2, Name = "Lunch Menu", Description = "Afternoon meals", Price = 25.99 },
            new Menu { Id = 3, Name = "Dinner Menu", Description = "Evening meals", Price = 35.99 },
            new Menu { Id = 4, Name = "Kids Menu", Description = "Meals for kids", Price = 10.99 },
            new Menu { Id = 5, Name = "Dessert Menu", Description = "Sweet treats", Price = 12.99 }
        };

        public Menu AddMenu(Menu menu)
        {
            _menus.Add(menu);
            return menu;
        }

        public void DeleteMenu(int id)
        {
            _menus = _menus.Where(obj => obj.Id != id).ToList(); 
        }

        public List<Menu> GetAllMenu()
        {
            return _menus;
        }

        public Menu GetMenu(int id)
        {
            return _menus.Where(obj => obj.Id == id).FirstOrDefault();
        }

        public Menu UpdateMenu(Menu menu)
        {
            return menu;
        }
    }
}
