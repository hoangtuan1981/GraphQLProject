using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface IMenuRepository
{
    List<Menu> GetAllMenu();
    Menu GetMenu(int id); 
    Menu AddMenu(Menu menu);
    Menu UpdateMenu(Menu menu);
    void DeleteMenu(int id);
}
