using CaseStudyOnCarWash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
     public interface ICar
    {
        Task<List<Car>> GetAllCarDetails();

        Task<Car> GetCarById(int id);

        Task<Car> AddCar(Car Car);

        Task<Car> UpdateCar(int id, Car Car);

        Task DeleteCar(int id);
    }
}
