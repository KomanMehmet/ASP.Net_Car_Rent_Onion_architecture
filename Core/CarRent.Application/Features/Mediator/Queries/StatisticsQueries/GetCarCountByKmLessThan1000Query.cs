using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmLessThan1000Query : IRequest<GetCarCountByKmLessThan1000QueryResult>
    {
    }
}
