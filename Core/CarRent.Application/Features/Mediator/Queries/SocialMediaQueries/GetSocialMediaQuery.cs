using CarRent.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
