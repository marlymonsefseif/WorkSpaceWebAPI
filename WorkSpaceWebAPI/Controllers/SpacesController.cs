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
    public class SpacesController : ControllerBase
    {
        private readonly ISpaceRepository _spaceRepository;
        public SpacesController(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var spaces = _spaceRepository.Get(s => s.IsDeleted == false, s => new { s.Id, s.Name, s.PricePerHour });
            return Ok(spaces);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            object space = _spaceRepository
                .GetById(id, s => new { s.Name, s.Description, s.Capacity, s.AvailableFrom, s.AvailableTo });
            if (space != null)
                return Ok(space);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Add(SpaceDTO spaceDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Spaces space = new Spaces
                    {
                        Name = spaceDto.Name,
                        Capacity = spaceDto.Capacity,
                        PricePerHour = spaceDto.PricePerHour,
                        SpaceType = spaceDto.SpaceType,
                        AvailableFrom = spaceDto.AvailableFrom,
                        AvailableTo = spaceDto.AvailableTo,
                        IsAvailable = spaceDto.IsAvailable,
                        Description = spaceDto.Description
                    };
                    _spaceRepository.Add(space);
                    _spaceRepository.SaveChanges();
                    return CreatedAtAction("GetById", new { id = space.Id }, null);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, SpaceDTO spaceEdit)
        {
            if (ModelState.IsValid)
            {
                Spaces space = _spaceRepository.GetById(id);
                if (space == null)
                    return NotFound();
                try
                {
                    space.Name = spaceEdit.Name;
                    space.Capacity = spaceEdit.Capacity;
                    space.PricePerHour = spaceEdit.PricePerHour;
                    space.SpaceType = spaceEdit.SpaceType;
                    space.AvailableFrom = spaceEdit.AvailableFrom;
                    space.AvailableTo = spaceEdit.AvailableTo;
                    space.IsAvailable = spaceEdit.IsAvailable;
                    space.Description = spaceEdit.Description;

                    _spaceRepository.Update(space);
                    _spaceRepository.SaveChanges();
                    //return RedirectToAction("GetById", new { id = space.Id });
                    return Ok("Updated");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("HardDelete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Spaces space = _spaceRepository.GetById(id);
            if (space != null)
            {
                _spaceRepository.Delete(space);
                _spaceRepository.SaveChanges();
                return Ok("Deleted");
            }

            return NotFound();
        }
        [HttpDelete("SoftDelete/{id:int}")]
        public IActionResult SoftDelete(int id)
        {
            Spaces space = _spaceRepository.GetById(id);
            if (space != null)
            {
                space.IsDeleted = true;
                _spaceRepository.Update(space);
                _spaceRepository.SaveChanges();
                return Ok("Deleted");
            }
            return NotFound();
        }
        [HttpPatch("restor/{id:int}")]
        public IActionResult Restore(int id)
        {
            Spaces space = _spaceRepository.GetById(id,true);
            if (space != null)
            {
                space.IsDeleted = false;
                _spaceRepository.Update(space);
                _spaceRepository.SaveChanges();
                return Ok("Restored");
            }
            return NotFound();
        }
        [HttpGet("GetDeleted")]
        public IActionResult GetDeleted()
        {
            var spaces = _spaceRepository.Get(s => s.IsDeleted == true, s => new { s.Id, s.Name, s.PricePerHour });
            return Ok(spaces);
        }
    }
}
