using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Models
{
    public class PackageDetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public string status { get; set; }
        
    }
}
