using CarRent.Application.Features.CQRS.Results.BannerResults;
using CarRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repostory;

        public GetBannerQueryHandler(IRepository<Banner> repostory)
        {
            _repostory = repostory;
        }

        public async Task<List<GetBannerQueryResult>> Handle() 
        {
            var values = await _repostory.GetAllAsync();

            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Title = x.Title,
                Description = x.Description,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl,
            }).ToList();
        }
    }
}
