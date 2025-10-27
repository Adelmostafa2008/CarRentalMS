using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.DTOs
{
    public class ReadCustomerBasicDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }

    public class CreateCustomerDTO
    {
        public ReadCustomerBasicDTO cus { get; set; }
        public CreateProForCus Pro { get; set; }
    }
    public class ReadCustomerDetaildDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalRentalTransactions { get; set; }
        public CreateProForCus? profile { get; set; }
    }
    public class UpdateCustomerDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }

     public class ReadCustomerDetailsdDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalRentalTransactions { get; set; }
    }
}