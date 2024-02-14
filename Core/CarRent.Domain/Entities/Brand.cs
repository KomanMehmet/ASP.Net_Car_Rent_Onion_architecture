using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string Name { get; set; }

        public List<Car> Cars { get; set; }
    }
}
