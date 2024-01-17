using _2FAtoLogin.Data;
using _2FAtoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _2FAtoLogin.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<User> GetUser(string username, string password)
        {
            var fromdb =  _repo.SingleOrDefault(u => username == u.UserName && password == u.Password);
            if(fromdb == null)
            {
                throw new Exception("User not found");
            }
            return fromdb;
        }
    }
}