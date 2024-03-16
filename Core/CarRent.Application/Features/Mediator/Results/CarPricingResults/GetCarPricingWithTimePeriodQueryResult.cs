namespace CarRent.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithTimePeriodQueryResult
	{
        public string Model { get; set; }

        public decimal AmountDaily { get; set; }

        public decimal AmountWeekly { get; set; }

        public decimal AmountMountly { get; set; }

		public string BrandName { get; set; }

		public string CoverImageUrl { get; set; }
	}
}
