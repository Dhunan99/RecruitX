namespace RecruitX.Models

{

    public class JobRequisition

    {

        public int JrId { get; set; }

        public string BusinessUnit { get; set; }

        public DateTime? RequestedDate { get; set; }

        public int? RequestedBy { get; set; }

        public int? HiringManager { get; set; }

        public int? NumPositions { get; set; }

        public string WorkShift { get; set; }

        public DateTime? ExpectedOnboardingDate { get; set; }

        public string WorkModel { get; set; }

        public string Role { get; set; }

        public string Qualification { get; set; }

        public decimal? TotalExperienceRequired { get; set; }

        public decimal? RelevantExperienceRequired { get; set; }

        public int? LocationId { get; set; }

        public string JobPurpose { get; set; }

        public string JobSpecification { get; set; }

        public string ProjectName { get; set; }

        public string ProjectRole { get; set; }

        public bool OnsiteOpportunity { get; set; }

        public bool? Billable { get; set; }

        public bool? ClientInterview { get; set; }

        public int? ClientId { get; set; }

        public string ExpectedSalaryRange { get; set; }

        public DateTime? IdealStartDate { get; set; }

        public string JdStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        // Navigation properties

        public Employee RequestedByEmployee { get; set; }

        public Employee HiringManagerEmployee { get; set; }

        public Employee CreatedByEmployee { get; set; }

        public Client Client { get; set; }

        public Location Location { get; set; }

    }

}

