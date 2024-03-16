using CarRent.Application.Features.Mediator.Results.RentACarResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationID { get; set; }

        public bool Available { get; set; }
    }
}
