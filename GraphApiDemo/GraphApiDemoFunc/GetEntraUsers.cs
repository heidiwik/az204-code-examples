using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using GraphApiDemoFunc.Models;
using GraphApiDemoFunc.Utils;
using System.Text.Json;


namespace GraphApiDemoFunc
{
    public class GetEntraUsers
    {

        private readonly ILogger<GetEntraUsers> _logger;
        private IConfiguration _config;

        public GetEntraUsers(ILogger<GetEntraUsers> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [Function("GetEntraUsers")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            var users = await GraphUtils.GetUsers(_config, _logger);

            if (users == null)
            {
                return new BadRequestObjectResult("Error getting users");
            }

            List<UserData> userNames = new List<UserData>();

            foreach (var user in users)
            {
                if (user == null || user?.DisplayName == null)
                {
                    continue;
                }

                userNames.Add(new UserData
                {
                    Name = user.DisplayName,
                    City = user.City
                });
            }

            var userNamesJson = JsonSerializer.Serialize(userNames);

            return new OkObjectResult(userNamesJson);
        }
    }
}

