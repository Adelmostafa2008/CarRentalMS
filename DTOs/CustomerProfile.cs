using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.DTOs
{
    public class CreateCustomerProfileDTO
    {
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public DateTime LicenseExpiry { get; set; }
        public int CusId { get; set; }
    }

    public class ReadProWithCusDTO
    {
        public string Address { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiry { get; set; }
        public ReadCustomerBasicDTO ?customer { get; set; }
    }

    public class UpdateProfileDTO
    {
        public string Address { get; set; }
        public DateTime LicenseExpiry { get; set; }
    }
    public class CreateProForCus
    {
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public DateTime LicenseExpiry { get; set; }
    }
}