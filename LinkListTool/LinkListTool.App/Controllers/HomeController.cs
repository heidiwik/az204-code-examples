using System.Diagnostics;
using LinkTool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LinkTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private static readonly HttpClient _httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var model = new Link { };

            if (TempData["Result"] != null)
            {
                ViewBag.Result = TempData["Result"];
                ViewBag.Notice = TempData["Notice"];
            }

            if (_configuration["ShowInstructions"] == "true")
            {
                ViewBag.Instructions = _configuration["Instructions"];
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendForm(Link link)
        {
            if (ModelState.IsValid)
            {
                _logger.LogError("** DEBUG: Link submitted");

                link.Id = Guid.NewGuid();
                link.LinkLearningPathInt = 5;

                var linkExport = new LinkExport
                {
                    LinkUrl = link.LinkUrl,
                    LinkText = link.LinkText,
                    LinkCategory = link.LinkCategory,
                    LinkLearningPathInt = 5
                };

                string jsonData = JsonConvert.SerializeObject(linkExport);


                try
                {
                    // TODO: use managed identity instead of key
                    var functionUrl = _configuration["Func:Url"] + "?code=" + _configuration["Func:Key"];


                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync(functionUrl, content);

                    //  response.EnsureSuccessStatusCode();

                    string responseData = await response.Content.ReadAsStringAsync();

                    // Log the response
                    _logger.LogError("** DEBUG - Response from Azure Function: {responseData}", responseData);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Result"] = "Link saved";
                        TempData["Notice"] = "success";
                    }
                    else
                    {
                        TempData["Result"] = "There was an error: " + " : " + response.ReasonPhrase;
                        TempData["Notice"] = "danger";
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    Console.WriteLine($"Error sending data to Azure Function: {ex.Message}");
                    throw;
                }


                return RedirectToAction("Index");
            }

            return View("Index", link);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
