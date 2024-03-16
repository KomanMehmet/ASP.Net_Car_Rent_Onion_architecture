using CarRent.Application.Interfaces.CarPricingInterfaces;
using CarRent.Application.ViewModels;
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


		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();

			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From(Select Brands.Name,Model,CoverImageUrl,PricingID,Amound From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amound) For PricingID In ([2], [3], [6])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							BrandName = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader[3]),
								Convert.ToDecimal(reader[4]),
								Convert.ToDecimal(reader[5])
							}
						};

						values.Add(carPricingViewModel);
						
					}
				}
				_context.Database.CloseConnection();
				return values;
			};
		}
	}
}









//List<CarPricing> values = new List<CarPricing>();

//using (var command = _context.Database.GetDbConnection().CreateCommand())
//{
//	command.CommandText = "Select * From(Select Brands.Name, Model, PricingID, Amound From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amound) For PricingID In ([2], [3], [6])) as PivotTable;";
//	command.CommandType = System.Data.CommandType.Text;
//	_context.Database.OpenConnection();
//	using (var reader = command.ExecuteReader())
//	{
//		while (reader.Read())
//		{
//			CarPricing carPricing = new CarPricing();

//			Enumerable.Range(1, 3).ToList().ForEach(x =>
//			{
//				if (DBNull.Value.Equals(reader[x]))
//				{
//					carPricing.Amound
//							}
//				else
//				{
//					carPricing.Amound.
//							}
//			});
//			values.Add(carPricing);
//		}
//	}
//	_context.Database.CloseConnection();
//	return values;
//};
