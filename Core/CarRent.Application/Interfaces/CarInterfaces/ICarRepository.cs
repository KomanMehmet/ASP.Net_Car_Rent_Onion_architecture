using CarRent.Domain.Entities;


namespace CarRent.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrand();
        List<Car> GetLastFiveCarsWithBrands();
        
    }
}
