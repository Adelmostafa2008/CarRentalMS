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
    public class BranchRepo : GenericRepo<Branch>, IBranchRepo
    {
        public BranchRepo(AppDb _db) : base(_db)
        {
        }

        public async Task<IList<Branch>> GetAllBranches()
        {
            return await _db.branch.Include(x => x.cars).ThenInclude(x => x.rentalTransactions).OrderByDescending(x => x.cars.Sum(x => x.rentalTransactions.Count)).ToListAsync();
        }
    }
}