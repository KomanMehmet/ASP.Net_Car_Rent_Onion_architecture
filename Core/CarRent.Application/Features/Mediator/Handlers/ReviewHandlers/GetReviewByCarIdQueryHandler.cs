using CarRent.Application.Features.Mediator.Queries.ReviewQueries;
using CarRent.Application.Features.Mediator.Results.ReviewResults;
using CarRent.Application.Features.Mediator.Results.ServiceResults;
using CarRent.Application.Interfaces.ReviewInterfaces;
using MediatR;

namespace CarRent.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _reviewRepository.GetReviewsByCarID(request.Id);

            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                Comment = x.Comment,
                CarID = x.CarID,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaitingValue = x.RaitingValue,
                ReviewDate = x.ReviewDate,
                ReviewID = x.ReviewID
            }).ToList();
        }
    }
}
