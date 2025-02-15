using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Config;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILogger<AnalyticsController> _logger;
        private readonly IAnalyticsService _analyticsService;
        private readonly SecurityConfig _securityConfig;
        private readonly DbConfig _dbConfig;

        public AnalyticsController(
            ILogger<AnalyticsController> logger,
            IAnalyticsService analyticsService,
            SecurityConfig securityConfig,
            DbConfig dbConfig)
        {
            _logger = logger;
            _analyticsService = analyticsService;
            _securityConfig = securityConfig;
            _dbConfig = dbConfig;
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactionAnalytics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetTransactionAnalytics(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting transaction analytics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUserAnalytics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetUserAnalytics(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user analytics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("kyc")]
        public async Task<IActionResult> GetKycAnalytics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetKycAnalytics(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting KYC analytics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurrencyAnalytics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetCurrencyAnalytics(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting currency analytics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("performance")]
        public async Task<IActionResult> GetSystemPerformance()
        {
            try
            {
                var performance = await _analyticsService.GetSystemPerformanceMetrics();
                return Ok(performance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting system performance metrics");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("security")]
        public async Task<IActionResult> GetSecurityAnalytics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetSecurityAnalytics(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting security analytics");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
