using Microsoft.EntityFrameworkCore;
using RecruitX.DTO;
using RecruitX.Interfaces;

public class JobDescriptionRepository : IJobDescriptionRepository
{
    private readonly AppDbContext _context;

    public JobDescriptionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobDescriptionsDTO>> GetJobDescriptionsAsync()
    {
        return await _context.JobDescriptions
            .Include(j => j.JobRequisition)
                .ThenInclude(jr => jr.Location)
            .Select(jd => new JobDescriptionsDTO
            {
                Id = "JD" + jd.JdId.ToString("D3"),
                RoleTitle = jd.JobRequisition.Role,
                DeliveryUnit = jd.JobRequisition.BusinessUnit,
                Location = jd.JobRequisition.Location.Location_Name,
                Experience = $"{jd.JobRequisition.TotalExperienceRequired} years",
                CreatedDate = jd.CreatedAt,
                AssociatedJr = jd.JobRequisition.JobRequisition_Id.ToString("D3")
            })
            .ToListAsync();
    }
}
