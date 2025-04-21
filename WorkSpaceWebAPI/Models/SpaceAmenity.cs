namespace WorkSpaceWebAPI.Models
{
    public class SpaceAmenity
    {
        public int SpaceId { get; set; }
        public int AmenityId { get; set; }
       
        public Spaces Space { get; set; } 
        public Amenity Amenity { get; set; } 
    }
}
