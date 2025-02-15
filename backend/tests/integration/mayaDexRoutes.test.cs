using System;
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
    public class MayaDexRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public MayaDexRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetMarkets_ReturnsSuccessStatusCode()
        {
            // Arrange
            var endpoint = "/api/dex/markets";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateOrder_WithValidData_ReturnsCreatedResponse()
        {
            // Arrange
            var endpoint = "/api/dex/orders";
            var order = TestDataHelper.GenerateValidOrder();

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, order);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetOrderBook_ReturnsValidData()
        {
            // Arrange
            var marketId = "BTC-USDT";
            var endpoint = $"/api/dex/orderbook/{marketId}";

            // Act
            var response = await _client.GetAsync(endpoint);
            var orderBook = await response.Content.ReadFromJsonAsync<OrderBook>();

            // Assert
            response.EnsureSuccessStatusCode();
            orderBook.Should().NotBeNull();
            orderBook.Bids.Should().NotBeNull();
            orderBook.Asks.Should().NotBeNull();
        }

        [Fact]
        public async Task CancelOrder_WithValidId_ReturnsSuccessResponse()
        {
            // Arrange
            var orderId = Guid.NewGuid().ToString();
            var endpoint = $"/api/dex/orders/{orderId}";

            // Act
            var response = await _client.DeleteAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetUserTrades_WithValidUserId_ReturnsTradeHistory()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/dex/trades/user/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);
            var trades = await response.Content.ReadFromJsonAsync<TradeHistory>();

            // Assert
            response.EnsureSuccessStatusCode();
            trades.Should().NotBeNull();
            trades.Items.Should().NotBeNull();
        }

        [Fact]
        public async Task GetKycStatus_ReturnsValidStatus()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/kyc/status/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);
            var kycStatus = await response.Content.ReadFromJsonAsync<KycStatus>();

            // Assert
            response.EnsureSuccessStatusCode();
            kycStatus.Should().NotBeNull();
            kycStatus.Status.Should().BeOneOf("Pending", "Approved", "Rejected");
        }
    }
}
