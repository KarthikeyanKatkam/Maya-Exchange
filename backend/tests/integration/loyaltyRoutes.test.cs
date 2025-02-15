using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Models;
using Maya.Exchange.Services;

namespace Maya.Exchange.Tests.Integration
{
    public class LoyaltyRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public LoyaltyRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetLoyaltyPoints_ReturnsOkResult()
        {
            // Arrange
            var userId = "test-user-id";

            // Act
            var response = await _client.GetAsync($"/api/loyalty/points/{userId}");
            var result = await response.Content.ReadAsAsync<int>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async Task EarnPoints_WithValidTransaction_ReturnsSuccess()
        {
            // Arrange
            var request = new LoyaltyPointsRequest
            {
                UserId = "test-user-id",
                TransactionAmount = 1000,
                TransactionType = "CRYPTO_PURCHASE"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/loyalty/earn", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var points = await response.Content.ReadAsAsync<int>();
            points.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task RedeemPoints_WithSufficientBalance_ReturnsSuccess()
        {
            // Arrange
            var request = new RedeemPointsRequest
            {
                UserId = "test-user-id",
                PointsToRedeem = 100,
                RewardType = "TRADING_FEE_DISCOUNT"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/loyalty/redeem", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetLoyaltyTiers_ReturnsAllTiers()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/api/loyalty/tiers");
            var tiers = await response.Content.ReadAsAsync<LoyaltyTier[]>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            tiers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetUserTier_ReturnsCorrectTier()
        {
            // Arrange
            var userId = "test-user-id";

            // Act
            var response = await _client.GetAsync($"/api/loyalty/user-tier/{userId}");
            var tier = await response.Content.ReadAsAsync<LoyaltyTier>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            tier.Should().NotBeNull();
            tier.Requirements.Should().NotBeNull();
            tier.Benefits.Should().NotBeNull();
        }
    }
}
