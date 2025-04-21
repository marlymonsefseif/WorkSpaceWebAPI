namespace WorkSpaceWebAPI.Models
{
    public class SpaceAmenity
    {
        public int SpaceId { get; set; }
        public int AmenityId { get; set; }
       
        //public Space Space { get; set; } // Assuming you have a Space class
        public Amenity Amenity { get; set; } // Assuming you have an Amenity class
    }
}
