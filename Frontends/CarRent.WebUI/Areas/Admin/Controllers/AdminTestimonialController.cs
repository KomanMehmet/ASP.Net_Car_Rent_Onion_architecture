﻿using CarRent.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRent.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]//Hangi sınıf için kullanılacağının belirtilmesi gerekiyor.
    [Route("Admin/AdminTestimonial")]
    public class AdminTestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//bir tane istemci oluştur

            var responseMessage = await client.GetAsync("https://localhost:7197/api/Testimonials");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateTestimonial")]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var respoenseMessage = await client.PostAsync("https://localhost:7197/api/Testimonials", content);

            if (respoenseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }

            return View();
        }


        [Route("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:7197/api/Testimonials?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7197/api/Testimonials/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7197/api/Testimonials", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }

            return View();
        }
    }
}