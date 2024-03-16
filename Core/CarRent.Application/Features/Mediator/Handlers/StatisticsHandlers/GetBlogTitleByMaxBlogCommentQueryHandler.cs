using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogTitleByMaxBlogComment();

            return new GetBlogTitleByMaxBlogCommentQueryResult
            {
                BlogTitleByMaxBlogComment = value
            };
        }
    }
}
