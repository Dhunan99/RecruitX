namespace RecruitX.Models
{
    public class JrAssignment
    {
        public long AssignmentId { get; set; }
        public int JrId { get; set; }
        public long AssignedTo { get; set; }
        public long AssignedBy { get; set; }
        public DateTime AssignedAt { get; set; }

        public JobRequisition JobRequisition { get; set; } = null!;
        public User AssignedToUser { get; set; } = null!;
        public User AssignedByUser { get; set; } = null!;
    }
}
