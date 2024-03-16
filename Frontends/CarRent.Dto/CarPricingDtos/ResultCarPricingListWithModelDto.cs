namespace CarRent.Dto.CarPricingDtos
{
	public class ResultCarPricingListWithModelDto
	{
        public string Model { get; set; }

        public decimal AmountDaily { get; set; }

        public decimal AmountWeekly { get; set; }

        public decimal amountMountly { get; set; }

        public string CoverImageUrl { get; set; }

        public string BrandName { get; set; }
    }
}
