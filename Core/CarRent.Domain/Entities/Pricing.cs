using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entities
{
    public class Pricing
    {
        [Key]
        public int PricingID { get; set; }

        public string Name { get; set; }

        public List<CarPricing> CarPricings { get; set; }
    }
}
