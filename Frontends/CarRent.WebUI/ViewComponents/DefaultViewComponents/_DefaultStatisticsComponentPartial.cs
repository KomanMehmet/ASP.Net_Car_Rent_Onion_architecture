using CarRent.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region Araba Sayısı İstatistikleri
            var responseMessage1 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);

                ViewBag.CarCount = values1.CarCount;
            }
            #endregion

            #region Lokasyon Sayısı İstatistikleri
            var responseMessage2 = await client.GetAsync("https://localhost:7197/api/Statistics/GetLocationCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);

                ViewBag.LocationCount = values2.LocationCount;
            }
            #endregion

            #region Marka Sayısı İstatistikleri
            var responseMessage5 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);

                ViewBag.BrandCount = values5.BrandCount;
            }
            #endregion

            #region Elektirikli Araç Sayısı İstatistikleri
            var responseMessage12 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCountByFuelElectric");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);

                ViewBag.CarCountElectric = values12.CarCountByFuelElectric;
            }
            #endregion

            return View();
        }
    }
}
