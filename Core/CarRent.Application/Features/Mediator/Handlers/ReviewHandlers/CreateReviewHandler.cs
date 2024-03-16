using CarRent.Application.Features.Mediator.Commands.ReviewCommands;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                CarID = request.CarID,
                CustomerName = request.CustomerName,
                RaitingValue = request.RaitingValue,
                ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())

            });
        }
    }
}
