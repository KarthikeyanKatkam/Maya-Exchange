using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api;
using Maya.Exchange.Models;
using Maya.Exchange.Tests.Helpers;

namespace Maya.Exchange.Tests.Integration
{
    public class SecurityRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SecurityRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task KycEndpoint_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var kycRequest = new KycVerificationRequest
            {
                UserId = "test-user-id",
                DocumentType = "PASSPORT",
                DocumentNumber = "AB123456",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = "1990-01-01",
                Address = "123 Test St",
                Country = "US"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/kyc/verify", kycRequest);

            // Assert
            response.Should().BeSuccessful();
            var result = await response.Content.ReadAsAsync<KycVerificationResponse>();
            result.Status.Should().Be("PENDING");
        }

        [Fact]
        public async Task SecuritySettings_UpdateRequest_ReturnsSuccess()
        {
            // Arrange
            var settingsRequest = new SecuritySettingsRequest
            {
                UserId = "test-user-id",
                TwoFactorEnabled = true,
                EmailNotificationsEnabled = true,
                LoginNotificationsEnabled = true
            };

            // Act
            var response = await _client.PutAsJsonAsync("/api/security/settings", settingsRequest);

            // Assert
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task SecurityAudit_GetLogs_ReturnsAuditTrail()
        {
            // Arrange
            var userId = "test-user-id";

            // Act
            var response = await _client.GetAsync($"/api/security/audit/{userId}");

            // Assert
            response.Should().BeSuccessful();
            var auditLogs = await response.Content.ReadAsAsync<SecurityAuditLog[]>();
            auditLogs.Should().NotBeEmpty();
        }

        [Fact]
        public async Task AccessControl_InvalidToken_ReturnsUnauthorized()
        {
            // Arrange
            _client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "invalid-token");

            // Act
            var response = await _client.GetAsync("/api/security/protected");

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
