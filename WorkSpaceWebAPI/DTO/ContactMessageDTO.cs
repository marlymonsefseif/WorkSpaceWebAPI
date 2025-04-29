using System.ComponentModel.DataAnnotations;

namespace WorkSpaceWebAPI.DTO
{
    public class ContactMessageDTO
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }
    }
}
