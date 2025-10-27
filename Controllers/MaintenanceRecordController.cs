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
    public class MaintenanceRecordController : ControllerBase
    {
        private readonly IMaintenanceRepo _mr;
        private readonly ICarRepo _cr;
        public MaintenanceRecordController(IMaintenanceRepo mr , ICarRepo cr)
        {
            _mr = mr;
            _cr = cr;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceRecord([FromBody] CreateMaintenanceDTO main)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var car = await _cr.GetCarById(main.CarId);

            if (car == null) return BadRequest("Inavalid Id");

            var record = new MaintenanceRecord
            {
                Cost = main.Cost,
                car = car,
                CarId = car.Id,
                Date = main.Date,
                Description = main.Description,
            };

            car.Status = "Maintenance";

            await _mr.Create(record);

            return Ok("Done!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecords()
        {
            var res = await _mr.GetAllRecords();

            if (!res.Any()) return BadRequest("No Maintainance Records Found ");

            var Vres = res.GroupBy(x => x.car.Brand).Select(x => new ReadMaintenanceDTO
            {
                CarBrand = x.Key,
                CarCount = x.Count(),
                MaintenanceCost = x.Sum(x => x.Cost),
                Cars = x.Select(x => new ReadCarMaintenanceDTO
                {
                    CarModel = x.car.Model,
                    MaintenanceCost = x.Cost,
                }).ToList(),
            }).ToList();

            return Ok(Vres);
        }

        [HttpGet("highValues")]
        public async Task<IActionResult> HighValueRecords([FromQuery] decimal Cost)
        {
            var res = await _mr.HighValueRecords(Cost);

            if (!res.Any()) return BadRequest($"No Records Found With This Cost {Cost}");

            var Vres = res.Select(x => new ReadHighMaintenanceDTO
            {
                Description = x.Description,
                Date = x.Date,
                Cars = new ReadCarMaintenanceDTO
                {
                    CarModel = x.car.Model,
                    MaintenanceCost = x.Cost,

                },

            }).ToList();

            return Ok(Vres);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            var res = await _mr.GetRecordById(id);

            if (res == null) return BadRequest("Invalid Id");

            var date = DateTime.Now.AddDays(-30);

            if (res.Date < date)
            {
                res.car.Status = "Available";
                
                await _mr.Delete(res);

                return Ok("Done!");
            }

            return BadRequest("The record is new");
        }
    }
}