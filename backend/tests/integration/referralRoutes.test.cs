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
    public class ReferralRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public ReferralRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateReferral_WithValidData_ReturnsCreatedStatusCode()
        {
            // Arrange
            var endpoint = "/api/referrals";
            var referral = new ReferralRequest
            {
                ReferrerId = Guid.NewGuid(),
                ReferredEmail = "newuser@example.com",
                ReferralCode = "REF123",
                ReferralType = "STANDARD"
            };

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, referral);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetReferralHistory_ReturnsSuccessStatusCode()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var endpoint = $"/api/referrals/history/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetReferralRewards_ReturnsSuccessStatusCode()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var endpoint = $"/api/referrals/rewards/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ValidateReferralCode_WithValidCode_ReturnsSuccessStatusCode()
        {
            // Arrange
            var referralCode = "REF123";
            var endpoint = $"/api/referrals/validate/{referralCode}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
