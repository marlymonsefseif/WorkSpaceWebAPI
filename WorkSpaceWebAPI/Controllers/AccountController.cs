using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto UserFromRegister)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(UserFromRegister.Email);
            if (existingUser != null)
                return BadRequest("Email already exists");

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = UserFromRegister.FirstName,
                LastName = UserFromRegister.LastName,
                Email = UserFromRegister.Email,
                UserName = UserFromRegister.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user,UserFromRegister.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            bool roleCreated = await MakeRole("User");  
            if (!roleCreated)
            {
                return BadRequest("Failed to create User role.");
            }

            await _userManager.AddToRoleAsync(user, "User");
            if (UserFromRegister.Email.ToLower() == "admin@gmail.com")
            {
                roleCreated = await MakeRole("Admin");
                if (!roleCreated)
                    return BadRequest("Failed to create Admin role.");
                await _userManager.AddToRoleAsync(user, "Admin"); 
            }

            return Ok(new { message = "Account Create Success" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto UserFromLogin)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            ApplicationUser user = await _userManager.FindByEmailAsync(UserFromLogin.Email);
            if (user == null)
                return BadRequest("Invalid Account");

            bool found = await _userManager.CheckPasswordAsync(user, UserFromLogin.Password);
            if (!found)
                return BadRequest("Invalid Password");

            //-------------------------Create Token----------------------------
            string jti = Guid.NewGuid().ToString();
            var userRoles = await _userManager.GetRolesAsync(user);
            var expireDate = UserFromLogin.RememberMe ? DateTime.UtcNow.AddDays(15) : DateTime.UtcNow.AddHours(1);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim("Email", user.Email ?? ""),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken myToken = new JwtSecurityToken(
                issuer: _config["JWT:Iss"],
                audience: _config["JWT:Aud"],
                expires: expireDate,
                claims: claims,
                signingCredentials: signingCredentials
                );

            return Ok(new
            {
                id = user.Id,
                name = user.FirstName,
                expired = expireDate,
                token = new JwtSecurityTokenHandler().WriteToken(myToken)
            });
        }


        [NonAction]
        public async Task<bool> MakeRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                IdentityRole<int> role = new IdentityRole<int> { Name = roleName };
                IdentityResult result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;  
        }


    }
}
