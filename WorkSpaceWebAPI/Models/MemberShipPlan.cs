using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.Models
{
    public class MemberShipPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public ICollection<UserMemberShip>? UserMemberships { get; set; }
    }
}