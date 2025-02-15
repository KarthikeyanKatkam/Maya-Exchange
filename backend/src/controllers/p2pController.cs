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
    public class P2PController : ControllerBase
    {
        private readonly ILogger<P2PController> _logger;
        private readonly IP2PService _p2pService;
        private readonly IKycService _kycService;
        private readonly ITransactionService _transactionService;

        public P2PController(
            ILogger<P2PController> logger,
            IP2PService p2pService,
            IKycService kycService,
            ITransactionService transactionService)
        {
            _logger = logger;
            _p2pService = p2pService;
            _kycService = kycService;
            _transactionService = transactionService;
        }

        [HttpGet("listings")]
        public async Task<IActionResult> GetP2PListings([FromQuery] P2PListingQueryParams queryParams)
        {
            try
            {
                var listings = await _p2pService.GetListings(queryParams);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving P2P listings");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create-listing")]
        [KycVerification]
        public async Task<IActionResult> CreateP2PListing([FromBody] P2PListingRequest request)
        {
            try
            {
                var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var listing = await _p2pService.CreateListing(request);
                return Ok(listing);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating P2P listing");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("trade")]
        [KycVerification]
        public async Task<IActionResult> ExecuteP2PTrade([FromBody] P2PTradeRequest request)
        {
            try
            {
                var result = await _p2pService.ExecuteTrade(request);
                await _transactionService.RecordP2PTransaction(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing P2P trade");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("trades")]
        public async Task<IActionResult> GetUserTrades([FromQuery] TransactionQueryParams queryParams)
        {
            try
            {
                var userId = User.GetUserId();
                var trades = await _p2pService.GetUserTrades(userId, queryParams);
                return Ok(trades);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user trades");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("cancel-listing")]
        public async Task<IActionResult> CancelP2PListing([FromBody] CancelListingRequest request)
        {
            try
            {
                var result = await _p2pService.CancelListing(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error canceling P2P listing");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetP2PStatistics()
        {
            try
            {
                var stats = await _p2pService.GetP2PStats();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving P2P statistics");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
