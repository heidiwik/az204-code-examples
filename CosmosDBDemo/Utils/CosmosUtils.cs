using CosmosDBDemo.Models;
using Microsoft.Azure.Cosmos;
using System;
using Microsoft.Extensions.Configuration;

namespace CosmosDBDemo.Utils
{
    public class CosmosDBConnector
    {
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        public CosmosDBConnector()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: false, reloadOnChange: true)
                .Build();

            var endpointUrl = configuration["CosmosDB:EndpointUrl"];
            var authKey = configuration["CosmosDB:AuthKey"];
            var databaseName = configuration["CosmosDB:DatabaseName"];
            var containerName = configuration["CosmosDB:ContainerName"];

            cosmosClient = new CosmosClient(endpointUrl, authKey);
            
            database = cosmosClient.GetDatabase(databaseName);

            container = database.GetContainer(containerName);
        }

        public async Task<List<Link>?> QueryItemsByLearningPathAsync(int learningPath)
        {
            var query = $"SELECT * FROM c WHERE c.learningPath = '{learningPath}'";

            try
            {
                FeedIterator<Link> feed = container.GetItemQueryIterator<Link>(queryText: query);


                List<Link> items = new List<Link>();


                while (feed.HasMoreResults)
                {
                    FeedResponse<Link> response = await feed.ReadNextAsync();

                    foreach (Link item in response)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nError when fetching data from Cosmos DB: " + ex.Message);
            }
            return null;

        }
    }


}
