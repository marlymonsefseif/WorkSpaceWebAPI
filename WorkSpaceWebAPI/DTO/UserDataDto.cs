namespace WorkSpaceWebAPI.DTO
{
    public class UserDataDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfileImg { get; set; }
        public List<string>? membershipName { get; set; }
        public string? NewPassword { get; set; }

    }
}
