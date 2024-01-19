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
        private readonly IDbContext _dbContext;

        public UserService(IUserRepository repo,IDbContext dbContext)
        {
            _repo = repo;
            _dbContext = dbContext;
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

        public async Task<User> GetUserbyName(string username)
        {
            var fromdb = _repo.SingleOrDefault(u => username == u.UserName);
            if (fromdb == null)
            {
                throw new Exception("User not found");
            }
            return fromdb;
        }

        public async Task<User> UpdateUser(User user)
        {
            _repo.Update(user);
            return user;
        }
        public async Task<User> AddUser(User user)
        {
            _repo.Add(user);

            return user;
        }
    }
}