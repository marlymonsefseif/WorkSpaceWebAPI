using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class ReviewDTO
    {
        public int? Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? RoomName { get; set; }

    }
}
