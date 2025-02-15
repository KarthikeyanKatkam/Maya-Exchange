using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Maya.Exchange.Models;
using Maya.Exchange.Services;
using Maya.Exchange.Controllers;

namespace Maya.Exchange.Routes
{
    [ApiController]
    [Route("api/charity")]
    public class MayaCharityFoundationRoutes : ControllerBase
    {
        private readonly ICharityService _charityService;
        private readonly IKycService _kycService;
        private readonly ITransactionService _transactionService;

        public MayaCharityFoundationRoutes(
            ICharityService charityService,
            IKycService kycService, 
            ITransactionService transactionService)
        {
            _charityService = charityService;
            _kycService = kycService;
            _transactionService = transactionService;
        }

        [HttpGet("campaigns")]
        public async Task<IActionResult> GetCharityCampaigns()
        {
            try
            {
                var campaigns = await _charityService.GetActiveCampaigns();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("donate")]
        [Authorize]
        public async Task<IActionResult> MakeDonation([FromBody] DonationRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required for donations");
                }

                var donation = await _charityService.ProcessDonation(userId, request);
                await _transactionService.RecordDonationTransaction(donation);
                
                return Ok(new { message = "Donation processed successfully", transactionId = donation.TransactionId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetDonationHistory()
        {
            try
            {
                var userId = User.Identity.Name;
                var history = await _charityService.GetUserDonationHistory(userId);
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("impact")]
        public async Task<IActionResult> GetCharityImpact()
        {
            try
            {
                var impact = await _charityService.GetCharityImpactMetrics();
                return Ok(impact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("campaign/subscribe")]
        [Authorize]
        public async Task<IActionResult> SubscribeToCampaign([FromBody] CampaignSubscriptionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var subscription = await _charityService.SubscribeUserToCampaign(userId, request);
                return Ok(subscription);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
