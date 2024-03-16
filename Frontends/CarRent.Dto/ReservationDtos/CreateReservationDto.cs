﻿namespace CarRent.Dto.ReservationDtos
{
    public class CreateReservationDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumer { get; set; }

        public int PickUpLocationID { get; set; }

        public int DropOffLocationID { get; set; }

        public int CarID { get; set; }

        public int Age { get; set; }

        public int DriverLicenseYear { get; set; }

        public string Description { get; set; }
    }
}
