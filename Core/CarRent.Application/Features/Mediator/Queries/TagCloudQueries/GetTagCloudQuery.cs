using CarRent.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
    {
    }
}
