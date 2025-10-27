using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.DTOs
{
    public class ReadCarDTO
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public IList<CarDetDTO> ?Cars { get; set; }
    }

    public class CarDetDTO
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string PlateNumber { get; set; }
        public decimal DailyRate { get; set; }
    }

    public class CreateCarDTO
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string PlateNumber { get; set; }
        public string Status { get; set; }
        public decimal DailyRate { get; set; }
    }

    public class UpdateCarDTO
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string PlateNumber { get; set; }
        public string Status { get; set; }
        public decimal DailyRate { get; set; }
    }
    
    public class ReadCarMaintenanceDTO
    {
        public string CarModel { get; set; }
        public decimal MaintenanceCost { get; set; }
    }
}