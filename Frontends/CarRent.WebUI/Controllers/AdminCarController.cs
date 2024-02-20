using CarRent.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//bir tane istemci oluştur

            var responseMessage = await client.GetAsync("https://localhost:7197/api/Cars/GetCarWithBrand");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDtos>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            return View();
        }
    }
}
