using _2FAtoLogin.Models;
using _2FAtoLogin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _2FAtoLogin.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
       
        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] UserLogin model)
        {
            try
            {
                var tmp = await _userService.GetUser(model.UserName, model.Password);
                if(tmp!=null)
                {
                    var jwtToken = new JwtToken()
                    {
                        Role = "USER",
                        UserName = tmp.UserName,
                        UserId = tmp.UserId,
                        Token = _tokenService.CreateToken(tmp.UserName, "USER")
                    };
                    if (tmp.hasTwoFactorAuth) return Ok(tmp);
                    else return Ok(jwtToken);
                }
                return Unauthorized();
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
