using _2FAtoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2FAtoLogin.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string username, string password);

        Task<User> GetUserbyName(string username);

        Task<User> UpdateUser(User user);

        Task<User> AddUser(User user);

    }
}
