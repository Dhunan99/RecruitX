namespace RecruitX.Models
{
    public class User
    {
        public long UserId { get; set; }
        public long? EmployeeId { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
