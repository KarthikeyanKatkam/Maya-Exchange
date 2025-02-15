using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api;
using Maya.Exchange.Models;
using Maya.Exchange.Tests.Helpers;

namespace Maya.Exchange.Tests.Integration
{
    public class SettingsRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public SettingsRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetUserSettings_ReturnsSuccessStatusCode()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/settings/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateUserSettings_WithValidData_ReturnsOkStatusCode()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/settings/{userId}";
            var settings = new UserSettingsUpdateRequest
            {
                Language = "en",
                Theme = "dark",
                NotificationsEnabled = true,
                TwoFactorEnabled = true,
                DefaultCurrency = "USD",
                TimeZone = "UTC"
            };

            // Act
            var response = await _client.PutAsJsonAsync(endpoint, settings);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateSecuritySettings_WithValidData_ReturnsOkStatusCode()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/settings/{userId}/security";
            var securitySettings = new SecuritySettingsUpdateRequest
            {
                PasswordChangeRequired = false,
                LoginNotifications = true,
                WithdrawalConfirmation = true,
                TradingConfirmation = true,
                WhitelistedIPs = new[] { "192.168.1.1" }
            };

            // Act
            var response = await _client.PutAsJsonAsync(endpoint, securitySettings);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateKycSettings_WithValidData_ReturnsOkStatusCode()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/settings/{userId}/kyc";
            var kycSettings = new KycSettingsUpdateRequest
            {
                AutomaticVerification = true,
                DocumentsRetentionPeriod = 90,
                RequiredDocuments = new[] { "PASSPORT", "PROOF_OF_ADDRESS" },
                VerificationLevel = "ADVANCED"
            };

            // Act
            var response = await _client.PutAsJsonAsync(endpoint, kycSettings);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
