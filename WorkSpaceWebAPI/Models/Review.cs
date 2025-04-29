using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public UserMembership? User { get; set; }
        public Spaces? space { get; set; }
    }
}
