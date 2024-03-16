using CarRent.Application.Features.Mediator.Queries.AboutQueries;
using CarRent.Application.Features.Mediator.Results.AboutResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetAboutByIdQueryResult
            {
                AboudID = value.AboudID,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title
            };
        }
    }
}
