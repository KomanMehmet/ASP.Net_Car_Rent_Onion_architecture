using CarRent.Domain.Entities;

namespace CarRent.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        public List<Review> GetReviewsByCarID(int carID);
    }
}
