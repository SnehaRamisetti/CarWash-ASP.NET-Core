using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.Models
{
    public class CustomerTable : DbContext
    {
        public CustomerTable(DbContextOptions<CustomerTable> options): base(options)
        {

        }
         public DbSet<Customer> Customers { get; set; }
    }
}
