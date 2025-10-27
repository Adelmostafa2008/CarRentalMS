using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface IRentRepo : IGenericRepo<RentalTransaction>
    {
        Task<IList<RentalTransaction>> GetAllTransactions();
        Task<IList<RentalTransaction>> GetActiveTransactions();
        Task<RentalTransaction> GetTransactionById(int id);
    }
}