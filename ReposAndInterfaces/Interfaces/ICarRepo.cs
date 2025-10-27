using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;

namespace Car_Rental_Management_System.ReposAndInterfaces.Interfaces
{
    public interface ICarRepo : IGenericRepo<Car>
    {
        Task<IList<Car>> GetAllCars();
        Task<Car> GetCarByPlate(string plate);
        Task<IList<Car>> GetCarsByBranchName(string branch);
        Task<Car> GetCarById(int id);
    }
}