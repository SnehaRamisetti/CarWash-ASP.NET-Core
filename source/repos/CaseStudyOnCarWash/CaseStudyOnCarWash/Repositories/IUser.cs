using CaseStudyOnCarWash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyOnCarWash.Repositories
{
    public interface IUser
    {

        Task<List<User>> GetAllUserDetails();

        Task<User> GetUserById(int id);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(int id, User user);

        Task DeleteUser(int id);
        User GetUserByEmail(string Email);

        Task<User> Login(UserLogin userObj);
    }
}
