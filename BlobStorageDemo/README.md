# Azure Blob Storage Demo

This project demonstrates basic operations with Azure Blob Storage using the Azure.Storage.Blobs library. 

It includes creating a blob container, uploading a file to the container, downloading the file from the container, and cleaning up by deleting the container and local files.

https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/4-develop-blob-storage-dotnet


# Connect to Azure Blob Storage

In Azure Portal:
Copy the connection string from the portal and set it to Key Vault on Azure
Create a new environment variable named 'CosmosDBConnectionString' and set the value to the connection string as reference in the portal

More information of using Environment Variables in Azure can be found here:
https://learn.microsoft.com/en-us/azure/app-service/configure-common?tabs=portal

More information on how to set up Key Vault can be found here:
https://learn.microsoft.com/en-us/azure/key-vault/general/quick-create-portal
https://learn.microsoft.com/en-us/azure/app-service/app-service-key-vault-references?tabs=azure-cli#-understand-source-app-settings-from-key-vault

Local testing:
Set the connection string to the environment variable 'CosmosDBConnectionString' on your local.settings.json