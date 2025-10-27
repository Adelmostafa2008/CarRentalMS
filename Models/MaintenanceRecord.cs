using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Cost { get; set; } 
        public int? CarId { get; set; }
        public Car ? car { get; set; }
    }
} 

