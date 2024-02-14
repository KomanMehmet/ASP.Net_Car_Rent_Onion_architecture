using CarRent.Application.Features.CQRS.Results.BrandResults;
using CarRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repostory;

        public GetBrandQueryHandler(IRepository<Brand> repostory)
        {
            _repostory = repostory;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repostory.GetAllAsync();

            return values.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                Name = x.Name
            }).ToList();
        }
    }
}
