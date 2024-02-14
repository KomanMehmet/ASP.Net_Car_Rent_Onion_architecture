
using CarRent.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarRent.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery: IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
