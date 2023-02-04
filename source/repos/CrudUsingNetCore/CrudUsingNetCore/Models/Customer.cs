using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudUsingNetCore.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string?  Gender { get; set; }

        [Required]
        public string  City { get; set; }
       
        public int IsActive { get; set; }

    }
}
