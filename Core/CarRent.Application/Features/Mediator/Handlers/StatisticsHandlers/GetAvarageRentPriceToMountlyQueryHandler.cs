using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvarageRentPriceToMountlyQueryHandler : IRequestHandler<GetAvarageRentPriceToMountlyQuery, GetAvarageRentPriceToMountlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvarageRentPriceToMountlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvarageRentPriceToMountlyQueryResult> Handle(GetAvarageRentPriceToMountlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvarageRentPriceToMountly();

            return new GetAvarageRentPriceToMountlyQueryResult
            {
                AvgRentPriceToMountly = value
            };
        }
    }
}
