using CarRent.Application.ViewModels;
using CarRent.Domain.Entities;

namespace CarRent.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricing> GetCarPricingWithCars();

		List<CarPricingViewModel> GetCarPricingWithTimePeriod();
	}
}
