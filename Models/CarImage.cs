using System;
using System.Collections.Generic;

namespace Car_Rental_System.Models
{
    public partial class CarImage
    {
        public int ImageId { get; set; }
        public int? CarId { get; set; }
        public string ImageUrl { get; set; } = null!;

        public virtual Car? Car { get; set; }
    }
}
