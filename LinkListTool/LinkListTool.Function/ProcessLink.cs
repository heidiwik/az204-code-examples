using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using LinkList.Models;
using LinkList.Utils;
using Newtonsoft.Json;

using Microsoft.Extensions.Configuration;

namespace LinkList
{
    public class ProcessLink
    {
        private readonly ILogger<ProcessLink> _logger;
        private readonly IConfiguration _configuration;

        public ProcessLink(ILogger<ProcessLink> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }

        [Function("ProcessLink")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {

            _logger.LogInformation("Function ProcessLink processed a request.");

            if (req == null)
            {
                return new BadRequestObjectResult("Please provide a valid request with the necessary parameters.");
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            // Deserialize the JSON into a dynamic object or a specific type
            dynamic? data = JsonConvert.DeserializeObject(requestBody);

            if (data == null)
            {
                return new BadRequestObjectResult("Please provide a valid request with the necessary parameters.");
            }

            var link = new Link()
            {
                Url = data?.LinkUrl,
                Text = data?.LinkText,
                Category = data?.LinkCategory,
                LearningPath = data?.LinkLearningPathInt,
                PartitionKey = "Link",
                RowKey = Guid.NewGuid().ToString()
            };

            _logger.LogInformation($"Link URL: {link.Url}, Link Text: {link.Text}, Link Category: {link.Category}, Learning Path: {link.LearningPath}");

            if (string.IsNullOrEmpty(link.Url))
            {
                return new BadRequestObjectResult("Link URL is required.");
            }

            // save link to table storage

            _logger.LogInformation("Saving link to table storage...");

            var result = await TableStorageUtils.SaveLink(_logger, _configuration, link);
            if (!result)
            {
                _logger.LogInformation("An error occurred while saving the link.");

                return new BadRequestObjectResult("An error occurred while saving the link.");
            }

            // todo: send notification to teams channel if link is saved

            _logger.LogInformation("Link has been successfully saved.");

            return new OkObjectResult("Link has been successfully saved.");
        }
    }
}
