So by the end of the course, you'll completely understand:
How to create a complete real world projects with GraphQL and .Net Core via Entity Framework Code First Approach with all the advanced functions.
Learn GraphQL Essentials including types , queries , mutations , fragments , aliases , variables
Write GraphQL Types
Write GraphQL Queries
Write GraphQL Mutations
Create Restaurant Table Booking Project in .Net Core with GraphQL

# Link
 	https://graphql.org/learn
	1. query
	2. mutation

# intergration with graphQL
    install package:
    GraphQL.Server.Transports.AspNetCore
# visual code
	vscode-graphiql-explorer
# visual studio
	graphiql

# Add : Schema, Type, Query, Mutation


# Test:
#  Query
	https://localhost:7287/graphql
		query firstGraphQuery{
			menus{
				id
				name
			}
		}

		query secondQuery{
			menu(menuID: 1){
				id
				name
				price
			}
		}

# Mutation
#  1. Create Mutation
#		Operation
			mutation CreateMenu($menu: MenuInput){
			createMenu(menu : $menu){
				id
				name
				description
				price
				}
			}
#		Variables
			{
				"menu": {
					"id": 10,
					"name": "test",
					"description": "Descript 1",
					"price": 150.5
				}
			}
#  2. Update Mutation
#		Operation
			mutation UpdateMenu($id: Int, $menu: MenuInput){
				updateMenu(menuId: $id, menu: $menu){
						id
						name
						description
						price
					}
			}
#		Variables
			{
				"id": 10,
				"menu": {
					"id": 10,
					"name": "test 1 ",
					"description": "Descript 555",
					"price": 100
				}
			}