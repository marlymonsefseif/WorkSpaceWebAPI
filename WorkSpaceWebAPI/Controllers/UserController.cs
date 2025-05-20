using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public UserController(IApplicationUserRepository applicationUser)
        {
            _userRepository = applicationUser;
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
        public IActionResult EditUser(int id, UserDataDto userDataFromReq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ApplicationUser userFromDb = _userRepository.GetById(id);
            userFromDb.FirstName = userDataFromReq.FirstName;
            userFromDb.LastName = userDataFromReq.LastName;
            userFromDb.Email = userDataFromReq.Email;
            userFromDb.PhoneNumber = userDataFromReq.PhoneNumber;
            userFromDb.ImageProfileUrl = userDataFromReq.ProfileImg;
            userFromDb.PasswordHash = userDataFromReq.NewPassword;
            _userRepository.Update(userFromDb);
            _userRepository.Save();
            return Ok(new { message = "Edit Success" });
        }
    }
}
