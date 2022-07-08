using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RingCentralReport.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Import()
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();

                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient _httpClient = new HttpClient(clientHandler);
                _httpClient.Timeout = TimeSpan.FromMinutes(30);
               var response = await _httpClient.PostAsync("https://localhost:7023/api/SyncAllData", null);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {

            }
            return View("index");
        }
    }
}
