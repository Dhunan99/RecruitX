using RecruitX.DTO;

public interface IJobDescriptionRepository
{
    Task<IEnumerable<JobDescriptionsDTO>> GetJobDescriptionsAsync();
}
