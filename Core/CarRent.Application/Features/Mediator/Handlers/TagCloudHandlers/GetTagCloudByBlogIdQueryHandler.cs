using CarRent.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRent.Application.Features.Mediator.Results.TagCloudResults;
using CarRent.Application.Interfaces.TagCloudInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudByBlogId(request.Id);

            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                Title = x.Title,
                BlogID = x.BlogID,
                TagClodID = x.TagClodID
            }).ToList();
        }
    }
}
