using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MayaExchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        private readonly ILogger<CryptoController> _logger;

        public CryptoController(ICryptoService cryptoService, ILogger<CryptoController> logger)
        {
            _cryptoService = cryptoService;
            _logger = logger;
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetCryptoBalance()
        {
            try
            {
                var balance = await _cryptoService.GetUserCryptoBalance();
                return Ok(balance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving crypto balance");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendCrypto([FromBody] CryptoTransactionRequest request)
        {
            try
            {
                await _cryptoService.SendCrypto(request);
                return Ok(new { message = "Crypto sent successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending crypto");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveCrypto([FromBody] CryptoReceiveRequest request)
        {
            try
            {
                var address = await _cryptoService.GenerateReceiveAddress(request);
                return Ok(new { address = address });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating receive address");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCrypto([FromBody] CryptoConversionRequest request)
        {
            try
            {
                var result = await _cryptoService.ConvertCrypto(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting crypto");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactionHistory([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var transactions = await _cryptoService.GetTransactionHistory(startDate, endDate);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving transaction history");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("rates")]
        public async Task<IActionResult> GetExchangeRates()
        {
            try
            {
                var rates = await _cryptoService.GetCurrentExchangeRates();
                return Ok(rates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving exchange rates");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("supported-currencies")]
        public async Task<IActionResult> GetSupportedCurrencies()
        {
            try
            {
                var currencies = await _cryptoService.GetSupportedCryptoCurrencies();
                return Ok(currencies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving supported currencies");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
