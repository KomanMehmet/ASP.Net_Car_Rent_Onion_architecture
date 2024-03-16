using CarRent.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region Yazar Sayısı İstatistikleri
            var responseMessage3 = await client.GetAsync("https://localhost:7197/api/Statistics/GetAuthorCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);

                ViewBag.v3 = values3.AuthorCount;
            }
            #endregion

            #region Blog Sayısı İstatistikleri
            var responseMessage4 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBlogCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);

                ViewBag.v4 = values4.BlogCount;
            }
            #endregion

            #region Marka Sayısı İstatistikleri
            var responseMessage5 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandCount");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);

                ViewBag.v5 = values5.BrandCount;
            }
            #endregion

            #region Günlük Ortalama Kiralama Bedeli İstatistikleri
            var responseMessage6 = await client.GetAsync("https://localhost:7197/api/Statistics/GetAvarageRentPriceToDaily");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);

                ViewBag.v6 = values6.AvgPriceToDaily.ToString("0.00");
            }
            #endregion

            #region Haftalık Ortalama Kiralama Bedeli İstatistikleri
            var responseMessage7 = await client.GetAsync("https://localhost:7197/api/Statistics/GetAvarageRentPriceToWeekly");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);

                ViewBag.v7 = values7.AvgRentPriceToWeekly.ToString("0.00");
            }
            #endregion

            #region Aylık Ortalama Kiralama Bedeli İstatistikleri
            var responseMessage8 = await client.GetAsync("https://localhost:7197/api/Statistics/GetAvarageRentPriceToMountly");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);

                ViewBag.v8 = values8.AvgRentPriceToMountly.ToString("0.00");
            }
            #endregion

            #region Otomatik Şanzıman Araç İstatistikleri
            var responseMessage9 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCountByTransmisionIsAuto");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);

                ViewBag.v9 = values9.CarCountByTransmissionIsAuto;
            }
            #endregion

            #region 1000 KM altındaki Araç İstatistikleri
            var responseMessage10 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCountByKmLessThan1000");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);

                ViewBag.v10 = values10.CarCountByKmLessThan1000;
            }
            #endregion

            #region Dizel veya Benzinli Araç Sayısı İstatistikleri
            var responseMessage11 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCountByFuelGasOrDiesel");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);

                ViewBag.v11 = values11.CarCountByFuelGasOrDiesel;
            }
            #endregion

            #region Elektirikli Araç Sayısı İstatistikleri
            var responseMessage12 = await client.GetAsync("https://localhost:7197/api/Statistics/GetCarCountByFuelElectric");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);

                ViewBag.v12 = values12.CarCountByFuelElectric;
            }
            #endregion

            #region Günlük Kiralama Ücreti En Pahalı Araç İsmi İstatistikleri
            var responseMessage13 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandAndModelByRentPriceDailyMax");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);

                ViewBag.v13 = values13.BrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region Günlük Kiralama Ücreti En Ucuz Araç İsmi İstatistikleri
            var responseMessage14 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandAndModelByRentPriceDailyMin");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);

                ViewBag.v14 = values14.BrandAndModelByRentPriceDailyMin;
            }
            #endregion

            #region En Fazla Araç İsmi İstatistikleri
            var responseMessage15 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBrandNameByMaxCar");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);

                ViewBag.v15 = values15.BrandNameByMaxCar;
            }
            #endregion

            #region En Fazla Yorum Alan Blog İstatistikleri
            var responseMessage16 = await client.GetAsync("https://localhost:7197/api/Statistics/GetBlogTitleByMaxBlogComment");//client aracılığıyla api'daki methodlara erişmemizi sağlıyor.

            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();//response mesajdan gelen içeriğimizi stringe çeviriyoruz ve jsonData'ya aktarıyoruz.

                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);

                ViewBag.v16 = values16.BlogTitleByMaxBlogComment;
            }
            #endregion

            return View();
        }
    }
}
