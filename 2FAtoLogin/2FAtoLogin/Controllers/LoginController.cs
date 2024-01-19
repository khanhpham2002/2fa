using _2FAtoLogin.Data;
using _2FAtoLogin.Domain;
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
        private readonly IDbContext _dbContext;
        public LoginController(IUserService userService, ITokenService tokenService , IDbContext dbContext)
        {
            _userService = userService;
            _tokenService = tokenService;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] UserLogin model)
        {
            try
            {
                var tmp = await _userService.GetUser(model.UserName, model.Password);
                var testRoles = new List<ProductRole>
                {
                    new ProductRole { RoleName = RoleType.ADMINISTRATOR },
                    new ProductRole { RoleName = RoleType.VIEWER }
                };

                if (tmp!=null)
                {
                    var jwtToken = new JwtToken()
                    {
                        Roles = testRoles.ToArray(),
                        Scheme = "Bearer",
                        UserName = tmp.UserName,
                        UserId = tmp.UserId,
                        Token = _tokenService.CreateToken(tmp.UserName, "LoginSignature", testRoles.ToArray(),model.RememberMe,model.Password,false),
                        IsConfigurator = false
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
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddUser([FromBody] User user)
        {
            try
            {
                _userService.AddUser(user);
      
               
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
    }
}
