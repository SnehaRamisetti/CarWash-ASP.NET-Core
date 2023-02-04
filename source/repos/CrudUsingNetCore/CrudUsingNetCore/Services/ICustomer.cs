using CrudUsingNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.Services
{
    public interface ICustomer
    {


        Task<List<Customer>> GetAll();

        Task<Customer> GetById(Guid id);

        Task<Customer> Add(Customer customer);

        Task Update(Guid id, Customer customer);

        Task Delete(Guid id);
    }
}
