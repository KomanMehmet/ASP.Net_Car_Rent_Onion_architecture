using CarRent.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarRent.Application.Interfaces.CarFeatureInterfaces;
using CarRent.Domain.Entities;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
            {
                Avaliable = false,
                CarID = request.CarID,
                FeatureID = request.FeatureID
            });
        }
    }
}
