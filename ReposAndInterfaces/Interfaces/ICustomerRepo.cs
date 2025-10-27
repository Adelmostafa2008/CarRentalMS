using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        Task<Customer> GetCusById(int id);
        Task<Customer> GetCusByEmail(string mail);
        Task CreateCusWithPro(Customer cus, CustomerProfile pro);
        Task<IList<Customer>> GetCustomers();
        Task<IList<Customer>> GetActiveCustomers();

    }
}