using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface IBranchRepo : IGenericRepo<Branch>
    {
        Task<IList<Branch>> GetAllBranches();
    }
}