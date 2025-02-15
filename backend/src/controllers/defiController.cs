using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefiController : ControllerBase
    {
        private readonly ILogger<DefiController> _logger;
        private readonly IDefiService _defiService;

        public DefiController(ILogger<DefiController> logger, IDefiService defiService)
        {
            _logger = logger;
            _defiService = defiService;
        }

        [HttpGet("pools")]
        public async Task<IActionResult> GetLiquidityPools()
        {
            try
            {
                var pools = await _defiService.GetLiquidityPools();
                return Ok(pools);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving liquidity pools");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("yield-farms")]
        public async Task<IActionResult> GetYieldFarms()
        {
            try
            {
                var farms = await _defiService.GetYieldFarms();
                return Ok(farms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving yield farms");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("provide-liquidity")]
        public async Task<IActionResult> ProvideLiquidity([FromBody] LiquidityProvisionRequest request)
        {
            try
            {
                var result = await _defiService.ProvideLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error providing liquidity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("withdraw-liquidity")]
        public async Task<IActionResult> WithdrawLiquidity([FromBody] LiquidityWithdrawalRequest request)
        {
            try
            {
                var result = await _defiService.WithdrawLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error withdrawing liquidity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("staking-options")]
        public async Task<IActionResult> GetStakingOptions()
        {
            try
            {
                var options = await _defiService.GetStakingOptions();
                return Ok(options);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving staking options");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("stake")]
        public async Task<IActionResult> StakeTokens([FromBody] StakingRequest request)
        {
            try
            {
                var result = await _defiService.StakeTokens(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error staking tokens");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("unstake")]
        public async Task<IActionResult> UnstakeTokens([FromBody] UnstakingRequest request)
        {
            try
            {
                var result = await _defiService.UnstakeTokens(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unstaking tokens");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("rewards")]
        public async Task<IActionResult> GetRewards()
        {
            try
            {
                var rewards = await _defiService.GetUserRewards();
                return Ok(rewards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rewards");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("claim-rewards")]
        public async Task<IActionResult> ClaimRewards([FromBody] RewardsClaimRequest request)
        {
            try
            {
                var result = await _defiService.ClaimRewards(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error claiming rewards");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
