using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Controllers;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoyaltyRoutes : ControllerBase
    {
        private readonly ILoyaltyService _loyaltyService;
        private readonly IUserService _userService;

        public LoyaltyRoutes(ILoyaltyService loyaltyService, IUserService userService)
        {
            _loyaltyService = loyaltyService;
            _userService = userService;
        }

        [HttpGet("points/balance")]
        [Authorize]
        public async Task<IActionResult> GetLoyaltyPoints()
        {
            try
            {
                var userId = User.Identity.Name;
                var points = await _loyaltyService.GetUserPoints(userId);
                return Ok(new { points });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("points/earn")]
        [Authorize]
        public async Task<IActionResult> EarnPoints([FromBody] TransactionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var earnedPoints = await _loyaltyService.CalculateAndAwardPoints(userId, request.Amount);
                return Ok(new { earnedPoints });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("points/redeem")]
        [Authorize]
        public async Task<IActionResult> RedeemPoints([FromBody] RedeemRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var redemption = await _loyaltyService.RedeemPoints(userId, request.Points);
                return Ok(new { redemption });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("rewards")]
        [Authorize]
        public async Task<IActionResult> GetAvailableRewards()
        {
            try
            {
                var rewards = await _loyaltyService.GetAvailableRewards();
                return Ok(new { rewards });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("tier/status")]
        [Authorize]
        public async Task<IActionResult> GetUserTierStatus()
        {
            try
            {
                var userId = User.Identity.Name;
                var tierStatus = await _loyaltyService.GetUserTierStatus(userId);
                return Ok(new { tierStatus });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("referral/create")]
        [Authorize]
        public async Task<IActionResult> CreateReferralCode()
        {
            try
            {
                var userId = User.Identity.Name;
                var referralCode = await _loyaltyService.GenerateReferralCode(userId);
                return Ok(new { referralCode });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("referral/redeem")]
        [Authorize]
        public async Task<IActionResult> RedeemReferralCode([FromBody] ReferralRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _loyaltyService.RedeemReferralCode(userId, request.ReferralCode);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
