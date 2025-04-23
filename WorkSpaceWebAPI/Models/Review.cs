namespace WorkSpaceWebAPI.Models
{
    public class Review
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoomId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserMembership User { get; set; }
        public Spaces Room { get; set; }
    }
}
