using CarRent.Application.Features.Mediator.Queries.RentACarQueries;
using CarRent.Application.Features.Mediator.Results.RentACarResults;
using CarRent.Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);

            return values.Select(x => new GetRentACarQueryResult
            {
                CarID = x.CarID,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl
                
            }).ToList();
        }
    }
}
