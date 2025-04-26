using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.DTO
{
    public class SpaceDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerHour { get; set; }

        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }
        public bool IsAvailable { get; set; }
        public SpaceTypes SpaceType { get; set; }
        public List<int>? AmenitieIds { get; set; } = new List<int>();
    }
}
