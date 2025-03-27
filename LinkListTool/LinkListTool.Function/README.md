# LinkListTool Function

LinkListTool Function is a .NET 8 Azure Function that utilizes Azure Table Storage to manage a list of links. This project includes utilities for interacting with Azure Table Storage, specifically for saving and retrieving links.

## LinkList application

LinkList application consist of four parts: 
- LinkList web application is an application designed to provide additional information for the AZ-204 course by managing and storing links
- LinkListTool web application is an application that provides the functionality to add links to database using web application
- LinkListTool function processes links submitted through the application's form and stores them in Azure Table Storage
- LinkListTool Azure table storage is a storage account that stores links submitted through the application's form


## Prerequisites

- .NET 8 SDK

- Azure subscription with following resources:
	- Azure Storage Account
	- Azure Web Application
	- Azure Function App
	- Managed Identity for accessing Azure Table Storage

## Configuration


## Usage

### ProcessLink function

## Configuration

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Configure the Azure Storage connection string in the `local.settings.json` file:
4. Deploy the Azure Function to your Azure Function App.

## Usage

### ProcessLink function

The `ProcessLink` function can be triggered via an HTTP POST request. 

Below are the steps to call the function for testing:

1. Obtain the URL of the deployed Azure Function. This can be found in the Azure portal under your Function App.
2. Use a tool like `curl`, Postman, or any HTTP client to send a POST request to the function URL.
