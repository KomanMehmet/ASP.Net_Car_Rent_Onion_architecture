using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetBrandAndModelByRentPriceDailyMinQuery, GetBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandAndModelByRentPriceDailyMin();

            return new GetBrandAndModelByRentPriceDailyMinQueryResult
            {
                BrandAndModelByRentPriceDailyMin = value
            };
        }
    }
}
