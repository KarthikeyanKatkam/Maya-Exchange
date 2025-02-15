using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Middleware
{
    public class UpiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IUpiService _upiService;
        private readonly IKycService _kycService;
        private readonly ILogger<UpiMiddleware> _logger;

        public UpiMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            IUpiService upiService,
            IKycService kycService,
            ILogger<UpiMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _upiService = upiService;
            _kycService = kycService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Path.StartsWithSegments("/api/upi"))
                {
                    // Validate UPI transaction limits
                    if (context.Request.Method == "POST" && context.Request.Path.Value.EndsWith("/send"))
                    {
                        var request = await context.Request.ReadFromJsonAsync<UpiTransactionRequest>();
                        
                        // Check daily transaction limits
                        var dailyLimit = decimal.Parse(_configuration["Upi:DailyTransactionLimit"]);
                        var dailyTotal = await _upiService.GetDailyTransactionTotal(request.SenderId);
                        
                        if (dailyTotal + request.Amount > dailyLimit)
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsJsonAsync(new { 
                                message = "Daily UPI transaction limit exceeded" 
                            });
                            return;
                        }

                        // Validate KYC status
                        var kycStatus = await _kycService.ValidateKycStatus(request.SenderId);
                        if (!kycStatus.IsValid)
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            await context.Response.WriteAsJsonAsync(new { 
                                message = "KYC validation required for UPI transactions" 
                            });
                            return;
                        }

                        // Validate UPI ID format
                        if (!await _upiService.ValidateUpiId(request.ReceiverUpiId))
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsJsonAsync(new { 
                                message = "Invalid UPI ID format" 
                            });
                            return;
                        }
                    }
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UPI middleware");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { 
                    message = "An error occurred processing the UPI request" 
                });
            }
        }
    }
}
