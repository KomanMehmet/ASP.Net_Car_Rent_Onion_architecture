using CarRent.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarRent.Application.Features.Mediator.Results.CarDescriptionResults;
using CarRent.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;


namespace CarRent.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescription(request.Id);

            return new GetCarDescriptionQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                Details = values.Details,
                CarID = values.CarID
            };
        }
    }
}
