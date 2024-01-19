using _2FAtoLogin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Models
{
    public class JwtToken
    {
        public string Scheme { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public ProductRole[] Roles { get; set; }

        public bool IsConfigurator { get; set; }
    }
}