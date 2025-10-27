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
    public class CusProRepo : GenericRepo<CustomerProfile>, ICusProRepo
    {
        public CusProRepo(AppDb _db) : base(_db)
        {
        }

        public async Task<IList<CustomerProfile>> GetCusAndPro()
        {
            return await _db.customerProfile.Include(x => x.customer).ToListAsync();
        }

        public async Task<CustomerProfile> GetProById(int id)
        {
            return await _db.customerProfile.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerProfile> GetProByLNum(string Num)
        {
            return await _db.customerProfile.FirstOrDefaultAsync(x => x.LicenseNumber == Num);
        }
    }
}