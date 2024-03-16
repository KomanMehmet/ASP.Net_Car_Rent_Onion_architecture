using CarRent.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//bir tane istemci oluştur

            #region Araba Sayısı İstatistikleri
            var responseMessage1 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);

                ViewBag.v1 = values1.CarCount;
            }
            #endregion

            #region Lokasyon Sayısı İstatistikleri
            var responseMessage2 = await client.GetAsync("https://localhost:7197/api/Statistics/GetLocationCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);

                ViewBag.v2 = values2.LocationCount;
            }
            #endregion

            #region Marka Sayısı İstatistikleri
            var responseMessage3 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);

                ViewBag.v3 = values3.BrandCount;
            }
            #endregion

            #region Günlük Ortalama Kiralama Bedeli İstatistikleri
            var responseMessage4 = await client.GetAsync("https://localhost:7197/api/Statistics/GetAvarageRentPriceToDaily");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);

                ViewBag.v4 = values4.AvgPriceToDaily.ToString("0.00");
            }
            #endregion

            return View();
        }
    }
}
