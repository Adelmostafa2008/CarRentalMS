using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Models
{
    [Index(nameof(Name) , IsUnique = true)]
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public IList<Car> ? cars { get; set; }
    }
}

