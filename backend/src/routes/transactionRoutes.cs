using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Controllers;
using MayaExchange.Models;
using MayaExchange.Services;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionRoutes : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IKycService _kycService;

        public TransactionRoutes(ITransactionService transactionService, IKycService kycService)
        {
            _transactionService = transactionService;
            _kycService = kycService;
        }

        [HttpGet]
        [Authorize]
        [Route("history")]
        public async Task<IActionResult> GetTransactionHistory()
        {
            try
            {
                var userId = User.Identity.Name;
                var transactions = await _transactionService.GetUserTransactions(userId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("send")]
        public async Task<IActionResult> SendTransaction([FromBody] TransactionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.CheckKycStatus(userId);
                
                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required");
                }

                var result = await _transactionService.ProcessSendTransaction(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("receive")]
        public async Task<IActionResult> ReceiveTransaction([FromBody] TransactionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.CheckKycStatus(userId);

                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required");
                }

                var result = await _transactionService.ProcessReceiveTransaction(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] ConversionRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var kycStatus = await _kycService.CheckKycStatus(userId);

                if (!kycStatus.IsVerified)
                {
                    return BadRequest("KYC verification required");
                }

                var result = await _transactionService.ProcessCurrencyConversion(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
