using MediatR;

namespace CarRent.Application.Features.Mediator.Commands.FooterAddresCommands
{
    public class CreateFooterAddressCommand : IRequest
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
