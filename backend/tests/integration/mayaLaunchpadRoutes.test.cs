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
    public class MayaLaunchpadRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public MayaLaunchpadRoutesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetLaunchpadProjects_ReturnsOkResponse()
        {
            // Arrange
            var endpoint = "/api/launchpad/projects";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateLaunchpadProject_WithValidData_ReturnsCreated()
        {
            // Arrange
            var endpoint = "/api/launchpad/projects";
            var project = TestDataHelper.CreateSampleLaunchpadProject();

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, project);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetLaunchpadProjectDetails_WithValidId_ReturnsOkResponse()
        {
            // Arrange
            var projectId = "test-project-id";
            var endpoint = $"/api/launchpad/projects/{projectId}";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ParticipateInLaunchpad_WithValidKYC_ReturnsOkResponse()
        {
            // Arrange
            var projectId = "test-project-id";
            var endpoint = $"/api/launchpad/projects/{projectId}/participate";
            var participation = new LaunchpadParticipation
            {
                UserId = "test-user-id",
                Amount = 1000,
                Currency = "USDT"
            };

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, participation);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetUserParticipations_ReturnsOkResponse()
        {
            // Arrange
            var userId = "test-user-id";
            var endpoint = $"/api/launchpad/users/{userId}/participations";

            // Act
            var response = await _client.GetAsync(endpoint);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task VerifyKYC_WithValidDocuments_ReturnsOkResponse()
        {
            // Arrange
            var endpoint = "/api/launchpad/kyc/verify";
            var kycData = TestDataHelper.CreateSampleKYCData();

            // Act
            var response = await _client.PostAsJsonAsync(endpoint, kycData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
