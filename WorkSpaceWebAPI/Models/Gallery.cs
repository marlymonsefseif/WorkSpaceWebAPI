using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string? Caption { get; set; }

        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        
        // Navigation property
        public Spaces? Space { get; set; } 
    }
}
