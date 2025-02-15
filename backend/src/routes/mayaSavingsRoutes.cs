using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/savings")]
    public class MayaSavingsRoutes : ControllerBase
    {
        private readonly ISavingsService _savingsService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public MayaSavingsRoutes(
            ISavingsService savingsService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _savingsService = savingsService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpGet("balance")]
        [Authorize]
        public async Task<IActionResult> GetSavingsBalance()
        {
            try
            {
                var userId = User.Identity.Name;
                var balance = await _savingsService.GetUserSavingsBalance(userId);
                return Ok(new { balance });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("deposit")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> DepositToSavings([FromBody] SavingsDepositRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for savings deposits");
                }

                var result = await _savingsService.ProcessDeposit(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("withdraw")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> WithdrawFromSavings([FromBody] SavingsWithdrawalRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetKycStatus(userId);

                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for savings withdrawals");
                }

                var result = await _savingsService.ProcessWithdrawal(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("transactions")]
        [Authorize]
        public async Task<IActionResult> GetSavingsTransactions()
        {
            try
            {
                var userId = User.Identity.Name;
                var transactions = await _savingsService.GetUserTransactions(userId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("interest-rate")]
        [Authorize]
        public async Task<IActionResult> GetCurrentInterestRate()
        {
            try
            {
                var interestRate = await _savingsService.GetCurrentInterestRate();
                return Ok(new { interestRate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
