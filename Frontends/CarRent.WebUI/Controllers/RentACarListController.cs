using CarRent.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
        {
            var locationId = TempData["locationId"];

			id = int.Parse(locationId.ToString());

			ViewBag.locationId = locationId;

			//filterRentACarDto.LocationID = int.Parse(locationId.ToString());
			//filterRentACarDto.Available = true;
			var client = _httpClientFactory.CreateClient();//bir tane istemci oluştur

			var responseMessage = await client.GetAsync($"https://localhost:7197/api/RentACars?locationId={id}&available=true");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);

				return View(values);
			}

			return View();
		}
    }
}
