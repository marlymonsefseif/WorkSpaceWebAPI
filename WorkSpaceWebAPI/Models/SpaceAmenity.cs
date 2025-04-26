using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class SpaceAmenity
    {
        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }

        // Navigation property
        public Spaces? Space { get; set; } 
        public Amenity? Amenity { get; set; } 
    }
}
