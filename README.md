# intergration with graphQL
    install package:
    GraphQL.Server.Transports.AspNetCore
# visual code
	vscode-graphiql-explorer
# visual studio
	graphiql

# Add : Schema, Type, Query, Mutation


# Test
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

