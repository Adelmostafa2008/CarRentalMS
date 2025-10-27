using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface ICusProRepo : IGenericRepo<CustomerProfile>
    {
        Task<IList<CustomerProfile>> GetCusAndPro();
        Task<CustomerProfile> GetProById(int id);
        Task<CustomerProfile> GetProByLNum(string Num);
    }
}