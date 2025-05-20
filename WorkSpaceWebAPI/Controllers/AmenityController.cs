using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityRepository _amenityRepo;

        public AmenityController(IAmenityRepository amenityRepo) 
        {
            _amenityRepo = amenityRepo;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Amenity name cannot be null or empty.");
            }
            Amenity amenity = new Amenity { Name = name };
            _amenityRepo.Add(amenity);
            _amenityRepo.SaveChanges();
            AmenityDto amenityDto = new AmenityDto
            {
                Id = amenity.Id,
                Name = amenity.Name
            };
            return Ok(amenityDto);

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Amenity> amenities = await _amenityRepo.GetAllAsync();
            List<AmenityDto> amenityDtos = amenities
                .Select(a => new AmenityDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();
            return Ok(amenityDtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            
            bool res= await _amenityRepo.DeleteAsync(id);
            if (!res)
            {
                return NotFound($"Amenity with id {id} not found.");
            }
            _amenityRepo.SaveChanges();
            return Ok("Amenity deleted successfully.");
        }
    }
}
