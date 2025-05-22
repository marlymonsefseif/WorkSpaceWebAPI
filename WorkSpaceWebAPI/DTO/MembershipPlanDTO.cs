using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class MembershipPlanDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero.")]
        public int DurationInDays { get; set; }
    }
}
