using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _settingsService;
        private readonly INotificationService _notificationService;
        private readonly ISecurityService _securityService;

        public SettingsController(
            ILogger<SettingsController> logger,
            ISettingsService settingsService, 
            INotificationService notificationService,
            ISecurityService securityService)
        {
            _logger = logger;
            _settingsService = settingsService;
            _notificationService = notificationService;
            _securityService = securityService;
        }

        [HttpGet("preferences")]
        public async Task<IActionResult> GetUserPreferences()
        {
            try
            {
                var userId = User.GetUserId();
                var preferences = await _settingsService.GetUserPreferences(userId);
                return Ok(preferences);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving user preferences: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPut("preferences")]
        public async Task<IActionResult> UpdateUserPreferences([FromBody] UserPreferencesUpdateRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _settingsService.UpdateUserPreferences(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating user preferences: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("notification-settings")]
        public async Task<IActionResult> GetNotificationSettings()
        {
            try
            {
                var userId = User.GetUserId();
                var settings = await _notificationService.GetNotificationSettings(userId);
                return Ok(settings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving notification settings: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPut("notification-settings")]
        public async Task<IActionResult> UpdateNotificationSettings([FromBody] NotificationSettingsUpdateRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _notificationService.UpdateNotificationSettings(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating notification settings: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("security-settings")]
        public async Task<IActionResult> GetSecuritySettings()
        {
            try
            {
                var userId = User.GetUserId();
                var settings = await _securityService.GetSecuritySettings(userId);
                return Ok(settings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving security settings: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPut("security-settings")]
        public async Task<IActionResult> UpdateSecuritySettings([FromBody] SecuritySettingsUpdateRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _securityService.UpdateSecuritySettings(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating security settings: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("enable-2fa")]
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

        [HttpPost("disable-2fa")]
        public async Task<IActionResult> Disable2FA([FromBody] Disable2FARequest request)
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
    }
}
