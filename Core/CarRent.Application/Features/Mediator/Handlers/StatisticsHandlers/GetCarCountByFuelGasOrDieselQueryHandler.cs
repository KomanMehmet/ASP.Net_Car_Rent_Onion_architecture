using CarRent.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByFuelGasOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasOrDieselQuery, GetCarCountByFuelGasOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGasOrDieselQueryResult> Handle(GetCarCountByFuelGasOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasOrDiesel();

            return new GetCarCountByFuelGasOrDieselQueryResult
            {
                CarCountByFuelGasOrDiesel = value
            };
        }
    }
}
