using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositWithdrawController : ControllerBase
    {
        private readonly ILogger<DepositWithdrawController> _logger;
        private readonly IDepositWithdrawService _depositWithdrawService;

        public DepositWithdrawController(
            ILogger<DepositWithdrawController> logger,
            IDepositWithdrawService depositWithdrawService)
        {
            _logger = logger;
            _depositWithdrawService = depositWithdrawService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            try
            {
                var result = await _depositWithdrawService.ProcessDeposit(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing deposit");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request) 
        {
            try
            {
                var result = await _depositWithdrawService.ProcessWithdrawal(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing withdrawal");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("limits")]
        public async Task<IActionResult> GetTransactionLimits()
        {
            try
            {
                var limits = await _depositWithdrawService.GetUserTransactionLimits();
                return Ok(limits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving transaction limits");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            try
            {
                var methods = await _depositWithdrawService.GetAvailablePaymentMethods();
                return Ok(methods);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving payment methods");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("fees")]
        public async Task<IActionResult> GetTransactionFees([FromQuery] string currency, [FromQuery] decimal amount)
        {
            try
            {
                var fees = await _depositWithdrawService.CalculateTransactionFees(currency, amount);
                return Ok(fees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating transaction fees");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetTransactionHistory([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var history = await _depositWithdrawService.GetTransactionHistory(startDate, endDate);
                return Ok(history);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving transaction history");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
