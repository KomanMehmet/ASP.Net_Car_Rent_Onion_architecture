
using CarRent.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarRent.Application.Features.Mediator.Results.SocialMediaResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repotistory;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repotistory)
        {
            _repotistory = repotistory;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repotistory.GetAllAsync();

            return values.Select(x => new GetSocialMediaQueryResult
            {
                Icon = x.Icon,
                Name = x.Name,
                SocialMediaID = x.SocialMediaID,
                Url = x.Url
            }).ToList();
        }
    }
}
