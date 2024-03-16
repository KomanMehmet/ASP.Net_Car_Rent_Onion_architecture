using CarRent.Application.Features.Mediator.Commands.ReviewCommands;
using CarRent.Application.Interfaces;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReviewID);

            values.RaitingValue = request.RaitingValue;
            values.CustomerName = request.CustomerName;
            values.CustomerImage = request.CustomerImage;
            values.ReviewDate = request.ReviewDate;
            values.Comment = request.Comment;
            values.CarID = request.CarID;

            await _repository.UpdateAsync(values);
        }
    }
}
