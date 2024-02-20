using CarRent.Application.Interfaces.CarPricingInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarRentContext _context;

		public CarPricingRepository(CarRentContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();

			return values;
		}

	}
}
