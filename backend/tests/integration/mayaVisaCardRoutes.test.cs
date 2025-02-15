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
    public class MayaVisaCardRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public MayaVisaCardRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetVisaCardDetails_ReturnsSuccessStatusCode()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/visa-cards/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task IssueVisaCard_WithValidData_ReturnsCreatedStatusCode()
        {
            // Arrange
            var endpoint = "/api/visa-cards";
            var request = new VisaCardRequest
            {
                UserId = "test-user-id",
                CardType = "VIRTUAL",
                Currency = "USD",
                KycStatus = "VERIFIED"
            };

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task BlockVisaCard_WithValidId_ReturnsOkStatusCode()
        {
            // Arrange
            var cardId = Guid.NewGuid();
            var endpoint = $"/api/visa-cards/{cardId}/block";

            // Act
            var response = await _client.PutAsync(endpoint, null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetTransactionHistory_ReturnsSuccessStatusCode()
        {
            // Arrange
            var cardId = Guid.NewGuid();
            var endpoint = $"/api/visa-cards/{cardId}/transactions";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
