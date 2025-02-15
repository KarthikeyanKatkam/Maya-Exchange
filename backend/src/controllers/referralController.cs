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
    public class ReferralController : ControllerBase
    {
        private readonly ILogger<ReferralController> _logger;
        private readonly IReferralService _referralService;
        private readonly IUserService _userService;

        public ReferralController(
            ILogger<ReferralController> logger,
            IReferralService referralService,
            IUserService userService)
        {
            _logger = logger;
            _referralService = referralService;
            _userService = userService;
        }

        [HttpPost("generate")]
        [Authorize]
        public async Task<IActionResult> GenerateReferralCode()
        {
            try
            {
                var userId = User.GetUserId();
                var referralCode = await _referralService.GenerateReferralCode(userId);
                return Ok(new { referralCode });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error generating referral code: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("stats")]
        [Authorize] 
        public async Task<IActionResult> GetReferralStats()
        {
            try
            {
                var userId = User.GetUserId();
                var stats = await _referralService.GetReferralStats(userId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving referral stats: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyReferralCode([FromBody] ReferralApplyRequest request)
        {
            try
            {
                var result = await _referralService.ApplyReferralCode(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error applying referral code: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("rewards")]
        [Authorize]
        public async Task<IActionResult> GetReferralRewards([FromQuery] RewardQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var rewards = await _referralService.GetReferralRewards(userId, queryParams);
                return Ok(rewards);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving referral rewards: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("claim-reward")]
        [Authorize]
        public async Task<IActionResult> ClaimReferralReward([FromBody] RewardClaimRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _referralService.ClaimReward(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error claiming referral reward: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
