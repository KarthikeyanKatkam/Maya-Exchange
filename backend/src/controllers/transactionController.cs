using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IKycService _kycService;
        private readonly INotificationService _notificationService;

        public TransactionController(
            ILogger<TransactionController> logger,
            ITransactionService transactionService,
            IKycService kycService,
            INotificationService notificationService)
        {
            _logger = logger;
            _transactionService = transactionService;
            _kycService = kycService;
            _notificationService = notificationService;
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetTransactionHistory([FromQuery] TransactionQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var transactions = await _transactionService.GetTransactionHistory(userId, queryParams);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving transaction history: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("send")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> SendTransaction([FromBody] TransactionRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var kycStatus = await _kycService.ValidateKycStatus(userId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var transaction = await _transactionService.ProcessSendTransaction(userId, request);
                await _notificationService.SendTransactionNotification(userId, transaction.TransactionId);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing send transaction: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("receive")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> ReceiveTransaction([FromBody] ReceiveTransactionRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var kycStatus = await _kycService.ValidateKycStatus(userId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var transaction = await _transactionService.ProcessReceiveTransaction(userId, request);
                await _notificationService.SendTransactionNotification(userId, transaction.TransactionId);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing receive transaction: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("convert")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> ConvertCurrency([FromBody] ConversionRequest request)
        {
            try
            {
                var userId = User.GetUserId();
                var kycStatus = await _kycService.ValidateKycStatus(userId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var conversion = await _transactionService.ProcessCurrencyConversion(userId, request);
                await _notificationService.SendConversionNotification(userId, conversion.ConversionId);
                return Ok(conversion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing currency conversion: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("details/{transactionId}")]
        [Authorize]
        public async Task<IActionResult> GetTransactionDetails(string transactionId)
        {
            try
            {
                var userId = User.GetUserId();
                var details = await _transactionService.GetTransactionDetails(userId, transactionId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving transaction details: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
