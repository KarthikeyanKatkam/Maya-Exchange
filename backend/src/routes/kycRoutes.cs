using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Maya.Exchange.Models;
using Maya.Exchange.Services;
using Maya.Exchange.Controllers;

namespace Maya.Exchange.Routes
{
    [ApiController]
    [Route("api/kyc")]
    public class KycRoutes : ControllerBase
    {
        private readonly IKycService _kycService;
        private readonly IUserService _userService;

        public KycRoutes(IKycService kycService, IUserService userService)
        {
            _kycService = kycService;
            _userService = userService;
        }

        [HttpPost("submit")]
        [Authorize]
        public async Task<IActionResult> SubmitKyc([FromBody] KycSubmissionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _kycService.SubmitKycDocuments(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("status")]
        [Authorize]
        public async Task<IActionResult> GetKycStatus()
        {
            try
            {
                var userId = User.Identity.Name;
                var status = await _kycService.GetKycStatus(userId);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("verify")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifyKyc([FromBody] KycVerificationRequest request)
        {
            try
            {
                var result = await _kycService.VerifyKycSubmission(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("documents/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserDocuments(string userId)
        {
            try
            {
                var documents = await _kycService.GetUserKycDocuments(userId);
                return Ok(documents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("pending")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingVerifications()
        {
            try
            {
                var pendingVerifications = await _kycService.GetPendingKycVerifications();
                return Ok(pendingVerifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("update-level")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateKycLevel([FromBody] KycLevelUpdateRequest request)
        {
            try
            {
                var result = await _kycService.UpdateUserKycLevel(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
