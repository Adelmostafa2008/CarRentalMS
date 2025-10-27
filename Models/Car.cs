using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Models
{
    [Index(nameof(PlateNumber), IsUnique = true)]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string Status { get; set; } = "Available";
        [Required, Range(1, int.MaxValue)]
        public decimal DailyRate { get; set; }
        public IList<RentalTransaction>? rentalTransactions { get; set; }
        public IList<MaintenanceRecord>? MaintenanceRecord { get; set; }
        public int? BranchId { get; set; }
        public Branch ? branch { get; set; }
    }
    
}

