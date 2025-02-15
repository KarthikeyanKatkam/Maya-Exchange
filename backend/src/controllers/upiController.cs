using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpiController : ControllerBase
    {
        private readonly ILogger<UpiController> _logger;
        private readonly IUpiService _upiService;
        private readonly IKycService _kycService;
        private readonly ITransactionService _transactionService;

        public UpiController(
            ILogger<UpiController> logger,
            IUpiService upiService, 
            IKycService kycService,
            ITransactionService transactionService)
        {
            _logger = logger;
            _upiService = upiService;
            _kycService = kycService;
            _transactionService = transactionService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMoney([FromBody] UpiTransactionRequest request)
        {
            try
            {
                // Validate KYC status
                var kycStatus = await _kycService.ValidateKycStatus(request.SenderId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC validation failed" });
                }

                // Process UPI transaction
                var transaction = await _upiService.ProcessTransaction(request);
                if (!transaction.IsSuccess)
                {
                    return BadRequest(new { message = transaction.ErrorMessage });
                }

                // Record transaction
                await _transactionService.RecordTransaction(new TransactionRecord
                {
                    TransactionId = transaction.TransactionId,
                    SenderId = request.SenderId,
                    ReceiverId = request.ReceiverId,
                    Amount = request.Amount,
                    Currency = request.Currency,
                    TransactionType = TransactionType.UPI,
                    Status = TransactionStatus.Completed,
                    Timestamp = DateTime.UtcNow
                });

                return Ok(new { 
                    transactionId = transaction.TransactionId,
                    message = "Transaction successful"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing UPI transaction");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("balance/{upiId}")]
        public async Task<IActionResult> GetBalance(string upiId)
        {
            try
            {
                var balance = await _upiService.GetBalance(upiId);
                return Ok(new { balance = balance });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching UPI balance");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUpiId([FromBody] UpiValidationRequest request)
        {
            try
            {
                var isValid = await _upiService.ValidateUpiId(request.UpiId);
                return Ok(new { isValid = isValid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating UPI ID");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("transactions/{userId}")]
        public async Task<IActionResult> GetTransactionHistory(string userId)
        {
            try
            {
                var transactions = await _transactionService.GetUserTransactions(userId, TransactionType.UPI);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching UPI transaction history");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
