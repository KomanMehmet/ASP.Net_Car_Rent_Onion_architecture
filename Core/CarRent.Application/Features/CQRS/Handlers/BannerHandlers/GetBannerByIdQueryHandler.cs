using CarRent.Application.Features.CQRS.Queries.BannerQueries;
using CarRent.Application.Features.CQRS.Results.BannerResults;
using CarRent.Domain.Entities;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                VideoUrl = values.VideoUrl,
                VideoDescription = values.VideoDescription,
                Title = values.Title,
                Description = values.Description
            };
        }
    }
}
