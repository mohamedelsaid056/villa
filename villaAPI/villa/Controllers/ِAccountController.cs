using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using villa.Data;
using villa.DTO;
using villa.Models;

namespace villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

 
            private readonly ILogger<AccountController> _logger;
            private readonly ApplicationDbContext _context;

            private readonly UserManager<ApplicationUser> _userManager;

            private readonly IConfiguration _configuration;

            public AccountController(ILogger<AccountController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
            {
                _logger = logger;
                _context = context;

                _userManager = userManager;
                _configuration = configuration;

            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] registerDTO registerDTO)
            {
                if (registerDTO == null)
                    return BadRequest(ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                var user = new ApplicationUser()
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,

                };
                var result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);



                }
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] loginDTO loginDTO)
            {
                if (loginDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // check usermname

                var user = await _userManager.FindByNameAsync(loginDTO.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return BadRequest(ModelState);
                }
                //check password

                var found = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

                if (!found)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return BadRequest(ModelState);
                }
                else
                {
                    //create jwt 
                    //first i need to create list of claims 
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                    // if i have arole a will add it here 

                    //create key

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    //create credentials

                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // create token 
                    var MyToken = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: credentials

                        );


                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(MyToken),
                        expiration = MyToken.ValidTo
                    });
                }
            }
        }
    }


