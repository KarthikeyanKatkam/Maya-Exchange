using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KycController : ControllerBase
    {
        private readonly ILogger<KycController> _logger;
        private readonly IKycService _kycService;

        public KycController(
            ILogger<KycController> logger,
            IKycService kycService)
        {
            _logger = logger;
            _kycService = kycService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitKycDocuments([FromBody] KycSubmissionRequest request)
        {
            try
            {
                var result = await _kycService.SubmitDocuments(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting KYC documents");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetKycStatus()
        {
            try
            {
                var status = await _kycService.GetVerificationStatus();
                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving KYC status");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateKycInformation([FromBody] KycUpdateRequest request)
        {
            try
            {
                var result = await _kycService.UpdateInformation(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating KYC information");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("requirements")]
        public async Task<IActionResult> GetKycRequirements([FromQuery] string userLevel)
        {
            try
            {
                var requirements = await _kycService.GetRequirements(userLevel);
                return Ok(requirements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving KYC requirements");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyIdentity([FromBody] IdentityVerificationRequest request)
        {
            try
            {
                var result = await _kycService.VerifyIdentity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying identity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("limits")]
        public async Task<IActionResult> GetTransactionLimits()
        {
            try
            {
                var limits = await _kycService.GetUserTransactionLimits();
                return Ok(limits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving transaction limits");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
