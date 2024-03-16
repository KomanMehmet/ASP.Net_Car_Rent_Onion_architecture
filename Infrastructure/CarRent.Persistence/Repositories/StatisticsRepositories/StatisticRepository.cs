using CarRent.Application.Interfaces.StatisticsInterfaces;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarRentContext _context;

        public StatisticRepository(CarRentContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();

            return values;
        }

        public decimal GetAvarageRentPriceToDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();

            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amound);

            return values;
        }

        public decimal GetAvarageRentPriceToMountly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();

            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amound);

            return values;
        }

        public decimal GetAvarageRentPriceToWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();

            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amound);

            return values;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();

            return values;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //Select Top(1) BlogID, COUNT(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc
            var values = _context.Comments.GroupBy(x => x.BlogID).Select(y => new { BlogId = y.Key, Count = y.Count() }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogId).Select(y => y.Title).FirstOrDefault();

            return blogName;
        }

        public string GetBrandAndModelByRentPriceDailyMax()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();

            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amound);

            int carID = _context.CarPricings.Where(x => x.Amound == amount).Select(y => y.CarID).FirstOrDefault();

            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public string GetBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();

            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amound);

            int carID = _context.CarPricings.Where(x => x.Amound == amount).Select(y => y.CarID).FirstOrDefault();

            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();

            return values;
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandID).Select(y => new { BrandId = y.Key, Count = y.Count() }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandId).Select(y => y.Name).FirstOrDefault();

            return brandName;
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();

            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();

            return values;
        }

        public int GetCarCountByFuelGasOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();

            return value;
        }

        public int GetCarCountByKmLessThan1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();

            return value;
        }

        public int GetCarCountByTransmisionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();

            return value;
        }

        public int GetLocationCount()
        {
            var values = _context.Locations.Count();

            return values;
        }
    }
}
