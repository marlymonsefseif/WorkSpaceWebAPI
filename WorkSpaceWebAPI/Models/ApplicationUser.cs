using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WorkSpaceWebAPI.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "First name cannot exceed 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Last name cannot exceed 20 characters.")]
        public string LastName { get; set; }

        public string? ImageProfileUrl { get; set; }
        // Navigation property
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<UserMembership>? Memberships { get; set; }
        public override string ToString()
        {
            return FirstName + ' ' + LastName;
        }
    }
}