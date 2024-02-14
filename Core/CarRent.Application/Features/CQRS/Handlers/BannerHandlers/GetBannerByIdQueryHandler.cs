using CarRent.Application.Features.CQRS.Queries.AboutQueries;
using CarRent.Application.Features.CQRS.Queries.BannerQueries;
using CarRent.Application.Features.CQRS.Results.AboutResults;
using CarRent.Application.Features.CQRS.Results.BannerResults;
using CarRent.Application.Interfaces;
using CarRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
