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
    public class CarRepo : GenericRepo<Car>, ICarRepo
    {
        public CarRepo(AppDb _db) : base(_db)
        {
        }

        public async Task<IList<Car>> GetAllCars()
        {
            return await _db.car.Include(x => x.branch).ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _db.car.Include(x => x.rentalTransactions).Include(x => x.MaintenanceRecord).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> GetCarByPlate(string plate)
        {
            return await _db.car.FirstOrDefaultAsync(x => x.PlateNumber == plate);
        }

        public async Task<IList<Car>> GetCarsByBranchName(string branch)
        {
            return await _db.car.Include(c => c.branch).Where(x => x.branch.Name == branch).ToListAsync();
        }
    }
}