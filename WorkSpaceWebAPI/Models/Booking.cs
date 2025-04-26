using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.Models
{
    public enum Status
    {
        Pending,
        Confirmed,
        Cancelled
    }
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

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

        // Navigation property
        public Spaces zone { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}