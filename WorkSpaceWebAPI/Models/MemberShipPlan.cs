using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.Models
{
    public class MembershipPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }
        public int DurationInDays { get; set; }

        // Navigation property
        public ICollection<UserMembership>? UserMemberships { get; set; }
    }
}