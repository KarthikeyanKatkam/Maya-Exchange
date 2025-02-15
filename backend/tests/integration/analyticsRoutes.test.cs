using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using MayaExchange.Tests.Helpers;
using MayaExchange.Models;
using MayaExchange.Services;

namespace MayaExchange.Tests.Integration
{
    public class AnalyticsRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AnalyticsRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetTransactionAnalytics_ReturnsOkResult()
        {
            // Arrange
            var endpoint = "/api/analytics/transactions";

            // Act
            var response = await _client.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetUserAnalytics_ReturnsOkResult()
        {
            // Arrange
            var endpoint = "/api/analytics/users";

            // Act
            var response = await _client.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetCurrencyConversionAnalytics_ReturnsOkResult()
        {
            // Arrange
            var endpoint = "/api/analytics/conversions";

            // Act
            var response = await _client.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetKYCAnalytics_ReturnsOkResult()
        {
            // Arrange
            var endpoint = "/api/analytics/kyc";

            // Act
            var response = await _client.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetTradingVolumeAnalytics_ReturnsOkResult()
        {
            // Arrange
            var endpoint = "/api/analytics/trading-volume";

            // Act
            var response = await _client.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }
    }
}
