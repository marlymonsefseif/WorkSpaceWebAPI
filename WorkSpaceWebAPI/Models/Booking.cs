using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeOnly? EndTime { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public decimal Amount { get; set; }
        public Status status { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("zone")]
        public int ZoneId { get; set; }
        public Spaces zone { get; set; }
    }
}