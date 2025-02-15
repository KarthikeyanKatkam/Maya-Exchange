using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Maya.Exchange.Tests.Integration
{
    public class TransactionRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TransactionRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetTransactionHistory_ReturnsOk()
        {
            // Arrange
            var userId = "testUserId";

            // Act
            var response = await _client.GetAsync($"/api/transactions/history/{userId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateTransaction_ValidData_ReturnsCreated()
        {
            // Arrange
            var transaction = new
            {
                UserId = "testUserId",
                Type = "SEND",
                Amount = 100.00m,
                Currency = "USD",
                DestinationAddress = "0x123456789",
                Status = "PENDING"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(transaction),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync("/api/transactions", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task ConvertCurrency_ValidRequest_ReturnsOk()
        {
            // Arrange
            var conversion = new
            {
                UserId = "testUserId",
                FromCurrency = "USD",
                ToCurrency = "BTC",
                Amount = 1000.00m
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(conversion),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync("/api/transactions/convert", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetTransactionStatus_ValidId_ReturnsOk()
        {
            // Arrange
            var transactionId = "testTransactionId";

            // Act
            var response = await _client.GetAsync($"/api/transactions/status/{transactionId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CancelTransaction_ValidId_ReturnsOk()
        {
            // Arrange
            var transactionId = "testTransactionId";

            // Act
            var response = await _client.DeleteAsync($"/api/transactions/{transactionId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
