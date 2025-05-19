using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.DTO;
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
        public IActionResult GetUserById(int id)
        {
            UserDataDto user = _userRepository.GetUserById(id);
            return Ok(user);
        }
    }
}
