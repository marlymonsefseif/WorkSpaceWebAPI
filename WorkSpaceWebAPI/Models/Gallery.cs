using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\w+\.[a-zA-Z]+")]
        public string ImageURl { get; set; }
        public string? Caption { get; set; }

        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        
        // Navigation property
        public Spaces? Space { get; set; } 
    }
}
