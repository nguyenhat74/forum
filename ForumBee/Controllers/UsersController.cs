using ForumBee.Models.ViewModel;
using ForumITUDA.Models.Authentication;
using ForumITUDA.Models.Interface;
using ForumITUDA.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForumITUDA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;
        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkLogin = await unitOfWork.Users.checkLogin(model.Username, model.Password);

                if (checkLogin == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }
                else
                {
                    var jwtToken = GenerateJwtToken(checkLogin.Id);
                    return Ok(new AuthResult()
                    {
                        Success = true,
                        Token = jwtToken.Result
                    });
                }
            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            string tokenString = Request.Headers["Authorization"].ToString();
            // Get UserId, ChildName, PhoneNumber from token
            var infoFromToken = Auths.GetInfoFromToken(tokenString);
            var userId = infoFromToken.Result.UserId;
            var data = await unitOfWork.Users.getProfile(Guid.Parse(userId));
            if (data == null) return BadRequest();
            return Ok(data);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> registerUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkRegister = await unitOfWork.Users.CheckRegister(model.Email);

                if (checkRegister != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                                "User da ton tai"
                            },
                        Success = false
                    });
                }
                else
                {
                    await unitOfWork.Users.RegisterUser(model.Email,model.Password,model.Firstname,model.Lastname);
                    return Ok(new AuthResult()
                    {
                        Errors = new List<string>() {
                                "Dang ky thanh cong"
                            },
                        Success = true
                    });
                }
            }
            return BadRequest(); 
        }



        private async Task<object> GenerateJwtToken(Guid id)
        {
            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["JwtExpireHours"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
