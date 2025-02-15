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
    public class SettingsControllerTests
    {
        private readonly Mock<ISettingsService> _mockSettingsService;
        private readonly SettingsController _controller;

        public SettingsControllerTests()
        {
            _mockSettingsService = new Mock<ISettingsService>();
            _controller = new SettingsController(_mockSettingsService.Object);
        }

        [Fact]
        public async Task GetUserSettings_ReturnsOkResult_WhenSettingsExist()
        {
            // Arrange
            var userId = "testUserId";
            var settings = new UserSettings 
            { 
                UserId = userId,
                Language = "en",
                Theme = "light",
                NotificationsEnabled = true,
                TwoFactorEnabled = true,
                KycLevel = "advanced"
            };

            _mockSettingsService.Setup(x => x.GetUserSettingsAsync(userId))
                .ReturnsAsync(settings);

            // Act
            var result = await _controller.GetUserSettings(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSettings = Assert.IsType<UserSettings>(okResult.Value);
            Assert.Equal(settings.Language, returnedSettings.Language);
            Assert.Equal(settings.Theme, returnedSettings.Theme);
        }

        [Fact]
        public async Task UpdateUserSettings_ReturnsOkResult_WhenUpdateSuccessful()
        {
            // Arrange
            var userId = "testUserId";
            var updateSettings = new UserSettings
            {
                UserId = userId,
                Language = "es",
                Theme = "dark",
                NotificationsEnabled = false,
                TwoFactorEnabled = true,
                KycLevel = "advanced"
            };

            _mockSettingsService.Setup(x => x.UpdateUserSettingsAsync(userId, updateSettings))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateUserSettings(userId, updateSettings);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetKycSettings_ReturnsOkResult_WhenKycSettingsExist()
        {
            // Arrange
            var userId = "testUserId";
            var kycSettings = new KycSettings
            {
                UserId = userId,
                VerificationStatus = "verified",
                DocumentsSubmitted = true,
                VerificationLevel = 2,
                LastUpdated = DateTime.UtcNow
            };

            _mockSettingsService.Setup(x => x.GetKycSettingsAsync(userId))
                .ReturnsAsync(kycSettings);

            // Act
            var result = await _controller.GetKycSettings(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSettings = Assert.IsType<KycSettings>(okResult.Value);
            Assert.Equal(kycSettings.VerificationStatus, returnedSettings.VerificationStatus);
            Assert.Equal(kycSettings.VerificationLevel, returnedSettings.VerificationLevel);
        }

        [Fact]
        public async Task UpdateSecuritySettings_ReturnsOkResult_WhenUpdateSuccessful()
        {
            // Arrange
            var userId = "testUserId";
            var securitySettings = new SecuritySettings
            {
                UserId = userId,
                TwoFactorEnabled = true,
                BiometricEnabled = true,
                LoginNotifications = true,
                TransactionNotifications = true
            };

            _mockSettingsService.Setup(x => x.UpdateSecuritySettingsAsync(userId, securitySettings))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateSecuritySettings(userId, securitySettings);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
