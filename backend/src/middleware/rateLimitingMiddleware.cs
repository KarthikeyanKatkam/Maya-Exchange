using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Maya.Exchange.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly ConcurrentDictionary<string, DateTime> _lastRequestTimes;
        private readonly RateLimitingOptions _options;

        public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache, IOptions<RateLimitingOptions> options)
        {
            _next = next;
            _cache = cache;
            _lastRequestTimes = new ConcurrentDictionary<string, DateTime>();
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            var endpoint = context.Request.Path.ToString();
            var cacheKey = $"{ipAddress}:{endpoint}";

            // Check if request is within rate limit
            if (!IsWithinRateLimit(cacheKey))
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Rate limit exceeded. Please try again later.");
                return;
            }

            await _next(context);
        }

        private bool IsWithinRateLimit(string cacheKey)
        {
            var now = DateTime.UtcNow;

            // Get last request time
            if (!_lastRequestTimes.TryGetValue(cacheKey, out DateTime lastRequestTime))
            {
                _lastRequestTimes[cacheKey] = now;
                return true;
            }

            // Check if enough time has passed since last request
            var timeSinceLastRequest = now - lastRequestTime;
            if (timeSinceLastRequest < TimeSpan.FromSeconds(_options.TimeWindowSeconds))
            {
                // Get current request count
                var requestCount = _cache.GetOrCreate(cacheKey, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_options.TimeWindowSeconds);
                    return 1;
                });

                if (requestCount > _options.MaxRequests)
                {
                    return false;
                }

                _cache.Set(cacheKey, requestCount + 1);
            }
            else
            {
                // Reset counter for new time window
                _cache.Set(cacheKey, 1);
            }

            _lastRequestTimes[cacheKey] = now;
            return true;
        }
    }

    public class RateLimitingOptions
    {
        public int MaxRequests { get; set; } = 100;
        public int TimeWindowSeconds { get; set; } = 60;
    }

    public static class RateLimitingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitingMiddleware>();
        }
    }
}
