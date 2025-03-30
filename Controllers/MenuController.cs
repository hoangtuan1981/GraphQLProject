using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuService;

        public MenuController(IMenuRepository menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult GetAllMenus()
        {
            var menus = _menuService.GetAllMenu();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            var menu = _menuService.GetMenu(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        [HttpPost]
        public IActionResult AddMenu([FromBody] Menu menu)
        {
            var addedMenu = _menuService.AddMenu(menu);
            return CreatedAtAction(nameof(GetMenuById), new { id = addedMenu.Id }, addedMenu);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int id, [FromBody] Menu menu)
        {
            var existingMenu = _menuService.GetMenu(id);
            if (existingMenu == null)
            {
                return NotFound();
            }

            menu.Id = id;
            var updatedMenu = _menuService.UpdateMenu(id, menu);
            return Ok(updatedMenu);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id)
        {
            var existingMenu = _menuService.GetMenu(id);
            if (existingMenu == null)
            {
                return NotFound();
            }

            _menuService.DeleteMenu(id);
            return NoContent();
        }
    }
}