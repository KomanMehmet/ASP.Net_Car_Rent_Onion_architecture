using CarRent.Domain.Entities;

namespace CarRent.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeaturesByCarId(int id);

        void ChangeCarFeatureAvailableToFalse(int id);

        void ChangeCarFeatureAvailableToTrue(int id);

        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
