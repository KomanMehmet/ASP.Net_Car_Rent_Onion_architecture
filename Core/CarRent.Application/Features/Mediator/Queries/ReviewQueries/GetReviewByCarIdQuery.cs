using CarRent.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIdQuery : IRequest<List<GetReviewByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
