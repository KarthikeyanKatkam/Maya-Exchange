using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Models;
using MayaExchange.Services;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/launchpad")]
    public class MayaLaunchpadRoutes : ControllerBase
    {
        private readonly ILaunchpadService _launchpadService;
        private readonly IKycService _kycService;

        public MayaLaunchpadRoutes(ILaunchpadService launchpadService, IKycService kycService)
        {
            _launchpadService = launchpadService;
            _kycService = kycService;
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetLaunchpadProjects()
        {
            var projects = await _launchpadService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var project = await _launchpadService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [Authorize]
        [HttpPost("projects")]
        public async Task<IActionResult> CreateProject([FromBody] LaunchpadProject project)
        {
            // Verify KYC status before allowing project creation
            var kycStatus = await _kycService.GetUserKycStatusAsync(User.Identity.Name);
            if (kycStatus != KycStatus.Verified)
                return Unauthorized("KYC verification required");

            var createdProject = await _launchpadService.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
        }

        [Authorize]
        [HttpPost("projects/{id}/participate")]
        public async Task<IActionResult> ParticipateInProject(string id, [FromBody] ParticipationRequest request)
        {
            // Verify KYC status before allowing participation
            var kycStatus = await _kycService.GetUserKycStatusAsync(User.Identity.Name);
            if (kycStatus != KycStatus.Verified)
                return Unauthorized("KYC verification required");

            var result = await _launchpadService.ParticipateInProjectAsync(id, User.Identity.Name, request);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetLaunchpadStatistics()
        {
            var stats = await _launchpadService.GetLaunchpadStatisticsAsync();
            return Ok(stats);
        }

        [Authorize]
        [HttpGet("user/participations")]
        public async Task<IActionResult> GetUserParticipations()
        {
            var participations = await _launchpadService.GetUserParticipationsAsync(User.Identity.Name);
            return Ok(participations);
        }
    }
}
