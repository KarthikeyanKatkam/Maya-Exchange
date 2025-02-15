using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Config;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly SecurityConfig _securityConfig;
        private readonly EnvConfig _envConfig;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService,
            SecurityConfig securityConfig,
            EnvConfig envConfig)
        {
            _logger = logger;
            _authService = authService;
            _securityConfig = securityConfig;
            _envConfig = envConfig;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var result = await _authService.RegisterUser(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var result = await _authService.LoginUser(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("2fa/enable")]
        public async Task<IActionResult> EnableTwoFactor()
        {
            try
            {
                if (!_securityConfig.GetEnableTwoFactorAuth())
                {
                    return BadRequest("Two-factor authentication is not enabled");
                }

                var result = await _authService.EnableTwoFactorAuth();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enabling 2FA");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("2fa/verify")]
        public async Task<IActionResult> VerifyTwoFactor([FromBody] VerifyTwoFactorRequest request)
        {
            try
            {
                var result = await _authService.VerifyTwoFactorCode(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying 2FA code");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("password/reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                await _authService.ResetPassword(request);
                return Ok(new { message = "Password reset email sent" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initiating password reset");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                await _authService.ChangePassword(request);
                return Ok(new { message = "Password changed successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogoutUser();
                return Ok(new { message = "Logged out successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("session")]
        public async Task<IActionResult> GetSessionInfo()
        {
            try
            {
                var sessionInfo = await _authService.GetCurrentSession();
                return Ok(sessionInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving session info");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
