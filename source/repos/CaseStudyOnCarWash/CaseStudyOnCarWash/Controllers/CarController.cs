using CaseStudyOnCarWash.Models;
using CaseStudyOnCarWash.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICar _ICar;


        public CarController(ICar ICar)
        {
            _ICar = ICar;

        }


        //Get method to retrive all the car details
        #region
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCar()
        {

            var Cars = await _ICar.GetAllCarDetails();
            if (Cars == null)
            {
                return NotFound();
            }

            return Ok(Cars);
        }
        #endregion
        //Get the car details using id
        #region
         
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var Car = await _ICar.GetCarById(id);
            if (Car == null)
            {
                return NotFound();
            }

            return Ok(Car);
        }
        #endregion



        //To add the Car
        #region
        [HttpPost]
        public async Task<IActionResult> AddCarDetails(Car Car)
        {
            if (Car == null)
            {
                return BadRequest();
            }
            var add = await _ICar.AddCar(Car);
            return Ok(new
            {
                Message ="Added Car Details successfully"
            });
            
        }
        #endregion



        //To update the details of existing  User
        #region
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car Car)
        {
            var Cars = await _ICar.UpdateCar(id, Car);
            return CreatedAtAction(nameof(GetCarById), new { id = Cars.CarId }, Cars);
        }
        #endregion
        //To delete the Customer Details
        #region
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _ICar.DeleteCar(id);
            return Ok(new
            {
                Message = "Deleted Car Details successfully"
            });
        }
        #endregion
    }
}
