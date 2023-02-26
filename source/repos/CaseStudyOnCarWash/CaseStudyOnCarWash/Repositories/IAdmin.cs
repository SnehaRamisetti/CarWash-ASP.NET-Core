using CaseStudyOnCarWash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
     public interface IAdmin
    {
        Task<List<Admin>> GetAllAdminDetails();

        Task<Admin> GetAdminById(int id);

        Task<Admin> AddAdmin(Admin admin);

        Task<Admin> UpdateAdmin(int id, Admin admin);

        Task DeleteAdmin(int id);
        Task<Admin> Login(Login adminObj);
    }
}
