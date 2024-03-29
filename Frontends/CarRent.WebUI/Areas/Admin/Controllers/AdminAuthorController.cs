﻿using CarRent.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRent.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]//Hangi sınıf için kullanılacağının belirtilmesi gerekiyor.
    [Route("Admin/AdminAuthor")]
    public class AdminAuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//bir tane istemci oluştur

            var responseMessage = await client.GetAsync("https://localhost:7197/api/Authors");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateAuthor")]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createAuthorDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var respoenseMessage = await client.PostAsync("https://localhost:7197/api/Authors", content);

            if (respoenseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }

            return View();
        }


        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:7197/api/Authors?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7197/api/Authors/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateAuthorDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7197/api/Authors", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }

            return View();
        }
    }
}
