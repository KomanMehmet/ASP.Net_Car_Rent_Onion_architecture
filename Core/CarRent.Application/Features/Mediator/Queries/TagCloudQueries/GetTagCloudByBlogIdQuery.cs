using CarRent.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTagCloudByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
