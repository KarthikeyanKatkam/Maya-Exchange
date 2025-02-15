using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoyaltyController : ControllerBase
    {
        private readonly ILogger<LoyaltyController> _logger;
        private readonly ILoyaltyService _loyaltyService;

        public LoyaltyController(
            ILogger<LoyaltyController> logger,
            ILoyaltyService loyaltyService)
        {
            _logger = logger;
            _loyaltyService = loyaltyService;
        }

        [HttpGet("points")]
        public async Task<IActionResult> GetLoyaltyPoints()
        {
            try
            {
                var points = await _loyaltyService.GetUserPoints();
                return Ok(points);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving loyalty points");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("tiers")]
        public async Task<IActionResult> GetLoyaltyTiers()
        {
            try
            {
                var tiers = await _loyaltyService.GetLoyaltyTiers();
                return Ok(tiers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving loyalty tiers");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("redeem")]
        public async Task<IActionResult> RedeemPoints([FromBody] PointRedemptionRequest request)
        {
            try
            {
                var result = await _loyaltyService.RedeemPoints(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error redeeming points");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetPointsHistory([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var history = await _loyaltyService.GetPointsHistory(startDate, endDate);
                return Ok(history);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving points history");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("rewards")]
        public async Task<IActionResult> GetAvailableRewards()
        {
            try
            {
                var rewards = await _loyaltyService.GetAvailableRewards();
                return Ok(rewards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available rewards");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferPoints([FromBody] PointTransferRequest request)
        {
            try
            {
                var result = await _loyaltyService.TransferPoints(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error transferring points");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
