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
    [Route("api/upi")]
    public class UpiRoutes : ControllerBase
    {
        private readonly IUpiService _upiService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public UpiRoutes(
            IUpiService upiService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _upiService = upiService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpPost("link")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> LinkUpiId([FromBody] UpiLinkRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return Unauthorized("KYC verification required for UPI linking");
                }

                var result = await _upiService.LinkUpiIdAsync(userId, request.UpiId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("details")]
        [Authorize]
        public async Task<IActionResult> GetUpiDetails()
        {
            try
            {
                var userId = User.Identity.Name;
                var details = await _upiService.GetUpiDetailsAsync(userId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("transfer")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> UpiTransfer([FromBody] UpiTransferRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return Unauthorized("KYC verification required for UPI transfers");
                }

                var result = await _upiService.ProcessUpiTransferAsync(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("unlink")]
        [Authorize]
        public async Task<IActionResult> UnlinkUpiId()
        {
            try
            {
                var userId = User.Identity.Name;
                await _upiService.UnlinkUpiIdAsync(userId);
                return Ok(new { message = "UPI ID unlinked successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
