using _2FAtoLogin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _2FAtoLogin.Services
{
    public interface ITokenService
    {
        string CreateToken(string username, string scadaSessionId, ProductRole[] roles, bool rememberBe = false, string password = "", bool isConfigurator = false);
        ClaimsPrincipal ValidateToken(string token, out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken);
    }
}
