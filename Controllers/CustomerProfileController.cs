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
    public class CustomerProfileController : ControllerBase
    {
        private readonly ICusProRepo _cpr;
        private readonly ICustomerRepo _cr;
        public CustomerProfileController(ICusProRepo cpr, ICustomerRepo cr)
        {
            _cpr = cpr;
            _cr = cr;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePro([FromBody] CreateCustomerProfileDTO profile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var cus = await _cr.GetCusById(profile.CusId);

            if (cus == null) return NotFound("Invalid Customer Id");

            if (cus.customerProfile != null) return BadRequest("Profile already assigned");

            var pro = new CustomerProfile
            {
                Address = profile.Address,
                LicenseExpiry = profile.LicenseExpiry,
                LicenseNumber = profile.LicenseNumber,
                customer = cus,
                CustomerId = cus.Id,
            };

            await _cpr.Create(pro);

            return Ok("Done!");
        }

        [HttpGet]
        public async Task<IActionResult> GetCusWithPro()
        {
            var res = await _cpr.GetCusAndPro();

            if (!res.Any()) return NotFound("No Profiles Found");

            var Vres = res.Select(x => new ReadProWithCusDTO
            {
                Address = x.Address,
                LicenseExpiry = x.LicenseExpiry,
                LicenseNumber = x.LicenseNumber,
                customer = x.customer != null ?new ReadCustomerBasicDTO
                {
                    Name = x.customer.Name,
                    Email = x.customer.Email,
                    Phone = x.customer.Phone,
                } : null,

            }).ToList();

            return Ok(Vres);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] int id , [FromBody] UpdateProfileDTO pro)
        {
            var profile = await _cpr.GetProById(id);

            if (profile == null) return NotFound("Invalid ID");

            profile.Id = id;
            profile.Address = pro.Address;
            profile.LicenseExpiry = pro.LicenseExpiry;

            await _cpr.Update(profile);

            return Ok("Done!");
        }
    }
}