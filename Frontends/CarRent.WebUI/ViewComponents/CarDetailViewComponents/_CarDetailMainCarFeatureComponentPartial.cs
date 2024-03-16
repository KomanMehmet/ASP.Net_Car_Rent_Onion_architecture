﻿using CarRent.Dto.CarDtos;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarRent.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
            ViewBag.CarId = id;

			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync($"https://localhost:7197/api/Cars/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<ResultCarWithBrandDto>(jsonData);

				return View(values);
			}

			return View();
        }
    }
}
