using CarRent.Application.Features.Mediator.Commands.FooterAddresCommands;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    internal class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressID);

            value.PhoneNumber = request.PhoneNumber;
            value.Address = request.Address;
            value.Description = request.Description;
            value.Email = request.Email;

            await _repository.UpdateAsync(value);
        }
    }
}
