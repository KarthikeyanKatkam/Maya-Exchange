using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Services;
using MayaExchange.Models;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/visa-card")]
    public class MayaVisaCardRoutes : ControllerBase
    {
        private readonly IVisaCardService _visaCardService;
        private readonly IKycService _kycService;
        private readonly IAuthorizationService _authService;

        public MayaVisaCardRoutes(
            IVisaCardService visaCardService,
            IKycService kycService, 
            IAuthorizationService authService)
        {
            _visaCardService = visaCardService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpPost("issue")]
        [Authorize]
        public async Task<IActionResult> IssueVisaCard([FromBody] VisaCardRequest request)
        {
            try {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (kycStatus != KycStatus.Verified) {
                    return BadRequest("KYC verification required for card issuance");
                }

                var card = await _visaCardService.IssueCard(userId, request);
                return Ok(card);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("details")]
        [Authorize] 
        public async Task<IActionResult> GetCardDetails()
        {
            try {
                var userId = User.Identity.Name;
                var cardDetails = await _visaCardService.GetCardDetails(userId);
                return Ok(cardDetails);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("activate")]
        [Authorize]
        public async Task<IActionResult> ActivateCard([FromBody] CardActivationRequest request)
        {
            try {
                var userId = User.Identity.Name;
                await _visaCardService.ActivateCard(userId, request.CardId);
                return Ok("Card activated successfully");
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("block")]
        [Authorize]
        public async Task<IActionResult> BlockCard([FromBody] CardBlockRequest request)
        {
            try {
                var userId = User.Identity.Name;
                await _visaCardService.BlockCard(userId, request.CardId, request.Reason);
                return Ok("Card blocked successfully");
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("transactions")]
        [Authorize]
        public async Task<IActionResult> GetCardTransactions([FromQuery] TransactionQueryParams queryParams)
        {
            try {
                var userId = User.Identity.Name;
                var transactions = await _visaCardService.GetTransactions(userId, queryParams);
                return Ok(transactions);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("limits")]
        [Authorize]
        public async Task<IActionResult> UpdateCardLimits([FromBody] CardLimitUpdateRequest request)
        {
            try {
                var userId = User.Identity.Name;
                await _visaCardService.UpdateCardLimits(userId, request);
                return Ok("Card limits updated successfully");
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
