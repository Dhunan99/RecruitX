using Microsoft.AspNetCore.Mvc;
using RecruitX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequisitionController : ControllerBase
    {
        private readonly IJobRequisitionService _jobRequisitionService;

        public JobRequisitionController(IJobRequisitionService jobRequisitionService)
        {
            _jobRequisitionService = jobRequisitionService;
        }

        [HttpGet("track")]
        public async Task<ActionResult<List<TrackJrDto>>> GetTrackJobRequisitions()
        {
            var trackData = await _jobRequisitionService.GetTrackJrAsync();

            if (trackData == null || trackData.Count == 0)
                return NoContent();

            return Ok(trackData);
        }
    }
}
