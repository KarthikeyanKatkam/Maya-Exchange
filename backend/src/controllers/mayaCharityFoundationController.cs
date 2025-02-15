using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MayaCharityFoundationController : ControllerBase
    {
        private readonly ILogger<MayaCharityFoundationController> _logger;
        private readonly ICharityFoundationService _charityService;

        public MayaCharityFoundationController(
            ILogger<MayaCharityFoundationController> logger,
            ICharityFoundationService charityService)
        {
            _logger = logger;
            _charityService = charityService;
        }

        [HttpGet("campaigns")]
        public async Task<IActionResult> GetActiveCampaigns()
        {
            try
            {
                var campaigns = await _charityService.GetActiveCampaigns();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving active charity campaigns");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("donate")]
        public async Task<IActionResult> MakeDonation([FromBody] DonationRequest request)
        {
            try
            {
                var result = await _charityService.ProcessDonation(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing donation");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetDonationHistory([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var history = await _charityService.GetDonationHistory(startDate, endDate);
                return Ok(history);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving donation history");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("impact")]
        public async Task<IActionResult> GetCharityImpactMetrics()
        {
            try
            {
                var metrics = await _charityService.GetImpactMetrics();
                return Ok(metrics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving charity impact metrics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("certificates")]
        public async Task<IActionResult> GetDonationCertificates()
        {
            try
            {
                var certificates = await _charityService.GetUserDonationCertificates();
                return Ok(certificates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving donation certificates");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeToCharityUpdates([FromBody] CharitySubscriptionRequest request)
        {
            try
            {
                var result = await _charityService.SubscribeToUpdates(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error subscribing to charity updates");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
