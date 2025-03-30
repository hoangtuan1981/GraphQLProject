namespace GraphQLClient.Models;

public class GraphQLResponse
{
    public MenuData Data { get; set; }
}

public class MenuData
{
    public List<Menu> Menus { get; set; }
}