using _2FAtoLogin.Data;
using _2FAtoLogin.Models;
using _2FAtoLogin.Services;
using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace _2FAtoLogin.Controllers
{
    public class TwoFAController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IDbContext _dbContext;
        
        public TwoFAController(IUserService userService, ITokenService tokenService, IDbContext dbContext)
        {
            _userService = userService;
            _tokenService = tokenService;
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("createmfa")]
        public async Task<IHttpActionResult> CreateMFA(string username)
        {
            var googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
            var userUniqueKey = username + googleAuthKey;
            var tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("kay", username, ConvertSecretToBytes(userUniqueKey, false), 300);
            User tmp = await _userService.GetUserbyName(username);
            tmp.hasTwoFactorAuth = true;
            await _userService.UpdateUser(tmp);
            _dbContext.SaveChanges();
            return Ok(new
            {
                UserName = username,
                BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl,
                SetupCode = setupInfo.ManualEntryKey
            });
            return Unauthorized();
        }
        private static byte[] ConvertSecretToBytes(string secret, bool secretIsBase32) =>
           secretIsBase32 ? Base32Encoding.ToBytes(secret) : Encoding.UTF8.GetBytes(secret);

        [HttpPost]
        [Route("validmfa")]
        public async Task<IHttpActionResult> TwoFactorAuthenticate(UserLogin model, string code)
        {
            var googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
            var userUniqueKey = model.UserName + googleAuthKey;
            var tfa = new TwoFactorAuthenticator();
            var isValid = tfa.ValidateTwoFactorPIN(userUniqueKey, code);

            if (isValid)
            {
                User tmp = await _userService.GetUser(model.UserName, model.Password);
                if (tmp != null)
                {
                    var jwtToken = new JwtToken()
                    {
                        Role = "USER",
                        UserName = tmp.UserName,
                        UserId = tmp.UserId,
                        Token = _tokenService.CreateToken(tmp.UserName, "USER")
                    };
                    return Ok(jwtToken);
                }
                return Unauthorized();
            }

            return BadRequest("Invalid 2FA token");
        }

    }
}
