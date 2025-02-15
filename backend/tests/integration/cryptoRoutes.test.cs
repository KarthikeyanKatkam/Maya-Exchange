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
    public class CryptoRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public CryptoRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCryptoPrice_ReturnsOkResult()
        {
            // Arrange
            var cryptoSymbol = "BTC";

            // Act
            var response = await _client.GetAsync($"/api/crypto/price/{cryptoSymbol}");

            // Assert
            response.EnsureSuccessStatusCode();
            var price = await response.Content.ReadAsAsync<decimal>();
            price.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ConvertCrypto_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new CryptoConversionRequest
            {
                FromCurrency = "BTC",
                ToCurrency = "ETH",
                Amount = 1.0m
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/crypto/convert", request);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<CryptoConversionResult>();
            result.ConvertedAmount.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task SendCrypto_WithValidKYC_ReturnsOkResult()
        {
            // Arrange
            var request = new CryptoTransferRequest
            {
                ToAddress = "0x742d35Cc6634C0532925a3b844Bc454e4438f44e",
                Amount = 0.1m,
                CryptoSymbol = "ETH"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/crypto/send", request);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<TransactionResult>();
            result.TransactionId.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ReceiveCrypto_GeneratesValidAddress()
        {
            // Arrange
            var cryptoSymbol = "BTC";

            // Act
            var response = await _client.GetAsync($"/api/crypto/receive/{cryptoSymbol}");

            // Assert
            response.EnsureSuccessStatusCode();
            var address = await response.Content.ReadAsAsync<string>();
            address.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetTransactionHistory_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/crypto/transactions");

            // Assert
            response.EnsureSuccessStatusCode();
            var transactions = await response.Content.ReadAsAsync<TransactionHistory[]>();
            transactions.Should().NotBeNull();
        }
    }
}
