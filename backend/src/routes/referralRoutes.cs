using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Models;
using MayaExchange.Services;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralService _referralService;
        private readonly IUserService _userService;

        public ReferralController(IReferralService referralService, IUserService userService)
        {
            _referralService = referralService;
            _userService = userService;
        }

        [HttpPost("generate")]
        [Authorize]
        public async Task<IActionResult> GenerateReferralCode()
        {
            try
            {
                var userId = User.Identity.Name;
                var referralCode = await _referralService.GenerateReferralCode(userId);
                return Ok(new { ReferralCode = referralCode });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyReferralCode([FromBody] ApplyReferralRequest request)
        {
            try
            {
                var result = await _referralService.ApplyReferralCode(request.UserId, request.ReferralCode);
                return Ok(new { Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("rewards/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetReferralRewards(string userId)
        {
            try
            {
                var rewards = await _referralService.GetReferralRewards(userId);
                return Ok(new { Rewards = rewards });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("statistics/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetReferralStatistics(string userId)
        {
            try
            {
                var stats = await _referralService.GetReferralStatistics(userId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("withdraw-rewards")]
        [Authorize]
        public async Task<IActionResult> WithdrawReferralRewards([FromBody] WithdrawRewardsRequest request)
        {
            try
            {
                var result = await _referralService.WithdrawReferralRewards(request.UserId, request.Amount);
                return Ok(new { Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

    public class ApplyReferralRequest
    {
        public string UserId { get; set; }
        public string ReferralCode { get; set; }
    }

    public class WithdrawRewardsRequest
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
