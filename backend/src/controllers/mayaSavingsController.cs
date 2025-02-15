using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Maya.Models;
using Maya.Services;
using Maya.Utils;

namespace Maya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MayaSavingsController : ControllerBase
    {
        private readonly ISavingsService _savingsService;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;

        public MayaSavingsController(
            ISavingsService savingsService,
            IUserService userService, 
            ITransactionService transactionService)
        {
            _savingsService = savingsService;
            _userService = userService;
            _transactionService = transactionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSavingsAccount([FromBody] CreateSavingsAccountRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var account = await _savingsService.CreateSavingsAccount(userId, request);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetSavingsBalance()
        {
            try
            {
                var userId = User.GetUserId();
                var balance = await _savingsService.GetSavingsBalance(userId);
                return Ok(new { balance });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> DepositToSavings([FromBody] DepositRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var transaction = await _savingsService.DepositToSavings(userId, request.Amount, request.Currency);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawFromSavings([FromBody] WithdrawRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var transaction = await _savingsService.WithdrawFromSavings(userId, request.Amount, request.Currency);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetSavingsTransactions([FromQuery] TransactionQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var transactions = await _savingsService.GetSavingsTransactions(userId, queryParams);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("interest-rate")]
        public async Task<IActionResult> GetInterestRate()
        {
            try
            {
                var userId = User.GetUserId();
                var rate = await _savingsService.GetCurrentInterestRate(userId);
                return Ok(new { interestRate = rate });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("set-auto-save")]
        public async Task<IActionResult> SetAutoSave([FromBody] AutoSaveRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var settings = await _savingsService.SetAutoSaveRules(userId, request);
                return Ok(settings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
