using GraphQLClient.Models;
using System.Text;
using System.Text.Json;

namespace GraphQLClient;

public class GraphQLClientService
{
    private readonly HttpClient _httpClient;
    private string _url = "https://localhost:7287/graphql";
    public GraphQLClientService()
    {
        _httpClient = _httpClient ?? new HttpClient();
    }

    public async Task<List<Menu>> GetMenusAsync()
    {
        var query = new
        {
            query = @"query firstGraphQuery{
			        menus{
				        id
				        name
			        }
		        }"
        };

        var requestContent = new StringContent(
            JsonSerializer.Serialize(query),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(_url, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GraphQL request failed: {response.StatusCode}");
        }
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var json = await response.Content.ReadAsStringAsync();
        // Deserialize JSON
        var jsonResponse = JsonSerializer.Deserialize<GraphQLResponse>(json, options);

        List<Menu> menus = jsonResponse?.Data?.Menus ?? new List<Menu>();

        return menus;
    }


    public async Task<string> CreateMenuAsync(int id, string name, string description, decimal price)
    {
        //var mutation = new
        //{
        //    mutation = @"mutation CreateMenu($menu: MenuInput){
        //       createMenu(menu : $menu){
        //        id
        //        name
        //        description
        //        price
        //        }
        //       }
        //            },
        //    variables = new
        //    {
        //        menu = new
        //        {
        //            id = id,
        //            name = name,
        //            description = description,
        //            price = price
        //        }
        //    }"
        //};

        //var requestContent = new StringContent(
        //    JsonSerializer.Serialize(mutation),
        //    Encoding.UTF8,
        //    "application/json");

        //var response = await _httpClient.PostAsync(_url, requestContent);

        //if (!response.IsSuccessStatusCode)
        //{
        //    throw new Exception($"GraphQL request failed: {response.StatusCode}");
        //}

        //return await response.Content.ReadAsStringAsync();

        var mutation = new
        {
            query = @"mutation CreateMenu($menu: MenuInput){
                        createMenu(menu: $menu){
                            id
                            name
                            description
                            price
                        }
                    }",
            variables = new
            {
                menu = new
                {
                    id = id,
                    name = name,
                    description = description,
                    price = price
                }
            }
        };

        var requestContent = new StringContent(
            JsonSerializer.Serialize(mutation),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(_url, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GraphQL request failed: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdateMenuAsync(int id, string name, string description, decimal price)
    {
        var mutation = new
        {
            query = @"mutation UpdateMenu($id: Int, $menu: MenuInput){
                        updateMenu(menuId: $id, menu: $menu){
                            id
                            name
                            description
                            price
                        }
                    }",
            variables = new
            {
                id = id,
                menu = new
                {
                    id = id,
                    name = name,
                    description = description,
                    price = price
                }
            }
        };

        var requestContent = new StringContent(
            JsonSerializer.Serialize(mutation),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(_url, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"GraphQL request failed: {response.StatusCode}");
        }

        return await response.Content.ReadAsStringAsync();
    }
}