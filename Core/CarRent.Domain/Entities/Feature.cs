using System.ComponentModel.DataAnnotations;

namespace CarRent.Domain.Entities
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }

        public string Name { get; set; }

        public List<CarFeature> CarFeatures { get; set; }
    }
}
