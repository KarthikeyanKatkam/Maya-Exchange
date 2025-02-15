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
    public class MayaCharityFoundationRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public MayaCharityFoundationRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCharityProjects_ReturnsSuccessStatusCode()
        {
            // Arrange
            var endpoint = "/api/charity/projects";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateDonation_WithValidData_ReturnsCreatedStatusCode()
        {
            // Arrange
            var endpoint = "/api/charity/donations";
            var donation = new CharityDonation
            {
                ProjectId = Guid.NewGuid(),
                Amount = 100.00m,
                Currency = "USD",
                DonorId = Guid.NewGuid()
            };

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, donation);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetDonationHistory_ReturnsSuccessStatusCode()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var endpoint = $"/api/charity/donations/history/{userId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task VerifyCharityKYC_WithValidData_ReturnsSuccessStatusCode()
        {
            // Arrange
            var endpoint = "/api/charity/kyc/verify";
            var kycData = new CharityKYCVerification
            {
                OrganizationId = Guid.NewGuid(),
                DocumentType = "Registration",
                DocumentNumber = "12345",
                VerificationStatus = "Pending"
            };

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, kycData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCharityMetrics_ReturnsSuccessStatusCode()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var endpoint = $"/api/charity/metrics/{projectId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
