using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public string ModelName { get; set; }

        public string Status { get; set; }
        



    }
}
