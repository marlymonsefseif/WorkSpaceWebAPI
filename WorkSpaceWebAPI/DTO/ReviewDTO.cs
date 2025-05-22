using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class ReviewDTO
    {
        public int? Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? RoomName { get; set; }

    }
}
