using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Models
{
    public class JwtToken
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        
        public string Role { get; set; }
        
    }
}