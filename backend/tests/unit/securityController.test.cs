using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MayaExchange.Controllers;
using MayaExchange.Services;
using MayaExchange.Models;

namespace MayaExchange.Tests.Unit
{
    public class SecurityControllerTests
    {
        private readonly Mock<ISecurityService> _mockSecurityService;
        private readonly SecurityController _controller;

        public SecurityControllerTests()
        {
            _mockSecurityService = new Mock<ISecurityService>();
            _controller = new SecurityController(_mockSecurityService.Object);
        }

        [Fact]
        public async Task EnableTwoFactor_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new TwoFactorRequest
            {
                UserId = "test-user-id",
                PhoneNumber = "+1234567890"
            };

            _mockSecurityService
                .Setup(x => x.EnableTwoFactorAsync(It.IsAny<TwoFactorRequest>()))
                .ReturnsAsync(new TwoFactorResponse { Success = true, SecretKey = "test-secret" });

            // Act
            var result = await _controller.EnableTwoFactor(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<TwoFactorResponse>(okResult.Value);
            Assert.True(response.Success);
            Assert.NotNull(response.SecretKey);
        }

        [Fact]
        public async Task VerifyTwoFactor_ValidCode_ReturnsOkResult()
        {
            // Arrange
            var request = new VerifyTwoFactorRequest
            {
                UserId = "test-user-id",
                Code = "123456"
            };

            _mockSecurityService
                .Setup(x => x.VerifyTwoFactorAsync(It.IsAny<VerifyTwoFactorRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.VerifyTwoFactor(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task UpdateSecuritySettings_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new SecuritySettingsRequest
            {
                UserId = "test-user-id",
                EnableEmailAlerts = true,
                EnableSmsAlerts = true,
                RequireTwoFactorForWithdrawals = true
            };

            _mockSecurityService
                .Setup(x => x.UpdateSecuritySettingsAsync(It.IsAny<SecuritySettingsRequest>()))
                .ReturnsAsync(new SecuritySettings { UserId = request.UserId });

            // Act
            var result = await _controller.UpdateSecuritySettings(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var settings = Assert.IsType<SecuritySettings>(okResult.Value);
            Assert.Equal(request.UserId, settings.UserId);
        }
    }
}
