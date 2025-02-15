using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Maya.Exchange.Models;
using Maya.Exchange.Services;

namespace Maya.Exchange.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ILogger<AuthMiddleware> _logger;

        public AuthMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            IUserService userService,
            ILogger<AuthMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _userService = userService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

                    // Verify user exists and is active
                    var user = await _userService.GetUserById(userId);
                    if (user == null || !user.IsActive)
                    {
                        throw new SecurityTokenException("Invalid user");
                    }

                    // Add user to context
                    var claims = new List<Claim>
                    {
                        new Claim("id", userId),
                        new Claim("email", user.Email),
                        new Claim("role", user.Role)
                    };

                    var identity = new ClaimsIdentity(claims);
                    context.User = new ClaimsPrincipal(identity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Authentication failed: {ex.Message}");
                // Continue without setting user context
            }

            await _next(context);
        }
    }

    // Extension method to register the middleware
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
