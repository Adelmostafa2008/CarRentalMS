using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public CustomerProfile? customerProfile { get; set; }
        public IList<RentalTransaction> ? rentalTransactions{ get; set; }
    }
}
 
