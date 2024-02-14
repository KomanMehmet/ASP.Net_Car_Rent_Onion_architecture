using CarRent.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
    {
    }
}
