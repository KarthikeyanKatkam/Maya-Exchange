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
    [Route("api/[controller]")]
    public class DepositWithdrawController : ControllerBase
    {
        private readonly IDepositWithdrawService _depositWithdrawService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public DepositWithdrawController(
            IDepositWithdrawService depositWithdrawService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _depositWithdrawService = depositWithdrawService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpPost("deposit")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for deposits");
                }

                var result = await _depositWithdrawService.ProcessDeposit(userId, request);
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
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var kycStatus = await _kycService.GetUserKycStatus(userId);

                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for withdrawals");
                }

                var result = await _depositWithdrawService.ProcessWithdrawal(userId, request);
                return Ok(result);
            }
            catch (InsufficientFundsException)
            {
                return BadRequest("Insufficient funds for withdrawal");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("limits")]
        [Authorize]
        public async Task<IActionResult> GetTransactionLimits()
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var limits = await _depositWithdrawService.GetUserTransactionLimits(userId);
                return Ok(limits);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetTransactionHistory([FromQuery] TransactionHistoryRequest request)
        {
            try
            {
                var userId = _authService.GetCurrentUserId();
                var history = await _depositWithdrawService.GetTransactionHistory(userId, request);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
