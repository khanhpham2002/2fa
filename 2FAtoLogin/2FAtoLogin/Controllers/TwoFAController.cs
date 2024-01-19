using _2FAtoLogin.Data;
using _2FAtoLogin.Domain;
using _2FAtoLogin.Models;
using _2FAtoLogin.Services;
using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
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
        private readonly UrlEncoder _encoder;

        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public TwoFAController(IUserService userService, ITokenService tokenService, IDbContext dbContext, UrlEncoder encoder)
        {
            _userService = userService;
            _tokenService = tokenService;
            _dbContext = dbContext;
            _encoder = encoder;
        }
        [HttpPost]
        [Route("create-mfa")]
        public async Task<IHttpActionResult> CreateMFA(string username)
        {
            var googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
            var userUniqueKey = username + googleAuthKey;
            var tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("kay", username, Encoding.UTF8.GetBytes(userUniqueKey) , 300);
            User tmp = await _userService.GetUserbyName(username);
            tmp.hasTwoFactorAuth = true;
            await _userService.UpdateUser(tmp);
            _dbContext.SaveChanges();
            return Ok(new
            {
                UserName = username,
                BarcodeImageUrl = GennerateQrCode(username,setupInfo.ManualEntryKey),
                SetupCode = setupInfo.ManualEntryKey
            });
            return Unauthorized();
        }
        private string GennerateQrCode(string username, string manualEntryKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _encoder.Encode("khanhpahm"),
                _encoder.Encode(username),
                manualEntryKey
                );
        }
        private static byte[] ConvertSecretToBytes(string secret, bool secretIsBase32) =>
           secretIsBase32 ? Base32Encoding.ToBytes(secret) : Encoding.UTF8.GetBytes(secret);


        [HttpPost]
        [Route("valid-mfa")]
        public async Task<IHttpActionResult> TwoFactorAuthenticate(UserLogin model, string code)
        {
            var googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
            var userUniqueKey = model.UserName + googleAuthKey;
            var tfa = new TwoFactorAuthenticator();
            var isValid = tfa.ValidateTwoFactorPIN(userUniqueKey, code);

            if (isValid)
            {
                User tmp = await _userService.GetUser(model.UserName, model.Password);
                var testRoles = new List<ProductRole>
                {
                    new ProductRole { RoleName = RoleType.ADMINISTRATOR },
                    new ProductRole { RoleName = RoleType.VIEWER }
                };
                if (tmp != null)
                {
                    var jwtToken = new JwtToken()
                    {
                        Roles = testRoles.ToArray(),
                        Scheme = "Bearer",
                        UserName = tmp.UserName,
                        UserId = tmp.UserId,
                        Token = _tokenService.CreateToken(tmp.UserName, "LoginSignature", testRoles.ToArray(), model.RememberMe, model.Password, false),
                        IsConfigurator = false
                    };
                    return Ok(jwtToken);
                }
                return Unauthorized();
            }

            return BadRequest("Invalid 2FA token");
        }

    }
}
