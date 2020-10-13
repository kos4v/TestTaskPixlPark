using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTaskPixlPark.Models;

namespace TestTaskPixlPark.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var output = await GetProductAsync("http://api.pixlpark.com/oauth/requesttoken");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine(output);
            System.Diagnostics.Debug.WriteLine("xxx");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }


}
