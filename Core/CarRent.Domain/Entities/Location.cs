using System.ComponentModel.DataAnnotations;

namespace CarRent.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        public string Name { get; set; }

        public List<RentACar> RentACars { get; set; }

        public List<Reservation> PickUpReservation { get; set; }

        public List<Reservation> DropOffReservation { get; set; }
    }
}
