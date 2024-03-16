using CarRent.Dto.ReviewDtos;
using CarRent.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIDComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCommentsByCarIDComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ResultReviewByCarIdDto resultReviewByCarIdDto = new ResultReviewByCarIdDto();

            ViewBag.CarID = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7197/api/Reviews?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
