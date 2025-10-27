using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Models;
using Car_Rental_Management_System.ReposAndInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.ReposAndInterfaces
{
    public class RentRepo : GenericRepo<RentalTransaction>, IRentRepo
    {
        public RentRepo(AppDb _db) : base(_db)
        {
        }

        public async Task<IList<RentalTransaction>> GetActiveTransactions()
        {
            return await _db.rentalTransaction.Include(x => x.car).ThenInclude(x => x.branch).Where(x => x.Status == "Active").ToListAsync();
        }

        public async Task<IList<RentalTransaction>> GetAllTransactions()
        {
            var res =  await _db.rentalTransaction.Include(x => x.car).ThenInclude(x => x.branch).ToListAsync();

            return res;
        }

        public async Task<RentalTransaction> GetTransactionById(int id)
        {
            return await _db.rentalTransaction.Include(x => x.car).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}