using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage ="PhoneNumber can not be empty")]
        

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email can not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public  string Password { get; set; }
        [Required]
        [RegularExpression(@"Customer|Washer")]
        public string Role { get; set; }
        [Required]
        [RegularExpression(@"Active| InActive")]
        public string IsActive { get; set; }
        
    }
}
