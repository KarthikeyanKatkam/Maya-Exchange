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
    public class KycRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public KycRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task SubmitKyc_ValidData_ReturnsOk()
        {
            // Arrange
            var kycRequest = TestDataHelper.CreateValidKycRequest();

            // Act
            var response = await _client.PostAsJsonAsync("/api/kyc/submit", kycRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task SubmitKyc_InvalidData_ReturnsBadRequest()
        {
            // Arrange
            var kycRequest = TestDataHelper.CreateInvalidKycRequest();

            // Act
            var response = await _client.PostAsJsonAsync("/api/kyc/submit", kycRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetKycStatus_ValidUserId_ReturnsStatus()
        {
            // Arrange
            var userId = TestDataHelper.GetValidUserId();

            // Act
            var response = await _client.GetAsync($"/api/kyc/status/{userId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var status = await response.Content.ReadAsAsync<KycStatus>();
            status.Should().NotBeNull();
        }

        [Fact]
        public async Task UploadDocument_ValidDocument_ReturnsOk()
        {
            // Arrange
            var documentRequest = TestDataHelper.CreateValidDocumentRequest();

            // Act
            var response = await _client.PostAsJsonAsync("/api/kyc/document/upload", documentRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task VerifyAddress_ValidAddress_ReturnsOk()
        {
            // Arrange
            var addressRequest = TestDataHelper.CreateValidAddressVerificationRequest();

            // Act
            var response = await _client.PostAsJsonAsync("/api/kyc/address/verify", addressRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateKycLevel_ValidRequest_ReturnsOk()
        {
            // Arrange
            var updateRequest = TestDataHelper.CreateValidKycLevelUpdateRequest();

            // Act
            var response = await _client.PutAsJsonAsync("/api/kyc/level/update", updateRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
