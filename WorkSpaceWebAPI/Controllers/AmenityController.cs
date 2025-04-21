using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IRepository<Amenity> amenityRepo;

        public AmenityController(IRepository<Amenity> amenityRepo) 
        {
            this.amenityRepo = amenityRepo;
        }
        [HttpPost]
        public ActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Amenity name cannot be null or empty.");
            }
            Amenity amenity = new Amenity { Name = name };
            amenityRepo.Add(amenity);
            amenityRepo.Save();
            return Created();

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Amenity> amenities =await amenityRepo.Get().ToListAsync();
            return Ok(amenities);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Amenity amenity = amenityRepo.GetById(id);
            if (amenity == null)
            {
                return NotFound();
            }
            amenityRepo.Delete(id);
            amenityRepo.Save();
            return NoContent();
        }
    }
}
