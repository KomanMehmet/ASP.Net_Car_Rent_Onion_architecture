using CarRent.Application.Interfaces.CarFeatureInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.CarFeatureRepositores
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarRentContext _context;

        public CarFeatureRepository(CarRentContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();

            values.Avaliable = false;

            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values =  _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();

            values.Avaliable = true;

            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);

            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByCarId(int id)
        {
            var values = _context.CarFeatures.Include(x => x.Feature).Where(y => y.CarID == id).ToList();

            return values;
        }
    }
}
