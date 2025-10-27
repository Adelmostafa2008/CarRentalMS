using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Models
{
    public class RentalTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public decimal TotalCost => (decimal)(EndDate - StartDate).Days * car.DailyRate;
        public string Status { get; set; } = "Active";
        public int? CarId { get; set; }
        public Car? car { get; set; }
        public int? CustomerId { get; set; }
        public Customer ? customer { get; set; }
    }
    
   

}

 