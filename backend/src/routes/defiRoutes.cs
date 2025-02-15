using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Services;
using MayaExchange.Models;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/defi")]
    public class DefiRoutes : ControllerBase
    {
        private readonly IDefiService _defiService;
        private readonly IKycService _kycService;

        public DefiRoutes(IDefiService defiService, IKycService kycService)
        {
            _defiService = defiService;
            _kycService = kycService;
        }

        [HttpGet("pools")]
        [Authorize]
        public async Task<IActionResult> GetLiquidityPools()
        {
            try
            {
                var pools = await _defiService.GetLiquidityPools();
                return Ok(pools);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("provide-liquidity")]
        [Authorize]
        public async Task<IActionResult> ProvideLiquidity([FromBody] LiquidityProvisionRequest request)
        {
            try
            {
                var kycStatus = await _kycService.CheckUserKycStatus(User.Identity.Name);
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for liquidity provision");
                }

                var result = await _defiService.ProvideLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("remove-liquidity")]
        [Authorize]
        public async Task<IActionResult> RemoveLiquidity([FromBody] LiquidityRemovalRequest request)
        {
            try
            {
                var result = await _defiService.RemoveLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("yield-farms")]
        [Authorize]
        public async Task<IActionResult> GetYieldFarms()
        {
            try
            {
                var farms = await _defiService.GetYieldFarms();
                return Ok(farms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("stake")]
        [Authorize]
        public async Task<IActionResult> Stake([FromBody] StakingRequest request)
        {
            try
            {
                var kycStatus = await _kycService.CheckUserKycStatus(User.Identity.Name);
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for staking");
                }

                var result = await _defiService.Stake(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("unstake")]
        [Authorize]
        public async Task<IActionResult> Unstake([FromBody] UnstakingRequest request)
        {
            try
            {
                var result = await _defiService.Unstake(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("rewards")]
        [Authorize]
        public async Task<IActionResult> GetRewards()
        {
            try
            {
                var rewards = await _defiService.GetUserRewards(User.Identity.Name);
                return Ok(rewards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("claim-rewards")]
        [Authorize]
        public async Task<IActionResult> ClaimRewards([FromBody] RewardClaimRequest request)
        {
            try
            {
                var result = await _defiService.ClaimRewards(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
