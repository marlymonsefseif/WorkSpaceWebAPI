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



//[HttpGet]
//public IActionResult GetAll()
//{
//    List<Category> categories = _categoryRepository.GetAll();
//    return Ok(categories);
//}

//[HttpGet("{id:int}")]
//public IActionResult GetById(int id)
//{
//    Category category = _categoryRepository.GetById(id);
//    if (category != null)
//    {
//        return Ok(category);
//    }
//    return NotFound();
//}

//[HttpPost]
//public IActionResult Insert(Category category)
//{
//    if (ModelState.IsValid == true)
//    {
//        try
//        {
//            _categoryRepository.Insert(category);
//            _categoryRepository.Save();
//            return CreatedAtAction("GetById", new { id = category.Id }, category);
//        }
//        catch (Exception ex)
//        {
//            ModelState.AddModelError("", ex.InnerException.Message);
//        }
//    }
//    return BadRequest(ModelState);
//}

//[HttpPut("{id:int}")]
//public IActionResult Update(int id, Category categoryFromReq)
//{
//    if (ModelState.IsValid)
//    {
//        try
//        {
//            Category categoryFromDb = _categoryRepository.GetById(id);
//            if (categoryFromDb != null)
//            {
//                categoryFromDb.Name = categoryFromReq.Name;
//                categoryFromDb.Description = categoryFromReq.Description;
//                _categoryRepository.Save();
//                return NoContent();
//            }
//        }
//        catch (Exception ex)
//        {
//            ModelState.AddModelError("", "Invalid id");
//        }
//    }
//    return BadRequest(ModelState);
//}

//[HttpDelete("{id:int}")]
//public IActionResult Delete(int id)
//{
//    Category category = _categoryRepository.GetById(id);
//    if (category != null)
//    {
//        _categoryRepository.Delete(id);
//        _categoryRepository.Save();
//        return NoContent();
//    }
//    return BadRequest("Invalid ID");
//}

//[HttpGet("/m")]
//public IActionResult GetAllProducts()
//{
//    List<CategorywithProducts> categories = _categoryRepository.GetAllWithProducts();
//    if (categories != null)
//        return Ok(categories);
//    return NotFound();
//}
