using AutoMapper;
using CrudUsingNetCore.Models;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.Services
{
        
    public class CustomerRepository : ICustomer
    {   
        private readonly CustomerTable _cust;
         

        public CustomerRepository(CustomerTable cust )
        {

            _cust = cust;
             
        }
       

        public  async Task<List<Customer>> GetAll()
        { 
            var cust= await _cust.Customers.ToListAsync();
            return cust;
        }


        public async Task<Customer> GetById(Guid id)
        {
            var cust = await _cust.Customers.FindAsync(id);
            return cust;
        }

        public async Task<Customer> Add(Customer customer)
        {
           var cust= _cust.Customers.Add(customer);
           await _cust.SaveChangesAsync();
            return (customer);
        }

         

       //To update the existing customer details
       public async Task Update(Guid id,Customer customer)
        {
            var cust= await _cust.Customers.FindAsync(id);
            if(cust!=null)
            {
                cust.Name = customer.Name;
                cust.City = customer.City;
                cust.IsActive = customer.IsActive;
                await _cust.SaveChangesAsync();
            }
        }

        //To delete the customer details
        public async Task Delete(Guid id)
        {
            var cust = await _cust.Customers.FindAsync(id);
            _cust.Customers.Remove(cust);
            await _cust.SaveChangesAsync();
        }
           
          
    }
}
