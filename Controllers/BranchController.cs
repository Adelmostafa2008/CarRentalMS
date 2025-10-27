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
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo _br;
        public BranchController(IBranchRepo br)
        {
            _br = br;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDTO br)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = new Branch
            {
                Capacity = br.Capacity,
                City = br.City,
                Name = br.Name,
            };

            await _br.Create(res);

            return Ok("Done!");

        }

        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var res = await _br.GetAllBranches();

            var Vres = res.Select(x => new ReadBranchDTO
            {
                Name = x.Name,
                City = x.City,
                TotalCars = x.cars.Any() ? x.cars.Count : 0,
                Capacity = x.Capacity - (x.cars.Any() ? x.cars.Count : 0),

            }).ToList();

            return Ok(Vres);
        }
    }
}