using CarRent.Dto.AboutDtos;
using CarRent.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.CarId = id;

            var client = _httpClientFactory.CreateClient();

            var respoenseMessage = await client.GetAsync($"https://localhost:7197/api/CarDescriptions?carId=" + id);

            if (respoenseMessage.IsSuccessStatusCode)
            {
                var jsonData = await respoenseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
