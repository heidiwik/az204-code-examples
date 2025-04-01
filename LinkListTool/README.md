# LinkList application & LinkListTool
**LinkList** is a web application designed to provide additional information for the AZ-204 course by providing links to resources and topics covered in the course.

**LinkListTool** provides functionality for adding links.

## 1. LinkList web application
Azure web application for sharing links. Code to be added soon. TODO

## 2. LinkListTool web application
Azure web application that provides functionality to add links to a table storage using a web interface. It interacts with an Azure Function App that processes and stores the submitted links.

## 3. LinkListTool function
Azure function app that processes links submitted through the application's form and stores them in Azure Table Storage.

## 4. LinkListTool Azure Table Storage
Azure storage account that stores links submitted through the application's form.

## Requirements for Azure resources for hosting the solution in Azure
Azure subscription with following resources:
- Storage Account
- Web Application
- Function App