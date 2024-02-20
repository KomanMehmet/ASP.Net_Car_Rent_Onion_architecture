using CarRent.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRent.Application.Features.Mediator.Results.CarPricingResults;
using CarRent.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWithCars();

			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
				Amount = x.Amound,
				Brand = x.Car.Brand.Name,
				CarPricingID = x.CarPricingID,
				CoverImageUrl = x.Car.CoverImageUrl,
				Model = x.Car.Model
			}).ToList();
		}
	}
}
