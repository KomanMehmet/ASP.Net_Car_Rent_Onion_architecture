namespace CarRent.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }

        public int LocationCount { get; set; }

        public int AuthorCount { get; set; }

        public int BlogCount { get; set; }

        public int BrandCount { get; set; }

        public decimal AvgPriceToDaily { get; set; }

        public decimal AvgRentPriceToWeekly { get; set; }

        public decimal AvgRentPriceToMountly { get; set; }

        public int CarCountByTransmissionIsAuto { get; set; }

        public int CarCountByKmLessThan1000 { get; set; }

        public int CarCountByFuelGasOrDiesel { get; set; }

        public int CarCountByFuelElectric { get; set; }

        public string BrandAndModelByRentPriceDailyMax { get; set; }

        public string BrandAndModelByRentPriceDailyMin { get; set; }

        public string BrandNameByMaxCar { get; set; }

        public string BlogTitleByMaxBlogComment { get; set; }
    }
}
