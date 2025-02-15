using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MayaExchange.Models;
using MayaExchange.Exceptions;

namespace MayaExchange.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterUserAsync(RegisterRequest request);
        Task<AuthResult> LoginAsync(LoginRequest request);
        Task<AuthResult> RefreshTokenAsync(string refreshToken);
        Task<bool> RevokeTokenAsync(string userId);
        Task<bool> ValidateTokenAsync(string token);
        Task<UserProfile> GetUserProfileAsync(string userId);
        Task<bool> UpdateUserProfileAsync(string userId, UserProfile profile);
        Task<bool> ChangePasswordAsync(string userId, ChangePasswordRequest request);
        Task<bool> RequestPasswordResetAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IKycService _kycService;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IKycService kycService,
            IEmailService emailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _kycService = kycService;
            _emailService = emailService;
        }

        public async Task<AuthResult> RegisterUserAsync(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new DuplicateResourceException("User with this email already exists");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new ValidationException("User registration failed");
            }

            await _kycService.InitiateKycProcess(user.Id);
            await _emailService.SendWelcomeEmailAsync(user.Email);

            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(user.Id);

            return new AuthResult
            {
                Token = token,
                RefreshToken = refreshToken,
                UserId = user.Id
            };
        }

        public async Task<AuthResult> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValid)
            {
                throw new UnauthorizedException("Invalid credentials");
            }

            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(user.Id);

            return new AuthResult
            {
                Token = token,
                RefreshToken = refreshToken,
                UserId = user.Id
            };
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken(string userId)
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
