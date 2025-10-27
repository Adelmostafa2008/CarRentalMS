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
    public class MaintenanceRepo : GenericRepo<MaintenanceRecord>, IMaintenanceRepo
    {
        public MaintenanceRepo(AppDb _db) : base(_db)
        {
        }

        public async Task<IList<MaintenanceRecord>> GetAllRecords()
        {
            return await _db.maintenanceRecord.Include(x => x.car).ToListAsync();
        }

        public async Task<MaintenanceRecord> GetRecordById(int id)
        {
            return await _db.maintenanceRecord.Include(x => x.car).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<MaintenanceRecord>> HighValueRecords(decimal cost)
        {
            return await _db.maintenanceRecord.Include(x => x.car).Where(x => x.Cost > cost).ToListAsync();
        }
    }
}