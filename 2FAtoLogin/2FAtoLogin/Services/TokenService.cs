using _2FAtoLogin.Common;
using _2FAtoLogin.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace _2FAtoLogin.Services
{
    public class TokenService : ITokenService
    {
        private const string plainTextSecurityKey = "P6u~yga@nP6eJde}3k?g8Fkhanhpahm10022002";
        private const string issuer = "https://localhost:44364/";
        private const string audience = "https://localhost:44364/";


        public string CreateToken(string username, string scadaSessionId, ProductRole[] roles, bool rememberBe = false, string password = "", bool isConfigurator = false)
        {
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, username),
                new Claim(Constants.ScadaSessionId, scadaSessionId),
            };

            if (roles.Any(x => x.RoleName == RoleType.ADMINISTRATOR) || isConfigurator)
            {
                claims.Add(new Claim(Constants.LoginSignature, Security.Encrypt(password)));
            }

            var claimsIdentity = new ClaimsIdentity(claims, "Custom");

            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,role.RoleName.ToString()));
            }
            if (isConfigurator)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "-" + RoleType.CONFIGURATOR.ToString()));
            }

            var securityTokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
                Audience = audience,
                Issuer = issuer,
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                IssuedAt = DateTime.UtcNow,
                Expires = rememberBe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(plainToken);
        }

        public ClaimsPrincipal ValidateToken(string token, out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken)
        {
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[]
               {
                    audience
               },
                ValidIssuers = new string[]
               {
                    issuer
               },
                IssuerSigningKey = signingKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.ValidateToken(token,
                tokenValidationParameters, out validatedToken);
        }

    }
}