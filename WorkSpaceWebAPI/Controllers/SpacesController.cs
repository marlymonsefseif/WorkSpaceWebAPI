using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpacesController : ControllerBase
    {
        private readonly WorkSpaceDbContext _context;
        public SpacesController(WorkSpaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Spaces> spaces = _context.Spaces.ToList();
            return Ok(spaces);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            Spaces space = _context.Spaces.FirstOrDefault(s => s.Id == id);
            if (space != null)
                return Ok(space);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Insert(Spaces space)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Spaces.Add(space);
                    _context.SaveChanges();
                    return CreatedAtAction("GetById", new { id = space.Id }, space);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Spaces spaceReq)
        {
            if (ModelState.IsValid)
            {
                Spaces space = _context.Spaces.FirstOrDefault(d => d.Id == id);
                if (space != null)
                {
                    space.Name = spaceReq.Name;
                    space.Capacity = spaceReq.Capacity;
                    space.PricePerHour = spaceReq.PricePerHour;
                    space.SpaceType = spaceReq.SpaceType;
                    space.AvailableFrom = spaceReq.AvailableFrom;
                    space.AvailableTo = spaceReq.AvailableTo;
                    space.IsAvailable = spaceReq.IsAvailable;
                    space.Description = spaceReq.Description;
                    _context.SaveChanges();
                    return Ok("Update");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Spaces space = _context.Spaces.FirstOrDefault(d => d.Id == id);
            if (space != null)
            {
                _context.Spaces.Remove(space);
                _context.SaveChanges();
                return Ok("Deleted");
            }

            return BadRequest("Invalid Id");
        }
    }
}
