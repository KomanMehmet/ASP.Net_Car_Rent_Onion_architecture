using CarRent.Application.Features.CQRS.Results.CategoryResults;
using CarRent.Domain.Entities;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repostory;

        public GetCategoryQueryHandler(IRepository<Category> repostory)
        {
            _repostory = repostory;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repostory.GetAllAsync();

            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name
            }).ToList();
        }
    }
}
