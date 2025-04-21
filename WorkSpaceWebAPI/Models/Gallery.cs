namespace WorkSpaceWebAPI.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public int SpaceId { get; set; }
        public Spaces Space { get; set; } // Navigation property
    }
}
