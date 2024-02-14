using CarRent.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogQuery : IRequest<List<GetBlogQueryResult>>
    {
    }
}
