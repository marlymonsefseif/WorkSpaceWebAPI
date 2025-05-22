using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceWebAPI.DTO
{
    public class UserMembershipDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }
        public int DurationInDays { get; set; }
        public int User_Id { get; set; }

        [ForeignKey("MembershipPlan")]
        public int MembershipPlans_Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
