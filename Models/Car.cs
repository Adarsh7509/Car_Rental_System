using System;
using System.Collections.Generic;

namespace Car_Rental_System.Models
{
    public partial class Car
    {
        public Car()
        {
            CarImages = new HashSet<CarImage>();
            CarSpecifications = new HashSet<CarSpecification>();
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? Year { get; set; }
        public string Location { get; set; } = null!;
        public decimal PricePerDay { get; set; }
        public string? AvailabilityStatus { get; set; }

        public virtual ICollection<CarImage> CarImages { get; set; }
        public virtual ICollection<CarSpecification> CarSpecifications { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
