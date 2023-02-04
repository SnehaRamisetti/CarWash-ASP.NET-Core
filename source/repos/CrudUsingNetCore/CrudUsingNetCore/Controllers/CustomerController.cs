using AutoMapper;
using CrudUsingNetCore.Models;
using CrudUsingNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _Icustomer;
        private readonly IMapper _mapper;

        public CustomerController(ICustomer Icustomer,IMapper mapper)
        {
            _Icustomer = Icustomer;
            _mapper = mapper;
        }


        //Get method to retrive all the customer details
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
             
             var cust= await _Icustomer.GetAll();
            if(cust==null)
            {
                return NotFound(); 
            }
            var custDTO= _mapper.Map<List<DTO.Customer>>(cust);
            return Ok(custDTO);
        }

        //Get the customer details using id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var cust= await _Icustomer.GetById(id);
            if(cust==null)
            {
                return NotFound();
            }
            var custDTO = _mapper.Map<DTO.Customer>(cust);
            return Ok(custDTO);
        }


        //To add the customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
           var cust=await _Icustomer.Add(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = cust.Id }, cust);
        }



        //To update the details of existing  customer

        [HttpPut("{id}")]
        public async Task<IActionResult> updateCustomer(Guid id,Customer customer)
        {
            await _Icustomer.Update(id, customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }


        //To delete the Customer Details
        [HttpDelete]
        public  async Task<IActionResult> RemoveCustomer(Guid id)
        {
           await _Icustomer.Delete(id);
            return Ok();
        }


    }
}
