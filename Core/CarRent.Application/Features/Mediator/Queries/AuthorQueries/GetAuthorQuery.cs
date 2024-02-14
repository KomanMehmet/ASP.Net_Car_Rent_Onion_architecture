using CarRent.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery : IRequest<List<GetAuthorQueryResult>>
    {

    }
}
