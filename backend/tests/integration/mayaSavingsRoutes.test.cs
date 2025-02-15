using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Maya.Tests.Integration
{
    public class MayaSavingsRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public MayaSavingsRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task CreateSavingsAccount_ValidRequest_ReturnsCreated()
        {
            // Arrange
            var request = new
            {
                UserId = "testUser123",
                Currency = "USD",
                InitialDeposit = 1000.00m
            };

            // Act
            var response = await _client.PostAsync("/api/savings/create", 
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetSavingsBalance_ValidAccount_ReturnsBalance()
        {
            // Arrange
            var accountId = "TEST-SAV-001";

            // Act
            var response = await _client.GetAsync($"/api/savings/balance/{accountId}");
            var content = await response.Content.ReadAsStringAsync();
            var balance = JsonConvert.DeserializeObject<decimal>(content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(balance >= 0);
        }

        [Fact]
        public async Task DepositToSavings_ValidAmount_ReturnsSuccess()
        {
            // Arrange
            var request = new
            {
                AccountId = "TEST-SAV-001",
                Amount = 500.00m,
                Currency = "USD"
            };

            // Act
            var response = await _client.PostAsync("/api/savings/deposit",
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WithdrawFromSavings_ValidAmount_ReturnsSuccess()
        {
            // Arrange
            var request = new
            {
                AccountId = "TEST-SAV-001",
                Amount = 100.00m,
                Currency = "USD"
            };

            // Act
            var response = await _client.PostAsync("/api/savings/withdraw",
                new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetInterestRate_ValidAccount_ReturnsRate()
        {
            // Arrange
            var accountId = "TEST-SAV-001";

            // Act
            var response = await _client.GetAsync($"/api/savings/interest-rate/{accountId}");
            var content = await response.Content.ReadAsStringAsync();
            var rate = JsonConvert.DeserializeObject<decimal>(content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(rate > 0);
        }

        [Fact]
        public async Task GetTransactionHistory_ValidAccount_ReturnsTransactions()
        {
            // Arrange
            var accountId = "TEST-SAV-001";

            // Act
            var response = await _client.GetAsync($"/api/savings/transactions/{accountId}");
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
