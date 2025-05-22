using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int RoomId { get; set; }
        public Spaces Room { get; set; }

    }

}
