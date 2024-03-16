using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvarageRentPriceToDailyQueryHandler : IRequestHandler<GetAvarageRentPriceToDailyQuery, GetAvarageRentPriceToDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvarageRentPriceToDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvarageRentPriceToDailyQueryResult> Handle(GetAvarageRentPriceToDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvarageRentPriceToDaily();

            return new GetAvarageRentPriceToDailyQueryResult
            {
                AvgPriceToDaily = value
            };
        }
    }
}
