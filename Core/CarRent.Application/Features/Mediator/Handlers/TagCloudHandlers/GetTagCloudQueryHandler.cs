using CarRent.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRent.Application.Features.Mediator.Results.TagCloudResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {

        private readonly IRepository<TagCloud> _repotistory;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repotistory)
        {
            _repotistory = repotistory;
        }
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repotistory.GetAllAsync();

            return values.Select(x => new GetTagCloudQueryResult
            {
                BlogID = x.BlogID,
                TagClodID = x.TagClodID,
                Title = x.Title
            }).ToList();
        }
    }
}
