using CarRent.Domain.Entities;

namespace CarRent.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int CarFeatureID { get; set; }

        public int FeatureID { get; set; }

        public string FeatureName { get; set; }

        public bool Avaliable { get; set; }
    }
}
