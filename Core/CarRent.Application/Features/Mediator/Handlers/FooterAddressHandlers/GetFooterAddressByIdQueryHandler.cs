using CarRent.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarRent.Application.Features.Mediator.Results.FooterAddressResults;
using CarRent.Domain.Entities;
using MediatR;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            return new GetFooterAddressByIdQueryResult
            {
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber,
                FooterAddressID = values.FooterAddressID
            };
        }
    }
}
