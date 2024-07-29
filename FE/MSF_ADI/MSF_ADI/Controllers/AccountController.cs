using Microsoft.AspNetCore.Mvc;
using MSF_ADI.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MSF_ADI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var loginContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/api/user/login", loginContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                // Handle success, e.g., store token, redirect, etc.
                ViewBag.Message = "Login successful!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle failure
                ViewBag.Message = "Login failed!";
                return View();
            }
        }
    }
}
