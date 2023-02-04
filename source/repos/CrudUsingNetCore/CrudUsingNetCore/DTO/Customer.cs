using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingNetCore.DTO
{
    public class Customer
    {
        public Guid Id { get; set; }

         
        public string CustomerName  { get; set; }

        public string? Gender { get; set; }

         
        public string CustomerCity { get; set; }

        public int IsActive { get; set; }
    }
}
