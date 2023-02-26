using CaseStudyOnCarWash.Models;
using CaseStudyOnCarWash.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _IAdmin;


        public AdminController(IAdmin IAdmin)
        {
            _IAdmin = IAdmin;

        }


        //Get method to retrive all the customer details
        #region
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAdmin()
        {

            var admins = await _IAdmin.GetAllAdminDetails();
            if (admins == null)
            {
                return NotFound();
            }

            return Ok(admins);
        }
        #endregion
        //Get the customer details using id
        #region
        //Get the customer details using id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _IAdmin.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }
        #endregion
       


        //To add the User or for registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(Admin admin)
        {
            if (admin == null)
            {
                return BadRequest();
            }
            var add = await _IAdmin.AddAdmin(admin);
            return Ok(new
            {
                Message = "Admin Registered successfully"
            });
            //CreatedAtAction(nameof(GetUserById), new { id = add.Id }, add);
        }



        //To update the details of existing  User
        #region
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, Admin Admin)
        {
            var Users = await _IAdmin.UpdateAdmin(id, Admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = Users.Id }, Users);
        }
        #endregion
        //To delete the Customer Details
        #region
        [HttpDelete]
        public async Task<IActionResult> RemoveAdmin(int id)
        {
            await _IAdmin.DeleteAdmin(id);
            return Ok(new
            {
                Message = "Deleted Admin Details successfully"
            });
        }
        #endregion
        //This method is for authenticate the user
        #region
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login adminObj)
        {
            if (adminObj == null)
            {
                return BadRequest();

            }
            var u = await _IAdmin.Login(adminObj);
            if (u == null)
            {
                return NotFound(new { Message = "Admin not found" });
            }

            string Token = JwtCreation(u);



            //return Ok(Token);

            return Ok(new
            {
                Token,
                Message = "Admin LoggedIn successful!"
            }); ;
        }
        #endregion
        //Creating method for jwt token
        #region

        private string JwtCreation(Admin user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email,user.Email)
                 
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
        #endregion
    }
}
