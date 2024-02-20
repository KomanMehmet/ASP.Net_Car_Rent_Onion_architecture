using CarRent.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRent.Application.Features.Mediator.Results.TagCloudResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetTagCloudByIdQueryResult
            {
                Title = value.Title,
                TagClodID = value.TagClodID,
                BlogID = value.BlogID
            };
        }
    }
}

