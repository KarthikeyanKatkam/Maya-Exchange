using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MayaVisaCardController : ControllerBase
    {
        private readonly ILogger<MayaVisaCardController> _logger;
        private readonly IVisaCardService _visaCardService;
        private readonly IKycService _kycService;
        private readonly ITransactionService _transactionService;

        public MayaVisaCardController(
            ILogger<MayaVisaCardController> logger,
            IVisaCardService visaCardService,
            IKycService kycService, 
            ITransactionService transactionService)
        {
            _logger = logger;
            _visaCardService = visaCardService;
            _kycService = kycService;
            _transactionService = transactionService;
        }

        [HttpPost("issue")]
        [KycVerification]
        public async Task<IActionResult> IssueVisaCard([FromBody] VisaCardRequest request)
        {
            try
            {
                var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var card = await _visaCardService.IssueNewCard(request);
                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error issuing Visa card: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("{cardId}")]
        [Authorize]
        public async Task<IActionResult> GetCardDetails(string cardId)
        {
            try
            {
                var card = await _visaCardService.GetCardDetails(cardId);
                if (card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving card details: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("activate")]
        [Authorize]
        public async Task<IActionResult> ActivateCard([FromBody] CardActivationRequest request)
        {
            try
            {
                var result = await _visaCardService.ActivateCard(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error activating card: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("block")]
        [Authorize]
        public async Task<IActionResult> BlockCard([FromBody] CardBlockRequest request)
        {
            try
            {
                var result = await _visaCardService.BlockCard(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error blocking card: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpGet("transactions/{cardId}")]
        [Authorize]
        public async Task<IActionResult> GetCardTransactions(string cardId, [FromQuery] TransactionQueryParams queryParams)
        {
            try
            {
                var transactions = await _transactionService.GetCardTransactions(cardId, queryParams);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving card transactions: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }

        [HttpPost("limit")]
        [Authorize]
        public async Task<IActionResult> UpdateSpendingLimit([FromBody] SpendingLimitRequest request)
        {
            try
            {
                var result = await _visaCardService.UpdateSpendingLimit(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating spending limit: {ex.Message}");
                return StatusCode(500, new { message = "Error processing request" });
            }
        }
    }
}
