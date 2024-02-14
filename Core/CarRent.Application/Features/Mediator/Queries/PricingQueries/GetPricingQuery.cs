using CarRent.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}
