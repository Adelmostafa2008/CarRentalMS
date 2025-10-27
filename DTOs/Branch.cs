using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental_Management_System.DTOs
{
    public class CreateBranchDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
    }

    public class ReadBranchDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int TotalCars { get; set; }
        public int Capacity { get; set; }
    }
}