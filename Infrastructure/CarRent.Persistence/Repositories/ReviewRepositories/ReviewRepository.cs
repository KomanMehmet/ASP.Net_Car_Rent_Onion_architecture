using CarRent.Application.Interfaces.ReviewInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;

namespace CarRent.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarRentContext _context;

        public ReviewRepository(CarRentContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByCarID(int carID)
        {
            var values = _context.Reviews.Where(x => x.CarID == carID).ToList();

            return values;
        }
    }
}
