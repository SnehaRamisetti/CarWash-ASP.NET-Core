using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
    }
}
