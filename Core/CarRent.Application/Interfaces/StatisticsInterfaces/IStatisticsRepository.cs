namespace CarRent.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();

        int GetLocationCount();

        int GetAuthorCount();

        int GetBlogCount();

        int GetBrandCount();

        decimal GetAvarageRentPriceToDaily();

        decimal GetAvarageRentPriceToWeekly();

        decimal GetAvarageRentPriceToMountly();

        int GetCarCountByTransmisionIsAuto();

        string GetBrandNameByMaxCar();

        string GetBlogTitleByMaxBlogComment();

        int GetCarCountByKmLessThan1000();

        int GetCarCountByFuelGasOrDiesel();

        int GetCarCountByFuelElectric();

        string GetBrandAndModelByRentPriceDailyMax();

        string GetBrandAndModelByRentPriceDailyMin();
    }
}
