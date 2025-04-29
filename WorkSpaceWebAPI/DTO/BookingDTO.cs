using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.DTO
{
    public class BookingDTO
    {
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly? EndTime { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public int Amount { get; set; }

        public Status status { get; set; } = Status.Pending;

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("zone")]
        public int ZoneId { get; set; }
    }
}
