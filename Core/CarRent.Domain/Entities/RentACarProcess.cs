using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID { get; set; }

        public int CarID { get; set; }

        public Car Car { get; set; }

        public int PickUpLocation { get; set; }

        public int DropOffLocation { get; set; }

        [DataType(DataType.Date)]
        public TimeSpan PickUpDate { get; set; }

        [DataType(DataType.Date)]
        public TimeSpan DropOffDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan PickUpTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DropOffTime { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public string PickUpDescription { get; set; }

        public string DropOffDescription { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
