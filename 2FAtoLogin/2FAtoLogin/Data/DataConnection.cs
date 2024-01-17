using _2FAtoLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Data
{
    public class DataConnection : DbContext, IDbContext
    {
        public DataConnection() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString) { }

        public DbSet<User> Users { get; set; }
    }
}