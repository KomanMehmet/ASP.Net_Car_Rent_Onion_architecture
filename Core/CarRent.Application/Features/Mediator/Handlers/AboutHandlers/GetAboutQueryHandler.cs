using CarRent.Application.Features.Mediator.Queries.AboutQueries;
using CarRent.Application.Features.Mediator.Results.AboutResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _Repostiroy;

        public GetAboutQueryHandler(IRepository<About> repostiroy)
        {
            _Repostiroy = repostiroy;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _Repostiroy.GetAllAsync();

            return values.Select(x => new GetAboutQueryResult
            {
                AboudID = x.AboudID,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
