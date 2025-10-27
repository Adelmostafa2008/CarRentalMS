using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface IMaintenanceRepo : IGenericRepo<MaintenanceRecord>
    {
        Task<IList<MaintenanceRecord>> GetAllRecords();
        Task<IList<MaintenanceRecord>> HighValueRecords(decimal cost);
        Task<MaintenanceRecord> GetRecordById(int id);
    }
}