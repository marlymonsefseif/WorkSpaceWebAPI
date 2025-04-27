using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class GalleryDto
    {
        [Required]
        public IFormFile ImgaeFile { get; set; }
        public string? Caption { get; set; }

        [Required]
        public int SpaceId { get; set; }
    }
}
