using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api.Controllers;
using Maya.Exchange.Api.Models;
using Maya.Exchange.Api.Services;

namespace Maya.Exchange.Tests.Unit
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _controller = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new RegisterRequest
            {
                Email = "test@example.com",
                Password = "Test123!@#",
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "+1234567890"
            };

            _authServiceMock.Setup(x => x.RegisterUser(It.IsAny<RegisterRequest>()))
                .ReturnsAsync(new UserResponse { Id = "test-id", Email = request.Email });

            // Act
            var result = await _controller.Register(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<UserResponse>(okResult.Value);
            response.Email.Should().Be(request.Email);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var request = new LoginRequest
            {
                Email = "test@example.com",
                Password = "Test123!@#"
            };

            var authResponse = new AuthResponse
            {
                Token = "test-token",
                RefreshToken = "refresh-token",
                ExpiresIn = 3600
            };

            _authServiceMock.Setup(x => x.LoginUser(It.IsAny<LoginRequest>()))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Login(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AuthResponse>(okResult.Value);
            response.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task RefreshToken_ValidToken_ReturnsNewToken()
        {
            // Arrange
            var request = new RefreshTokenRequest
            {
                RefreshToken = "valid-refresh-token"
            };

            var authResponse = new AuthResponse
            {
                Token = "new-token",
                RefreshToken = "new-refresh-token",
                ExpiresIn = 3600
            };

            _authServiceMock.Setup(x => x.RefreshToken(It.IsAny<string>()))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.RefreshToken(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AuthResponse>(okResult.Value);
            response.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task VerifyEmail_ValidToken_ReturnsOk()
        {
            // Arrange
            var token = "valid-verification-token";

            _authServiceMock.Setup(x => x.VerifyEmail(It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.VerifyEmail(token);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ForgotPassword_ValidEmail_ReturnsOk()
        {
            // Arrange
            var request = new ForgotPasswordRequest
            {
                Email = "test@example.com"
            };

            _authServiceMock.Setup(x => x.ForgotPassword(It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.ForgotPassword(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ResetPassword_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new ResetPasswordRequest
            {
                Token = "valid-reset-token",
                NewPassword = "NewTest123!@#"
            };

            _authServiceMock.Setup(x => x.ResetPassword(It.IsAny<ResetPasswordRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.ResetPassword(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
