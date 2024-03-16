﻿using CarRent.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAvarageRentPriceToDailyQuery : IRequest<GetAvarageRentPriceToDailyQueryResult>
    {
    }
}
