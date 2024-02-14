using CarRent.Application.Features.Mediator.Commands.BlogCommands;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);

            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.AuthorID = request.AuthorID;
            value.CategoryID = request.CategoryID;
            value.CreatedDate = request.CreatedDate;

            await _repository.UpdateAsync(value);
        }
    }
}
