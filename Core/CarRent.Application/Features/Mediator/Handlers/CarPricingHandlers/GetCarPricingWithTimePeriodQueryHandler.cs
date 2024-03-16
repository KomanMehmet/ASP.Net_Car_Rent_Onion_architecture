using CarRent.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRent.Application.Features.Mediator.Results.CarPricingResults;
using CarRent.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _carPricingRepository.GetCarPricingWithTimePeriod();

			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Model = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				BrandName = x.BrandName,
				AmountDaily = x.Amounts[0],
				AmountWeekly = x.Amounts[1],
				AmountMountly = x.Amounts[2],
			}).ToList();
		}
	}
}
