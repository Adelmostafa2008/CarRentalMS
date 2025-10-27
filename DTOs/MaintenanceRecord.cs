using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.DTOs
{
    public class CreateMaintenanceDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Cost { get; set; }
        public int CarId { get; set; }
    }

    public class ReadMaintenanceDTO
    {
        public string CarBrand { get; set; }
        public int CarCount { get; set; }
        public decimal MaintenanceCost { get; set; }
        public IList<ReadCarMaintenanceDTO>? Cars { get; set; }
    }
    
    public class ReadHighMaintenanceDTO
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ReadCarMaintenanceDTO ? Cars { get; set; }
    }
}