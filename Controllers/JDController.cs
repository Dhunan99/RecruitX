using Microsoft.AspNetCore.Mvc;
using RecruitX.DTO;
using RecruitX.Interfaces;

namespace RecruitX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JDController : ControllerBase
    {
        private readonly IJobDescriptionRepository _repository;

        public JDController(IJobDescriptionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDescriptionsDTO>>> GetJobDescriptions()
        {
            var jobs = await _repository.GetJobDescriptionsAsync();
            return Ok(jobs);
        }
    }
}
