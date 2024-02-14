using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
