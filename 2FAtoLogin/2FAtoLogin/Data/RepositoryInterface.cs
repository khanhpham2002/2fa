﻿using _2FAtoLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2FAtoLogin.Data
{
    public partial interface IUserRepository : IRepository<User>
    {
    }
}