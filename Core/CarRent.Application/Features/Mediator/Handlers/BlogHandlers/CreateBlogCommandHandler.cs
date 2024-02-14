using CarRent.Application.Features.Mediator.Commands.BlogCommands;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                CoverImageUrl = request.CoverImageUrl,
                CategoryID = request.CategoryID,
                AuthorID = request.AuthorID,
                CreatedDate = request.CreatedDate,
                Title = request.Title,
            });
        }
    }
}
