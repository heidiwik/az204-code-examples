# AZ-204 Code Examples

This repository contains a collection of code samples for the AZ-204 course. These examples are designed to help students practice and deepen the understanding of Azure development concepts through hands-on projects.

Feel free to explore the projects and use them to reinforce your understanding.

Found something to improve? Pull requests are always welcome.

## Blob Storage demo
A console application demonstrating how to interact with Azure Blob Storage, including uploading, downloading, and managing blobs. 

Based on [Microsoft Learn exercise](https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/4-develop-blob-storage-dotnet)

## Cosmos DB demo
A console application that demonstrates how to work with Azure Cosmos DB.

## Graph API demo
A Azure function that demonstraters how to authenticate to Microsoft Graph API and how to fetch data from Graph API

## LinkList application & LinkListTool
**LinkList** is a web application designed to provide additional information for the AZ-204 course by providing links to resources and topics covered in the course.

**LinkListTool** provides functionality for adding links.

### 1. LinkList web application
Azure web application for sharing links. Code to be added soon.

### 2. LinkListTool web application
Azure web application that provides functionality to add links to a table storage using a web interface. It interacts with an Azure Function App that processes and stores the submitted links.

### 3. LinkListTool function
Azure function app that processes links submitted through the application's form and stores them in Azure Table Storage.

### 4. LinkListTool Azure Table Storage
Azure storage account that stores links submitted through the application's form.

### Requirements for Azure resources for hosting the solution in Azure
Azure subscription with following resources:
- Storage Account
- Web Application
- Function App




