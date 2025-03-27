using CosmosDBDemo.Models;
using CosmosDBDemo.Utils;

namespace CosmosDBDemo
{
    class CosmosDBDemo
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the AZ-204 Link Finder!\n");

            Console.WriteLine("[1] App Service");
            Console.WriteLine("[2] Azure Functions");
            Console.WriteLine("[3] Blob Storage");
            Console.WriteLine("[4] Cosmos DB");
            Console.WriteLine("[5] Containers");
            Console.WriteLine("[6] Authentication & Authorization");
            Console.WriteLine("[7] Secure Cloud");
            Console.WriteLine("[8] API Management");
            Console.WriteLine("[9] Event-Based Solutions");
            Console.WriteLine("[10] Message-Based Solutions");
            Console.WriteLine("[11] Application Insights");
            Console.WriteLine("[12] Caching\n");

            Console.WriteLine("Enter the learning path:");

            int learningPath = Convert.ToInt32(Console.ReadLine());

            try
            {
                CosmosDBConnector cosmosDBConnector = new CosmosDBConnector();

                if (cosmosDBConnector == null)
                {
                    Console.WriteLine("Error: Could not initialize Cosmos DB connector");
                    return;
                }

                List<Link>? links = await cosmosDBConnector.QueryItemsByLearningPathAsync(learningPath);

                if (links == null)
                {
                    Console.WriteLine($"No links found for learning path {learningPath}");
                    return;
                }

                Console.WriteLine($"Found {links.Count} links for learning path {learningPath}:\n");

                foreach (Link link in links)
                {
                    Console.WriteLine($" {link.Text} : {link.Url}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);

            }
        }
    }
}
