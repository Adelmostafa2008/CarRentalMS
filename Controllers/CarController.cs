using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.DTOs;
using Car_Rental_Management_System.Models;
using Car_Rental_Management_System.ReposAndInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepo _cr;
        public CarController(ICarRepo cr)
        {
            _cr = cr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var res = await _cr.GetAllCars();

            if (!res.Any()) return NotFound("No Cars Found");

            var VRes = res.GroupBy(x => x.Status).Select(x => new ReadCarDTO
            {
                Status = x.Key,
                Count = x.Count(),
                Cars = x.Select(x => new CarDetDTO
                {
                    Brand = x.Brand,
                    DailyRate = x.DailyRate,
                    Model = x.Model,
                    PlateNumber = x.PlateNumber,

                }).ToList(),

            }).OrderByDescending(x => x.Count).ToList();

            return Ok(VRes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDTO car)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (car.DailyRate <= 0) return BadRequest("Invalid Daily Rate");

            var va = await _cr.GetCarByPlate(car.PlateNumber);

            if (va != null) return BadRequest("Plate Number Already Exists");

            var res = new Car
            {
                Model = car.Model,
                DailyRate = car.DailyRate,
                Brand = car.Brand,
                PlateNumber = car.PlateNumber,
                Status = car.Status,
            };

            await _cr.Create(res);

            return Ok("Done!");
        }

        [HttpGet("availableCar")]
        public async Task<IActionResult> GetAvailableCarsInBranch([FromQuery] string Branch)
        {
            var res = await _cr.GetCarsByBranchName(Branch);

            if (!res.Any()) return NotFound("No Cars Available At The Entered Branch");

            var Vres = res.Select(x => new CarDetDTO
            {
                Brand = x.Brand,
                DailyRate = x.DailyRate,
                Model = x.Model,
                PlateNumber = x.PlateNumber
            }).ToList();

            return Ok(Vres);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var res = await _cr.GetCarById(id);

            if (res == null) return NotFound("Invalid Id");

            if (!res.rentalTransactions.Any() && !res.MaintenanceRecord.Any()) { await _cr.Delete(res); return Ok("Done!"); }
            
            return BadRequest("Assigned to maintenance or rental records");

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id , [FromBody] UpdateCarDTO car)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _cr.GetById(id);

            if (res == null) return NotFound("Invalid Id");

            if (car.DailyRate <= 0) return BadRequest("Invalid Daily Rate");

            var va = await _cr.GetCarByPlate(car.PlateNumber);

            if (va != null) return BadRequest("Plate Number Already Exists");

            if (res.Status == "Rented") return BadRequest("the car is rented at the time you cant change the status");

            res.Id = id;
            res.Brand = car.Brand;
            res.DailyRate = car.DailyRate;
            res.Model = car.Model;
            res.Status = car.Status;
            res.PlateNumber = car.PlateNumber;
            

            await _cr.Update(res);

            return Ok("Done!");
        }
    }
}