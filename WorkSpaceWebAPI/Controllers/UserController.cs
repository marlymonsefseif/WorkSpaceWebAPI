using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IApplicationUserRepository applicationUser, UserManager<ApplicationUser> userManager)
        {
            _userRepository = applicationUser;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            List<UserDataDto> users = _userRepository.GetUsers();
            return Ok(users);
        }


        [HttpGet("{id:int}")]
        [Authorize]
        public IActionResult GetUser(int id)
        {
            UserDataDto userData = _userRepository.GetUserById(id);
            return Ok(userData);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> EditUser(int id, UserDataDto userDataFromReq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ApplicationUser userFromDb = _userRepository.GetById(id);
            if (userFromDb == null)
                return NotFound();

            userFromDb.FirstName = userDataFromReq.FirstName ?? userFromDb.FirstName;
            userFromDb.LastName = userDataFromReq.LastName ?? userFromDb.LastName;
            userFromDb.Email = userDataFromReq.Email ?? userFromDb.Email;
            userFromDb.PhoneNumber = userDataFromReq.PhoneNumber ?? userFromDb.PhoneNumber;
            userFromDb.ImageProfileUrl = userDataFromReq.ProfileImg ?? userFromDb.ImageProfileUrl;
            if (!string.IsNullOrWhiteSpace(userDataFromReq.OldPassword) &&
                    !string.IsNullOrWhiteSpace(userDataFromReq.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(userFromDb, userDataFromReq.OldPassword, userDataFromReq.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    return BadRequest(new { message = "Password change failed", errors = passwordChangeResult.Errors });
                }
            }
            _userRepository.Update(userFromDb);
            _userRepository.Save();
            return Ok(new { message = "Edit Success" });
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {

        }
    }
}
