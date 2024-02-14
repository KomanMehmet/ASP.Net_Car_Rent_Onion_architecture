using CarRent.Application.Features.Mediator.Queries.BlogQueries;
using CarRent.Application.Features.Mediator.Results.BlogResults;
using CarRent.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLastTreeBlogsWithAuthorsQueryHandler : IRequestHandler<GetLastTreeBlogsWithAuthorsQuery, List<GetLastTreeBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLastTreeBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLastTreeBlogsWithAuthorsQueryResult>> Handle(GetLastTreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLastTreeBlogsWithAuthors();

            return values.Select(x => new GetLastTreeBlogsWithAuthorsQueryResult
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
