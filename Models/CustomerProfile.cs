using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Models
{
    [Index(nameof(LicenseNumber) , IsUnique = true)]
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public DateTime LicenseExpiry { get; set; }
        public int? CustomerId { get; set; }
        public Customer ? customer { get; set; }
    }
}

 