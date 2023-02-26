using CaseStudyOnCarWash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public class CarRepo : ICar
    {
        private readonly CarDbcontext _cardb;

        //constructor injection
        public CarRepo(CarDbcontext cardb)
        {

            _cardb = cardb;

        }
        //This Method is to Add the new Car Details
        #region
        public async Task<Car> AddCar(Car car)
        {
            try
            {
                var addCar = _cardb.Cars.Add(car);
                await _cardb.SaveChangesAsync();
                return (car);
            }
            catch
            {
                throw;
            }

        }
        #endregion
        //This Method is to Delete the existing Car Details
        #region
        public async Task DeleteCar(int id)
        {
            try
            {
                var car = await _cardb.Cars.FindAsync(id);
                _cardb.Cars.Remove(car);
                await _cardb.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        #endregion
        //This Method is to Get All the Car Details
        #region
        public async Task<List<Car>> GetAllCarDetails()
        {
            try
            {
                var Cars = await _cardb.Cars.ToListAsync();
                return Cars;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //This Method is to Update the Existing Userdetails
        #region
        public async Task<Car> UpdateCar(int id, Car car)
        {
            try
            {
                var update = await _cardb.Cars.FindAsync(id);
                if (update != null)
                {
                    update.ModelName = car.ModelName;
                    update.Status = car.Status;
                     
                     
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
       

        //This Method is to Get the Car details using "Id" property
        #region
        public async Task<Car> GetCarById(int id)
        {
            try
            {
                var car = await _cardb.Cars.FindAsync(id);
                return car;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    
    }
}
