using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly? EndTime { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public int Amount { get; set; }
        public string StatusDisplay => status.ToString();
        public Status status { get; set; } = Status.Pending;
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
    }
}
