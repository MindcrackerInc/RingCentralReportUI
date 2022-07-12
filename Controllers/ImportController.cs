using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RingCentralReport.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly IConfiguration _configuration;
        public ImportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Import()
        {
            try
            {
                string URL= _configuration["RingCentralApi:URL"].ToString();
                HttpClientHandler clientHandler = new HttpClientHandler();

                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient _httpClient = new HttpClient(clientHandler);
                _httpClient.Timeout = TimeSpan.FromMinutes(30);
               var response = await _httpClient.PostAsync(URL, null);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {

            }
            return View("index");
        }
    }
}
