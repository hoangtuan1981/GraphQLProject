using Microsoft.AspNetCore.Mvc;

namespace GraphQLClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuClientController : ControllerBase
    {
        private readonly GraphQLClientService _graphQLClientService;
        public MenuClientController(GraphQLClientService graphQLClientService)
        {
            _graphQLClientService = graphQLClientService;
        }


        [HttpGet]
        public async Task<IActionResult> Menus()
        {
            var result = await _graphQLClientService.GetMenusAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddMenu()
        {
            var result = await _graphQLClientService.CreateMenuAsync(10,"test 1", "Descript 555", 100);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMenu()
        {
            var result = await _graphQLClientService.UpdateMenuAsync(10, "test 1", "Descript 555", 100);
            return Ok(result);
        }
    }
}
