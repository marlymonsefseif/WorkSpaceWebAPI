namespace WorkSpaceWebAPI.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<SpaceAmenity>? Amenities { get; set; }
    }
}
