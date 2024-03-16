using CarRent.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutQuery : IRequest<List<GetAboutQueryResult>>
    {
    }
}
