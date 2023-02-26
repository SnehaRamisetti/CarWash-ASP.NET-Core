using CaseStudyOnCarWash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public class AdminRepo : IAdmin
    {
        private readonly CarDbcontext _cardb;


        public AdminRepo(CarDbcontext cardb)
        {

            _cardb = cardb;

        }
        public async Task<Admin> AddAdmin(Admin admin)
        {
            try
            {
                var addadmin= _cardb.Admins.Add(admin);
                await _cardb.SaveChangesAsync();
                return (admin);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAdmin(int id)
        {
            try
            {
                var cust = await _cardb.Admins.FindAsync(id);
                _cardb.Admins.Remove(cust);
                await _cardb.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Admin> GetAdminById(int id)
        {
            try
            {
                var admin = await _cardb.Admins.FindAsync(id);
                return admin;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Admin>> GetAllAdminDetails()
        {
            try
            {
                var admins = await _cardb.Admins.ToListAsync();
                return admins;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Admin> Login(Login adminObj)
        {
            try
            {
                var user = await _cardb.Admins.FirstOrDefaultAsync(x => x.Email == adminObj.Email && x.Password == adminObj.Password);
                return user;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Admin> UpdateAdmin(int id, Admin admin)
        {
            try
            {
                var update = await _cardb.Admins.FindAsync(id);
                if (update != null)
                {
                     
                    update.Email = admin.Email;
                    update.Password = admin.Password;
                    
                    await _cardb.SaveChangesAsync();
                }
                return update;
            }
            catch
            {
                throw;
            }
        }
        
    }
}
