namespace RecruitX.Models
{
    public class OnSiteDetail
    {
        public int OnsiteDetailId { get; set; }
        public int JrId { get; set; }
        public string Rate { get; set; }
        public DateTime IdealStartDate { get; set; }
        public string? ContractType { get; set; }
        public string ContractDuration { get; set; }
        public string ReportingTo { get; set; }
        public string PreferredTimeZone { get; set; }
        public string PreferredVisaStatus { get; set; }
        public bool? H1TransferAccepted { get; set; }
        public string? InterviewProcess { get; set; }
        public bool? TravelRequired { get; set; }
        public string ClientBackground { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public JobRequisition? JobRequisition { get; set; }
    }
}