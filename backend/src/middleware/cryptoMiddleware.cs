using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Middleware
{
    public class CryptoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ICryptoService _cryptoService;
        private readonly ILogger<CryptoMiddleware> _logger;

        public CryptoMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            ICryptoService cryptoService,
            ILogger<CryptoMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _cryptoService = cryptoService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Validate crypto transaction limits
                if (context.Request.Path.StartsWithSegments("/api/crypto"))
                {
                    var userId = context.User.GetUserId();
                    var transactionLimit = await _cryptoService.GetUserTransactionLimit(userId);
                    
                    if (context.Request.Method == "POST")
                    {
                        var transaction = await GetTransactionFromBody(context.Request);
                        if (transaction.Amount > transactionLimit)
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsJsonAsync(new { 
                                message = "Transaction amount exceeds daily limit" 
                            });
                            return;
                        }
                    }
                }

                // Validate crypto address format
                if (context.Request.Query.ContainsKey("address"))
                {
                    var address = context.Request.Query["address"].ToString();
                    if (!_cryptoService.ValidateCryptoAddress(address))
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new { 
                            message = "Invalid crypto address format" 
                        });
                        return;
                    }
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in crypto middleware: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { 
                    message = "Internal server error" 
                });
            }
        }

        private async Task<CryptoTransaction> GetTransactionFromBody(HttpRequest request)
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<CryptoTransaction>(body);
        }
    }

    // Extension method to add the middleware to IApplicationBuilder
    public static class CryptoMiddlewareExtensions
    {
        public static IApplicationBuilder UseCryptoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CryptoMiddleware>();
        }
    }
}
