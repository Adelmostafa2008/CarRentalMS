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
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        private readonly ICusProRepo _cpr;
        public CustomerRepo(AppDb _db , ICusProRepo cpr) : base(_db)
        {
            _cpr = cpr;
        }

        public async Task CreateCusWithPro(Customer cus, CustomerProfile pro)
        {
            await Create(cus);

            pro.customer = cus;
            pro.CustomerId = cus.Id;

            await _cpr.Create(pro);
        }

        public async Task<IList<Customer>> GetActiveCustomers()
        {
            return await _db.customer.Include(c => c.rentalTransactions).Where(x => x.rentalTransactions.Any(x => x.Status == "Active")).ToListAsync();
        }

        public async Task<Customer> GetCusByEmail(string mail)
        {
            return await _db.customer.FirstOrDefaultAsync(x => x.Email == mail);
        }

        public async Task<Customer> GetCusById(int id)
        {
            return await _db.customer.Include(x => x.customerProfile).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            return await _db.customer.Include(x => x.customerProfile).Include(x => x.rentalTransactions).ToListAsync();
        }
    }
}