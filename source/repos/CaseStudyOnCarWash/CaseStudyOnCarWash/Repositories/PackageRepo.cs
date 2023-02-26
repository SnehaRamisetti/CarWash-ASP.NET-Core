using CaseStudyOnCarWash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public class PackageRepo : IPackage
    {
        private readonly CarDbcontext _cardb;

        //constructor injection
        public PackageRepo(CarDbcontext cardb)
        {

            _cardb = cardb;

        }
        //This Method is to Add the new Package Details
        #region
        public async Task<PackageDetails> AddPackage(PackageDetails package)
        {
            try
            {
                var addpackage = _cardb.PackageDetails.Add(package);
                await _cardb.SaveChangesAsync();
                return (package);
            }
            catch
            {
                throw;
            }

        }
        #endregion
        //This Method is to Delete the existing Package Details
        #region
        public async Task DeletePackage(int id)
        {
            try
            {
                var package = await _cardb.PackageDetails.FindAsync(id);
                _cardb.PackageDetails.Remove(package);
                await _cardb.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        #endregion
        //This Method is to Get All the Package Details
        #region
        public async Task<List<PackageDetails>> GetAllPackageDetails()
        {
            try
            {
                var Packages = await _cardb.PackageDetails.ToListAsync();
                return Packages;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //This Method is to Update the Existing Packagedetails
        #region
        public async Task<PackageDetails> UpdatePackage(int id, PackageDetails package)
        {
            try
            {
                var update = await _cardb. PackageDetails.FindAsync(id);
                if (update != null)
                {
                    update.Name = package.Name;
                    update.Description = package.Description;
                    update.price = package.price;
                    update.status = package.status;


                    await _cardb.SaveChangesAsync();
                }
                return update;
            }
            catch
            {
                throw;
            }
        }
        #endregion


        //This Method is to Get the Package details using "Id" property
        #region
        public async Task<PackageDetails> GetPackageById(int id)
        {
            try
            {
                var package = await _cardb.PackageDetails.FindAsync(id);
                return package;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    
    }
}
