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
    [Route("api/settings")]
    public class SettingsRoutes : ControllerBase
    {
        private readonly IUserSettingsService _settingsService;
        private readonly IAuthenticationService _authService;
        private readonly IKycService _kycService;

        public SettingsRoutes(
            IUserSettingsService settingsService,
            IAuthenticationService authService,
            IKycService kycService)
        {
            _settingsService = settingsService;
            _authService = authService;
            _kycService = kycService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserSettings()
        {
            try
            {
                var userId = User.Identity.Name;
                var settings = await _settingsService.GetUserSettings(userId);
                return Ok(settings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUserSettings([FromBody] UserSettings settings)
        {
            try
            {
                var userId = User.Identity.Name;
                var updatedSettings = await _settingsService.UpdateUserSettings(userId, settings);
                return Ok(updatedSettings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("2fa")]
        [Authorize]
        public async Task<IActionResult> Toggle2FA([FromBody] bool enable)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (enable && kycStatus != KycStatus.Verified)
                {
                    return BadRequest("KYC verification required to enable 2FA");
                }

                var result = await _settingsService.Toggle2FA(userId, enable);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("notifications")]
        [Authorize]
        public async Task<IActionResult> UpdateNotificationSettings([FromBody] NotificationSettings settings)
        {
            try
            {
                var userId = User.Identity.Name;
                var updatedSettings = await _settingsService.UpdateNotificationSettings(userId, settings);
                return Ok(updatedSettings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("security")]
        [Authorize]
        public async Task<IActionResult> UpdateSecuritySettings([FromBody] SecuritySettings settings)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);

                if (kycStatus != KycStatus.Verified)
                {
                    return BadRequest("KYC verification required to modify security settings");
                }

                var updatedSettings = await _settingsService.UpdateSecuritySettings(userId, settings);
                return Ok(updatedSettings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
