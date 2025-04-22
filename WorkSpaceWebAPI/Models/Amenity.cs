using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.Models
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }
        
        public ICollection<SpaceAmenity>? Amenities { get; set; }
    }
}
