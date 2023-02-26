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
    public class PackageController : ControllerBase
    {
        private readonly IPackage _IPackage;


        public PackageController(IPackage IPackage)
        {
            _IPackage = IPackage;

        }


        //Get method to retrive all the package details
        #region
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPackage()
        {

            var Packages = await _IPackage.GetAllPackageDetails();
            if (Packages == null)
            {
                return NotFound();
            }

            return Ok(Packages);
        }
        #endregion
        //Get the package details using id
        #region
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPackageById(int id)
        {
            var Package = await _IPackage.GetPackageById(id);
            if (Package == null)
            {
                return NotFound();
            }

            return Ok(Package);
        }
        #endregion

        //To add the  Package details
        #region
        [HttpPost]
        public async Task<IActionResult> Register(PackageDetails Package)
        {
            if (Package == null)
            {
                return BadRequest();
            }
            var add = await _IPackage.AddPackage(Package);
            return Ok(new
            {
                Message = " Added Package details successfully"
            });
            
        }
        #endregion



        //To update the details of existing  package
        #region
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, PackageDetails Package)
        {
            var Packages = await _IPackage.UpdatePackage(id, Package);
            return CreatedAtAction(nameof(GetPackageById), new { id = Packages.Id }, Packages);
        }
        #endregion
        //To delete the package  Details
        #region
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePackage(int id)
        {
            await _IPackage.DeletePackage(id);
            return Ok(new
            {
                Message = "Deleted Package Details successfully"
            });
        }
        #endregion
    }
}
