using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvarageRentPriceToWeeklyQueryHandler : IRequestHandler<GetAvarageRentPriceToWeeklyQuery, GetAvarageRentPriceToWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvarageRentPriceToWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvarageRentPriceToWeeklyQueryResult> Handle(GetAvarageRentPriceToWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvarageRentPriceToWeekly();

            return new GetAvarageRentPriceToWeeklyQueryResult
            {
                AvgRentPriceToWeekly = value
            };
        }
    }
}
