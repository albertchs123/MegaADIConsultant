using Microsoft.AspNetCore.Mvc;
using MSF_ADI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace MSF_ADI_FE.Controllers
{
    public class BpkbController : Controller
    {
        private readonly HttpClient _httpClient;

        public BpkbController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Create()
        {
            // Fetch storage locations to populate dropdown
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bpkb model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/api/bpkb", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Data saved successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Error saving data!";
                return View();
            }
        }
    }
}
