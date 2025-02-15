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
    [Route("api/p2p")]
    public class MayaP2PRoutes : ControllerBase
    {
        private readonly IP2PService _p2pService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public MayaP2PRoutes(
            IP2PService p2pService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _p2pService = p2pService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpGet("offers")]
        [Authorize]
        public async Task<IActionResult> GetP2POffers()
        {
            try
            {
                var offers = await _p2pService.GetAllOffersAsync();
                return Ok(offers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("offers")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> CreateP2POffer([FromBody] P2POffer offer)
        {
            try
            {
                var userId = User.Identity.Name;
                var createdOffer = await _p2pService.CreateOfferAsync(userId, offer);
                return CreatedAtAction(nameof(GetP2POfferById), new { id = createdOffer.Id }, createdOffer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("offers/{id}")]
        [Authorize]
        public async Task<IActionResult> GetP2POfferById(string id)
        {
            try
            {
                var offer = await _p2pService.GetOfferByIdAsync(id);
                if (offer == null)
                    return NotFound();
                return Ok(offer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("trades")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> CreateP2PTrade([FromBody] P2PTradeRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var trade = await _p2pService.CreateTradeAsync(userId, request);
                return Ok(trade);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("trades")]
        [Authorize]
        public async Task<IActionResult> GetUserTrades()
        {
            try
            {
                var userId = User.Identity.Name;
                var trades = await _p2pService.GetUserTradesAsync(userId);
                return Ok(trades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("trades/{tradeId}/complete")]
        [Authorize]
        public async Task<IActionResult> CompleteP2PTrade(string tradeId)
        {
            try
            {
                var userId = User.Identity.Name;
                await _p2pService.CompleteTradeAsync(userId, tradeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("trades/{tradeId}/cancel")]
        [Authorize]
        public async Task<IActionResult> CancelP2PTrade(string tradeId)
        {
            try
            {
                var userId = User.Identity.Name;
                await _p2pService.CancelTradeAsync(userId, tradeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
