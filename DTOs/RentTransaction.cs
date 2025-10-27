using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Car_Rental_Management_System.DTOs
{
    public class CreatTransactionDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int CusId { get; set; }
        public int CarId { get; set; }
    }
    public class ReadTransacionsDTO
    {
        public string BranchName { get; set; }
        public int TransactionsCount { get; set; }
        public decimal TotalIncome { get; set; }
        public int AvgRentalDuration { get; set; }
    }

    public class ReadTransacionsDetailsDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }

    public class UpdateTransactionDTO
    {
        public string status { get; set; }
    }
}