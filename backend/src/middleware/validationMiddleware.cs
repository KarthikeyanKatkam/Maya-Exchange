using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Maya.Exchange.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ValidationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Validate request headers
            if (!ValidateHeaders(context.Request.Headers))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid headers");
                return;
            }

            // Validate API key if required
            if (!await ValidateApiKey(context))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API key");
                return;
            }

            // KYC validation middleware
            if (!await ValidateKYC(context))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("KYC verification required");
                return;
            }

            // Transaction validation
            if (context.Request.Path.StartsWithSegments("/api/transactions"))
            {
                if (!await ValidateTransaction(context))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid transaction parameters");
                    return;
                }
            }

            // Currency conversion validation
            if (context.Request.Path.StartsWithSegments("/api/convert"))
            {
                if (!ValidateCurrencyConversion(context))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid currency conversion parameters");
                    return;
                }
            }

            await _next(context);
        }

        private bool ValidateHeaders(IHeaderDictionary headers)
        {
            return headers.ContainsKey("Content-Type") && 
                   headers["Content-Type"].ToString().ToLower().Contains("application/json");
        }

        private async Task<bool> ValidateApiKey(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-Key", out var apiKey))
                return false;

            // TODO: Implement API key validation against database/configuration
            return true;
        }

        private async Task<bool> ValidateKYC(HttpContext context)
        {
            // Skip KYC check for public endpoints
            string[] publicEndpoints = { "/api/auth/login", "/api/auth/register", "/api/public" };
            if (publicEndpoints.Any(endpoint => context.Request.Path.StartsWithSegments(endpoint)))
                return true;

            // TODO: Implement KYC validation logic
            // Check user KYC status from database
            return true;
        }

        private async Task<bool> ValidateTransaction(HttpContext context)
        {
            // TODO: Implement transaction validation logic
            // - Check transaction limits
            // - Validate wallet addresses
            // - Check sufficient balance
            return true;
        }

        private bool ValidateCurrencyConversion(HttpContext context)
        {
            // TODO: Implement currency conversion validation
            // - Check supported currencies
            // - Validate conversion rates
            // - Check conversion limits
            return true;
        }
    }

    // Extension method for middleware registration
    public static class ValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
