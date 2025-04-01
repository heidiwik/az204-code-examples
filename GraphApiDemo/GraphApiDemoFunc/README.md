
# Graph API Demo Azure Function

This project demonstrates how to use Microsoft Graph API in an Azure Function to retrieve user information. The project also demonstrates how to authenticate to the Microsoft Graph API using an app registration in Entra ID.

The Azure Function is built using the Azure Functions Worker runtime and the Microsoft Graph SDK.


## GetEntraUsers Function

The `GetEntraUsers` function is an HTTP-triggered function that retrieves user information from Microsoft Graph API. The function returns a list of users in the organization as JSON. 

## Microsoft Graph Utils
Microsoft Graph Utils contains utility methods for creating a GraphServiceClient and fetching users from Microsoft Graph API.

## Usage 

1. Create app registration in Azure Entra ID: https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-register-app?tabs=certificate%2Cexpose-a-web-api#register-an-application
2. Add the following environment variables to the Azure Function App settings:
	- `EntraClientId`: The client ID of the app registration in Entra ID.
	- `EntraClientSecret`: The client secret of the app registration in Entra ID.
	- `EntraTenantId`: The tenant ID of the app registration in Entra ID.
3. Add following Microsoft Graph application permissions to the app registration in Entra ID:
	- `User.Read.All`: Read all users' full profiles
	https://learn.microsoft.com/en-us/entra/identity-platform/quickstart-configure-app-access-web-apis?source=recommendations#add-permissions-to-access-microsoft-graph
4. Run the application and navigate to the `GetEntraUsers` function URL to retrieve user information