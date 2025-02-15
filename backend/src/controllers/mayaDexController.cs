using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MayaDexController : ControllerBase
    {
        private readonly ILogger<MayaDexController> _logger;
        private readonly IMayaDexService _dexService;

        public MayaDexController(
            ILogger<MayaDexController> logger,
            IMayaDexService dexService)
        {
            _logger = logger;
            _dexService = dexService;
        }

        [HttpGet("pairs")]
        public async Task<IActionResult> GetTradingPairs()
        {
            try
            {
                var pairs = await _dexService.GetAvailableTradingPairs();
                return Ok(pairs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving trading pairs");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("swap")]
        public async Task<IActionResult> SwapTokens([FromBody] SwapRequest request)
        {
            try
            {
                var result = await _dexService.ExecuteSwap(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing token swap");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("liquidity/pools")]
        public async Task<IActionResult> GetLiquidityPools()
        {
            try
            {
                var pools = await _dexService.GetLiquidityPools();
                return Ok(pools);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving liquidity pools");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("liquidity/add")]
        public async Task<IActionResult> AddLiquidity([FromBody] AddLiquidityRequest request)
        {
            try
            {
                var result = await _dexService.AddLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding liquidity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("liquidity/remove")]
        public async Task<IActionResult> RemoveLiquidity([FromBody] RemoveLiquidityRequest request)
        {
            try
            {
                var result = await _dexService.RemoveLiquidity(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing liquidity");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("price/{tokenPair}")]
        public async Task<IActionResult> GetTokenPrice(string tokenPair)
        {
            try
            {
                var price = await _dexService.GetTokenPrice(tokenPair);
                return Ok(price);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving token price");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetDexStats()
        {
            try
            {
                var stats = await _dexService.GetDexStatistics();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving DEX statistics");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
