using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MayaLaunchpadController : ControllerBase
    {
        private readonly ILaunchpadService _launchpadService;
        private readonly ILogger<MayaLaunchpadController> _logger;

        public MayaLaunchpadController(ILaunchpadService launchpadService, ILogger<MayaLaunchpadController> logger)
        {
            _launchpadService = launchpadService;
            _logger = logger;
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetLaunchpadProjects()
        {
            try
            {
                var projects = await _launchpadService.GetActiveProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving launchpad projects");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetProjectDetails(string id)
        {
            try
            {
                var details = await _launchpadService.GetProjectDetails(id);
                return Ok(details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving project details");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("participate")]
        public async Task<IActionResult> ParticipateInProject([FromBody] ProjectParticipationRequest request)
        {
            try
            {
                var result = await _launchpadService.ParticipateInProject(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error participating in project");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("allocations")]
        public async Task<IActionResult> GetUserAllocations()
        {
            try
            {
                var allocations = await _launchpadService.GetUserAllocations();
                return Ok(allocations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user allocations");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetLaunchpadStatistics()
        {
            try
            {
                var stats = await _launchpadService.GetLaunchpadStats();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving launchpad statistics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("claim")]
        public async Task<IActionResult> ClaimTokens([FromBody] TokenClaimRequest request)
        {
            try
            {
                var result = await _launchpadService.ClaimTokens(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error claiming tokens");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
