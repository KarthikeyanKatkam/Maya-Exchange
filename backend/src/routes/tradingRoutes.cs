using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/trading")]
    public class TradingRoutes : ControllerBase
    {
        private readonly ITradingService _tradingService;
        private readonly IKycService _kycService;
        private readonly IAuthorizationService _authService;

        public TradingRoutes(
            ITradingService tradingService,
            IKycService kycService, 
            IAuthorizationService authService)
        {
            _tradingService = tradingService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpPost("convert")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> ConvertCurrency([FromBody] ConversionRequest request)
        {
            try {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.GetUserKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return Unauthorized("KYC verification required for trading");
                }

                var result = await _tradingService.ConvertCurrency(
                    userId,
                    request.SourceCurrency,
                    request.TargetCurrency, 
                    request.Amount
                );

                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("rates")]
        public async Task<IActionResult> GetExchangeRates()
        {
            try {
                var rates = await _tradingService.GetCurrentRates();
                return Ok(rates);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("order")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> PlaceOrder([FromBody] TradeOrder order)
        {
            try {
                var userId = User.Identity.Name;
                var result = await _tradingService.PlaceOrder(userId, order);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetTradingHistory()
        {
            try {
                var userId = User.Identity.Name;
                var history = await _tradingService.GetUserTradingHistory(userId);
                return Ok(history);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
