using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMembershipController : ControllerBase
    {
        private readonly IUserMembershipPlansRepository _userMembershipRepository;
        public UserMembershipController(IUserMembershipPlansRepository userMembership)
        {
            _userMembershipRepository = userMembership;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            List<UserMembership> users = _userMembershipRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            UserMembership user = _userMembershipRepository.GetById(id);
            return Ok(user);
        }

        

        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            UserMembership user = _userMembershipRepository.GetById(id);
            if (user == null)
                return BadRequest("Invalid Id");

            _userMembershipRepository.DeleteById(id);
            _userMembershipRepository.Save();
            return Ok(user);
        }
    }
}

