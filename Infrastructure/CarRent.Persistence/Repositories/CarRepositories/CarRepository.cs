using CarRent.Application.Interfaces.CarInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentContext _context;

        public CarRepository(CarRentContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();

            return values;
        }


		public List<Car> GetLastFiveCarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();

            return values;
        }
    }
}
