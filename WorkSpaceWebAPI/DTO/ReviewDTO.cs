using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class ReviewDTO
    {
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
    }
}
