using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Domain.Entities
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string ImageUrl { get; set; }
    }
}
