using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private IGalleryRepository _galleryReposetory;
      

        public GalleryController(IGalleryRepository galleryReposetory)
        {
            _galleryReposetory = galleryReposetory;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var galleries = await _galleryReposetory
                .GetAllAsync(g =>
                new {
                    g.Id,
                    ImageUrl=_galleryReposetory.GetFullImageUrl(g.ImageURl),
                    g.Caption
                });
            return Ok(galleries);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gallery = await _galleryReposetory.GetByIdAsync(id);
            if (gallery == null)
                return NotFound();
            gallery.ImageURl = _galleryReposetory.GetFullImageUrl(gallery.ImageURl);
            return Ok(gallery);
        }
        [HttpGet("space/{spaceId:int}")]
        public async Task<IActionResult> GetBySpaceId(int spaceId)
        {
            var galleries = await _galleryReposetory
                    .GetAllBySpaceIdAsync(spaceId, 
                    g => new 
                    {
                        g.Id,
                        ImageUrl=_galleryReposetory.GetFullImageUrl(g.ImageURl),
                        g.Caption,
                        g.SpaceId
                    });
            if (galleries == null || galleries.Count == 0)
                return NotFound();
            return Ok(galleries);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] GalleryDto galleryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Gallery gallery = await _galleryReposetory.Add(galleryDto);
                _galleryReposetory.SaveChanges();
                gallery.ImageURl = _galleryReposetory.GetFullImageUrl(gallery.ImageURl);
                return CreatedAtAction(nameof(GetById), new { id = gallery.Id }, gallery);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _galleryReposetory.DeleteAsync(id);
            if (!result)
                return NotFound();
            _galleryReposetory.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("editCaption/{id:int}")]
        public async Task<IActionResult> Update(int id,string caption)
        {
            if (string.IsNullOrEmpty(caption))
                return BadRequest("Caption cannot be null or empty");
            Gallery existingGallery = await _galleryReposetory.GetByIdAsync(id);
            if (existingGallery == null)
                return NotFound();
            
            existingGallery.Caption = caption;
            _galleryReposetory.Update(existingGallery);
            _galleryReposetory.SaveChanges();
            return NoContent();
        }
    }
}
