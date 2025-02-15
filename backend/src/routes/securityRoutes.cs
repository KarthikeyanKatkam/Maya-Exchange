using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/security")]
    public class SecurityRoutes : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public SecurityRoutes(
            ISecurityService securityService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _securityService = securityService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpPost("2fa/enable")]
        [Authorize]
        public async Task<IActionResult> Enable2FA()
        {
            try
            {
                var userId = User.Identity.Name;
                var setup = await _securityService.Enable2FAAsync(userId);
                return Ok(setup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("2fa/verify")]
        [Authorize] 
        public async Task<IActionResult> Verify2FA([FromBody] TwoFactorVerificationRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var isValid = await _securityService.Verify2FAAsync(userId, request.Code);
                if (!isValid)
                    return BadRequest("Invalid 2FA code");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("2fa/disable")]
        [Authorize]
        public async Task<IActionResult> Disable2FA([FromBody] TwoFactorVerificationRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var isValid = await _securityService.Verify2FAAsync(userId, request.Code);
                if (!isValid)
                    return BadRequest("Invalid 2FA code");

                await _securityService.Disable2FAAsync(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("activity-log")]
        [Authorize]
        public async Task<IActionResult> GetActivityLog()
        {
            try
            {
                var userId = User.Identity.Name;
                var activities = await _securityService.GetUserActivityLogAsync(userId);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("devices/trusted")]
        [Authorize]
        public async Task<IActionResult> AddTrustedDevice([FromBody] TrustedDeviceRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                await _securityService.AddTrustedDeviceAsync(userId, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("devices/trusted/{deviceId}")]
        [Authorize]
        public async Task<IActionResult> RemoveTrustedDevice(string deviceId)
        {
            try
            {
                var userId = User.Identity.Name;
                await _securityService.RemoveTrustedDeviceAsync(userId, deviceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
