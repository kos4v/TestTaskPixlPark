using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
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

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            string publicKey = "38cd79b5f2b2486d86f562e3c43034f8";
            string privateKey = "8e49ff607b1f46e1a5e8f6ad5d312a80";
            string output = await GetAccessKey(publicKey, privateKey);
            System.Diagnostics.Debug.WriteLine(output);
            ResponseOrders response = await GetProduct(output);
            response.Start();
            System.Diagnostics.Debug.WriteLine("output");
            System.Diagnostics.Debug.WriteLine(response.Result[0].Shipping);
            foreach (var item in response.Result)
            {
                System.Diagnostics.Debug.WriteLine("output");
                System.Diagnostics.Debug.WriteLine(item.Shipping.Title);
            }
            ViewBag.products = response.Result;
            return View();
        }

        static async Task<ResponseOrders> GetProduct(string accessKey)
        {
            string path = "http://api.pixlpark.com/orders?oauth_token="+ accessKey;
            HttpResponseMessage response = await client.GetAsync(path);
            ResponseOrders responseOrders;
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                responseOrders = await response.Content.ReadAsAsync<ResponseOrders>();
                return responseOrders;
            }
            return null;
        }



        static async Task<string> GetAccessKey(string publicKey, string privateKey)
        {
            string path = "http://api.pixlpark.com/oauth/requesttoken";
            HttpResponseMessage response = await client.GetAsync(path);
            ResponseAuth responseRequest =  new ResponseAuth();
            if (response.IsSuccessStatusCode)
            {
                responseRequest = await response.Content.ReadAsAsync<ResponseAuth>();
            }

            
            StringBuilder password;
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(responseRequest.RequestToken + privateKey));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte s in hash) sb.Append(s.ToString("x2"));
                System.Diagnostics.Debug.WriteLine(sb);
                password = sb;
            }
            string AccessUrl = "http://api.pixlpark.com/oauth/accesstoken/?oauth_token=" + responseRequest.RequestToken +
                "&username=" + publicKey +
                "&password=" + password;

            System.Diagnostics.Debug.WriteLine(AccessUrl);


            ResponseAuth responseAccess;
            HttpResponseMessage responseAcccess = await client.GetAsync(AccessUrl);
            if (responseAcccess.IsSuccessStatusCode)
            {
                var res1 = await responseAcccess.Content.ReadAsStringAsync();
                responseAccess = await responseAcccess.Content.ReadAsAsync<ResponseAuth>();
                System.Diagnostics.Debug.WriteLine(res1);
                return responseAccess.AccessToken;
            }
            return "Unsuccess";
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


}
