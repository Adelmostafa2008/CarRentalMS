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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _cr;
        private readonly ICusProRepo _cpr;
        public CustomerController(ICustomerRepo cr , ICusProRepo cpr)
        {
            _cr = cr;
            _cpr = cpr;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCus([FromBody] CreateCustomerDTO cus)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var email = await _cr.GetCusByEmail(cus.cus.Email);

            if (email != null) return BadRequest("Email already Exists");

            var Lnum = await _cpr.GetProByLNum(cus.Pro.LicenseNumber);

            if (Lnum != null) return BadRequest("License number already exists");

            var customer = new Customer
            {
                Name = cus.cus.Name,
                Email = cus.cus.Email,
                Phone = cus.cus.Phone,
            };

            var profile = new CustomerProfile
            {
                Address = cus.Pro.Address,
                LicenseNumber = cus.Pro.LicenseNumber,
                LicenseExpiry = cus.Pro.LicenseExpiry,
            };



            await _cr.CreateCusWithPro(customer, profile);

            return Ok("Done!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCus()
        {
            var customers = await _cr.GetCustomers();

            if (!customers.Any()) return BadRequest("No Customers found");

            var Vres = customers.Select(x => new ReadCustomerDetaildDTO
            {
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                TotalRentalTransactions = x.rentalTransactions.Any() ? x.rentalTransactions.Count : 0,
                profile = x.customerProfile != null ? new CreateProForCus
                {
                    Address = x.customerProfile.Address,
                    LicenseExpiry = x.customerProfile.LicenseExpiry,
                    LicenseNumber = x.customerProfile.LicenseNumber,
                } : null
            }).ToList();

            return Ok(Vres);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCus([FromRoute] int id, [FromBody] UpdateCustomerDTO cus)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customer = await _cr.GetCusById(id);

            if (customer == null) return BadRequest("Invalid Id");

            var mail = await _cr.GetCusByEmail(cus.Email);

            if (mail != null) return BadRequest("Email already exsists");

            customer.Id = id;
            customer.Name = cus.Name;
            customer.Phone = cus.Phone;
            customer.Email = cus.Email;

            await _cr.Update(customer);

            return Ok("Done!");
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCus()
        {
            var customers = await _cr.GetActiveCustomers();

            if (!customers.Any()) return NotFound("No customers found");

            var Vres = customers.Select(x => new ReadCustomerDetailsdDTO
            {
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                TotalRentalTransactions = x.rentalTransactions.Count,

            }).ToList();

            return Ok(Vres);
        }

        
    }
}