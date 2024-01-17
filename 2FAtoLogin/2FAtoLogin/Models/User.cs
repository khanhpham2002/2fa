﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }
        
        public bool hasTwoFactorAuth { get; set; }
        
        public string MobileNumber { get; set; }
    }
}