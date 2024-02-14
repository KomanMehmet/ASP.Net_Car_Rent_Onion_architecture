
using CarRent.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
