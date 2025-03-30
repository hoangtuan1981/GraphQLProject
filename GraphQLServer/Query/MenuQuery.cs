using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public class MenuQuery : ObjectGraphType
{
    public MenuQuery( IMenuRepository menuRepository)
    {
        Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
        {
            return menuRepository.GetAllMenu();
        });

        Field<MenuType>("Menu").Arguments(new QueryArgument<IntGraphType> { Name = "menuID" }).Resolve(context => {
            return menuRepository.GetMenu(context.GetArgument<int>("menuID"));
        });
    }
}
