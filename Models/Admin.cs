using System;
using System.Collections.Generic;

namespace Car_Rental_System.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Role { get; set; }
    }
}
