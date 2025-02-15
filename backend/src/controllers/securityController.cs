using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;

        public SecurityController(
            ILogger<SecurityController> logger,
            ISecurityService securityService,
            IUserService userService)
        {
            _logger = logger;
            _securityService = securityService;
            _userService = userService;
        }

        [HttpPost("2fa/enable")]
        [Authorize]
        public async Task<IActionResult> Enable2FA()
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _securityService.Enable2FA(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error enabling 2FA: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("2fa/verify")]
        [Authorize] 
        public async Task<IActionResult> Verify2FA([FromBody] TwoFactorVerifyRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _securityService.Verify2FA(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error verifying 2FA: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("2fa/disable")]
        [Authorize]
        public async Task<IActionResult> Disable2FA([FromBody] TwoFactorDisableRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _securityService.Disable2FA(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error disabling 2FA: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("password/change")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _securityService.ChangePassword(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error changing password: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("password/reset-request")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequest request)
        {
            try
            {
                var result = await _securityService.RequestPasswordReset(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error requesting password reset: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("password/reset-confirm")]
        public async Task<IActionResult> ConfirmPasswordReset([FromBody] PasswordResetConfirmRequest request)
        {
            try
            {
                var result = await _securityService.ConfirmPasswordReset(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error confirming password reset: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("activity-log")]
        [Authorize]
        public async Task<IActionResult> GetActivityLog([FromQuery] ActivityLogQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var activities = await _securityService.GetActivityLog(userId, queryParams);
                return Ok(activities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving activity log: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
