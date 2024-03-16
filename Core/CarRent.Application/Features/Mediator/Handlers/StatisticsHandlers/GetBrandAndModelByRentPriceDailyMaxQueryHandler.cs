using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetBrandAndModelByRentPriceDailyMaxQuery, GetBrandAndModelByRentPriceDailyMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandAndModelByRentPriceDailyMax();

            return new GetBrandAndModelByRentPriceDailyMaxQueryResult
            {
                BrandAndModelByRentPriceDailyMax = value
            };
        }
    }
}
