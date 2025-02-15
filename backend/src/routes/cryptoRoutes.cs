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
    [Route("api/[controller]")]
    [Authorize]
    public class CryptoRoutes : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        private readonly ITransactionService _transactionService;

        public CryptoRoutes(ICryptoService cryptoService, ITransactionService transactionService)
        {
            _cryptoService = cryptoService;
            _transactionService = transactionService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendCrypto([FromBody] CryptoTransactionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _cryptoService.SendCrypto(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveCrypto([FromBody] CryptoReceiveRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _cryptoService.GenerateReceiveAddress(userId, request.Currency);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCrypto([FromBody] CryptoConversionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var result = await _cryptoService.ConvertCrypto(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance([FromQuery] string currency)
        {
            try
            {
                var userId = User.Identity.Name;
                var balance = await _cryptoService.GetBalance(userId, currency);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var userId = User.Identity.Name;
                var transactions = await _transactionService.GetUserTransactions(userId, startDate, endDate);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("exchange-rates")]
        public async Task<IActionResult> GetExchangeRates([FromQuery] string baseCurrency, [FromQuery] string quoteCurrency)
        {
            try
            {
                var rates = await _cryptoService.GetExchangeRates(baseCurrency, quoteCurrency);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("supported-currencies")]
        public async Task<IActionResult> GetSupportedCurrencies()
        {
            try
            {
                var currencies = await _cryptoService.GetSupportedCurrencies();
                return Ok(currencies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
