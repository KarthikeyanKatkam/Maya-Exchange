using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Maya.Exchange.Api;
using Maya.Exchange.Models;
using Maya.Exchange.Services;

namespace Maya.Exchange.Tests.Integration
{
    public class DefiRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public DefiRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetDefiPools_ReturnsSuccessStatusCode()
        {
            // Arrange
            var response = await _client.GetAsync("/api/defi/pools");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task AddLiquidity_WithValidInput_ReturnsSuccess()
        {
            // Arrange
            var request = new AddLiquidityRequest
            {
                TokenA = "USDT",
                TokenB = "ETH",
                AmountA = 1000,
                AmountB = 1
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/defi/liquidity/add", request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task RemoveLiquidity_WithValidInput_ReturnsSuccess()
        {
            // Arrange
            var request = new RemoveLiquidityRequest
            {
                PoolId = "pool123",
                LpTokenAmount = 100
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/defi/liquidity/remove", request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Swap_WithValidInput_ReturnsSuccess()
        {
            // Arrange
            var request = new SwapRequest
            {
                TokenIn = "USDT",
                TokenOut = "ETH",
                AmountIn = 1000
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/defi/swap", request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetYieldFarms_ReturnsSuccessStatusCode()
        {
            // Arrange
            var response = await _client.GetAsync("/api/defi/farms");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task StakeTokens_WithValidInput_ReturnsSuccess()
        {
            // Arrange
            var request = new StakeRequest
            {
                FarmId = "farm123",
                Amount = 100
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/defi/stake", request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task UnstakeTokens_WithValidInput_ReturnsSuccess() 
        {
            // Arrange
            var request = new UnstakeRequest
            {
                FarmId = "farm123",
                Amount = 50
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/defi/unstake", request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
