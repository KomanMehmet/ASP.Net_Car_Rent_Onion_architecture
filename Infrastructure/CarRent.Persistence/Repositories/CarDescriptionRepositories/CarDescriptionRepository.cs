using CarRent.Application.Interfaces.CarDescriptionInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarRentContext _context;

        public CarDescriptionRepository(CarRentContext context)
        {
            _context = context;
        }


        async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
        {
            var values = await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();

            return values;
        }
    }
}
