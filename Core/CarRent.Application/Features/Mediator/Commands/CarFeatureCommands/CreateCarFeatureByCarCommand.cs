using MediatR;

namespace CarRent.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand : IRequest
    {
        public int CarID { get; set; }

        public int FeatureID { get; set; }

        public bool Avaliable { get; set; }
    }
}
