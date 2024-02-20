
using CarRent.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
	{
	}
}
