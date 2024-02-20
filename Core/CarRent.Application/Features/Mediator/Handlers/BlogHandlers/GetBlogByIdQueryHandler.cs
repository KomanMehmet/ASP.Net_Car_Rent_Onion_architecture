using CarRent.Application.Features.Mediator.Queries.BlogQueries;
using CarRent.Application.Features.Mediator.Results.BlogResults;
using CarRent.Application.Interfaces;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetBlogByIdQueryResult
            {
                AuthorID = value.AuthorID,
                BlogID = value.BlogID,
                CategoryID = value.CategoryID,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Title = value.Title,
                Description = value.Description
            };
        }
    }
}
