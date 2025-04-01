using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Models;
using Microsoft.Extensions.Configuration;

namespace GraphApiDemoFunc.Utils
{
    internal class GraphUtils
    {
        private static async Task<GraphServiceClient> CreateClient(IConfiguration config)
        {
            var credential = new ClientSecretCredential(config["TenantId"], config["ClientId"], config["ClientSecret"]);

            var scopes = new[] { "https://graph.microsoft.com/.default" };

            return new GraphServiceClient(credential, scopes);
        }

        public static async Task<IEnumerable<User>?> GetUsers(IConfiguration config, ILogger log)
        {
            try
            {
                var client = await CreateClient(config);
                var users = await client.Users.GetAsync();
                return users?.Value;
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error getting users");
                return null;
            }
        }
    }
}
