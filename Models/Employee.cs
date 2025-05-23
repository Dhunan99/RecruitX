using System.ComponentModel.DataAnnotations;

namespace RecruitX.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Position { get; set; }
        public string DeliveryUnit { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LocationId { get; set; }  
        public Location? Location { get; set; }

        public DateTime UpdatedAt { get; set; }
        public long UserId { get; set; } 
        public User User { get; set; } = null!;
    }
}
