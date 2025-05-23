namespace RecruitX.Models
{
    public class JobDescription
    {
        public int JdId { get; set; }
        public int JrId { get; set; }
        public string? Status { get; set; }
        public string? JobDesc { get; set; }
        public int? FillPositions { get; set; }
        public string? Updates { get; set; }  // Assuming JSON stored as string
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        // Navigation properties (optional)
        public JobRequisition? JobRequisition { get; set; }
        public Employee? CreatedByEmployee { get; set; }
    }
}
