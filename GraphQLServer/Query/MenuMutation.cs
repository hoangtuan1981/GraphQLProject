using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public class MenuMutation : ObjectGraphType
{
    public MenuMutation(IMenuRepository menuRepository)
    {
        Field<MenuType>("CreateMenu").Arguments(new QueryArgument<MenuInputType> { Name = "menu"}).Resolve(context => {
            return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
        });

        Field<MenuType>("UpdateMenu").Arguments(new QueryArgument<IntGraphType> { Name = "menuId" },
            new QueryArgument<MenuInputType> { Name = "menu" }).Resolve(context => {
            
                var menu = context.GetArgument<Menu>("menu");
                var id = context.GetArgument<int>("menuId");

                return menuRepository.UpdateMenu(id, menu);
        });

        Field<StringGraphType>("DeleteMenu").Arguments(new QueryArgument<IntGraphType> { Name = "menuId"} ).Resolve(context => {

            menuRepository.DeleteMenu(context.GetArgument<int>("menuId"));
            return $"Completed delete menu with id: {context.GetArgument<string>("menuId")}";
        });
    }
}
