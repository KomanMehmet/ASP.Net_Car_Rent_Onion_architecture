using CarRent.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
