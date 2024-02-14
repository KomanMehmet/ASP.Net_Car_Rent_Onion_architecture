using CarRent.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
