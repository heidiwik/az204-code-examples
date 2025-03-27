using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using LinkList.Models;

namespace LinkList.Utils
{    public static class TableStorageUtils
    {
        private static TableClient? CreateClient(IConfiguration configuration, string tableName)
        {
            var endpoint = configuration["TableStorage:Endpoint"];

            if (!string.IsNullOrEmpty(endpoint))
            {
                var tableServiceClient = new TableServiceClient(new Uri(endpoint), new ManagedIdentityCredential());

                var tableClient = tableServiceClient.GetTableClient(tableName: tableName);

                return tableClient;
            }

            else return null;
        }

        public static async Task<IEnumerable<Link>?> GetLinks(ILogger log, IConfiguration configuration)
        {
            try
            {
                var results = new List<Link>();

                var table = configuration["TableStorage:LinkList"];

                if (table != null)
                {
                    var storageClient = CreateClient(configuration, table);

                    if (storageClient != null)
                    {
                        var pagedResults = storageClient.QueryAsync<Link>();

                        await foreach (var page in pagedResults.AsPages())
                        {
                            results.AddRange(page.Values);
                        }
                    }
                    else throw new Exception("Table storage endpoint not configured");
                }
                else throw new Exception("Table storage table name not configured");

                return results.OrderByDescending(r => r.Timestamp);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error occurred while reading table storage: " + ex.Message);
                return null;
            }
        }

        public static async Task<bool> SaveLink(ILogger log, IConfiguration configuration, Link link)
        {
            try
            {
                log.LogInformation($"Saving link to table storage: {link.Url}, {link.Text}, {link.LearningPath}, {link.Category}");

                link.PartitionKey = "Link";
                link.RowKey = Guid.NewGuid().ToString();

                var table = configuration["TableStorage:LinkList"];

                if (table != null && table != "")
                {
                    var storageClient = CreateClient(configuration, table);

                    if (storageClient != null)
                    {
                        var response = await storageClient.UpsertEntityAsync(link);

                        return !response.IsError;
                    }
                    else
                    {
                        //throw new Exception("Table storage endpoint not configured");
                        return false;
                    }
                }
                else
                {
                    //throw new Exception("Table storage table name not configured");
                    return false;
                }
                }
            catch (Exception ex)
            {
                log.LogError(ex, "Error occurred while reading table storage: " + ex.Message);
                return false;
            }
        }
    }
}
