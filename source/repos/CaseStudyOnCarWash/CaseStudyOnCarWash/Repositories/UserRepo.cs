using CaseStudyOnCarWash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    //This class is the implementation of User Interface
    public class UserRepo : IUser
    {
        private readonly CarDbcontext _cardb;

        //constructor injection
        public  UserRepo(CarDbcontext cardb)
        {

            _cardb = cardb;

        }
        //This Method is to Add the new User
        #region
        public async Task<User> AddUser(User user)
        {
            try
            {
                var adduser = _cardb.Users.Add(user);
                await _cardb.SaveChangesAsync();
                return (user);
            }
            catch
            {
                throw;
            }
           
        }
        #endregion
        //This Method is to Delete the existing User Details
        #region
        public async Task DeleteUser(int id)
        {
            try
            {
                var cust = await _cardb.Users.FindAsync(id);
                _cardb.Users.Remove(cust);
                await _cardb.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        #endregion
        //This Method is to Get All the User Details
        #region
        public async Task<List<User>> GetAllUserDetails()
        {
            try
            {
                var users = await _cardb.Users.ToListAsync();
                return users;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        //This Method is to Get the user details using "Email" property
        #region
        public  User GetUserByEmail(string Email)
        {
            try
            {
                var user = _cardb.Users.FirstOrDefault(Q => Q.Email == Email);
                return user;
            }
            catch
            {
                throw;
            }
            
        }
        #endregion

        //This Method is to Get the user details using "Id" property
        #region
        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _cardb.Users.FindAsync(id);
                return user;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        //This Method is to Update the Existing Userdetails
        #region
        public async Task<User> UpdateUser(int id, User user)
        {
            try
            {
                var update = await _cardb.Users.FindAsync(id);
                if (update != null)
                {
                    update.FirstName = user.FirstName;
                    update.LastName = user.LastName;
                    update.PhoneNumber = user.PhoneNumber;
                    update.Email = user.Email;
                    update.Password = user.Password;
                    update.Role = user.Role;
                    update.IsActive = user.IsActive;
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
        public async Task<User> Login(UserLogin userObj)
        {
            try
            {
                var user = await _cardb.Users.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);
                return user;
            }
            catch
            {
                throw;
            }
        }
    }
}
