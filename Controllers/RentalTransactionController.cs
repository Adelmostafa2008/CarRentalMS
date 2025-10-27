using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.DTOs;
using Car_Rental_Management_System.Models;
using Car_Rental_Management_System.ReposAndInterfaces.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalTransactionController : ControllerBase
    {
        private readonly IRentRepo _rr;
        private readonly ICarRepo _c;
        private readonly ICustomerRepo _cr;
        public RentalTransactionController(IRentRepo rr , ICarRepo c , ICustomerRepo cr)
        {
            _rr = rr;
            _cr = cr;
            _c = c;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreatTransactionDTO trans)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var car = await _c.GetById(trans.CarId);
            var cus = await _cr.GetById(trans.CusId);

            if (cus == null || car == null) return BadRequest("Car or Customer Id is Invalid");

            car.Status = "Rented";

            var transaction = new RentalTransaction
            {
                car = car,
                CarId = car.Id,
                customer = cus,
                CustomerId = cus.Id,
                EndDate = trans.EndDate,
                StartDate = trans.StartDate, 
            };

            await _rr.Create(transaction);

            return Ok("Done!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var res = await _rr.GetAllTransactions();

            if (!res.Any()) return BadRequest("No Transactions found");

            var Vres = res.GroupBy(x => x.car.branch.City).Select(x => new ReadTransacionsDTO
            {
                BranchName = x.Key,
                TransactionsCount = x.Count(),
                TotalIncome = x.Sum(x => x.TotalCost),
                AvgRentalDuration = (int)x.Average(x => (x.EndDate - x.StartDate).TotalDays)
            }).ToList();

            return Ok(Vres);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveTransactions()
        {
            var res = await _rr.GetActiveTransactions();

            if (!res.Any()) return BadRequest("No Transactions found");

            var Vres = res.Select(x => new ReadTransacionsDetailsDTO
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
            }).ToList();

            return Ok(Vres);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromRoute] int id , [FromBody] UpdateTransactionDTO tr)
        {
            var res = await _rr.GetTransactionById(id);

            if (res == null) return NotFound("Invalid Id");

            res.Id = id;
            res.Status = tr.status;
            res.car.Status = "Available";

            await _rr.Update(res);

            return Ok("Done!"); 

        }
    }
}