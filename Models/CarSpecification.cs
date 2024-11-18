using System;
using System.Collections.Generic;

namespace Car_Rental_System.Models
{
    public partial class CarSpecification
    {
        public int SpecificationId { get; set; }
        public int CarId { get; set; }
        public string Specification { get; set; } = null!;

        public virtual Car? Car { get; set; }
    }
}
