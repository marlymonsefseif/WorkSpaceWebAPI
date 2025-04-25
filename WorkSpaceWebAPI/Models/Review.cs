using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserMembership? User { get; set; }
        public Spaces? Room { get; set; }
    }
}
