using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api.Controllers;
using Maya.Exchange.Api.Models;
using Maya.Exchange.Api.Services;
using Maya.Exchange.Api.Tests.Helpers;

namespace Maya.Exchange.Api.Tests.Unit
{
    public class AnalyticsControllerTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly IAnalyticsService _analyticsService;
        private readonly AnalyticsController _controller;

        public AnalyticsControllerTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = fixture.Client;
            _analyticsService = _server.Services.GetRequiredService<IAnalyticsService>();
            _controller = new AnalyticsController(_analyticsService);
        }

        [Fact]
        public async Task GetUserAnalytics_ValidUserId_ReturnsSuccess()
        {
            // Arrange
            var userId = "test-user-id";

            // Act
            var result = await _controller.GetUserAnalytics(userId);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(userId);
            result.TransactionCount.Should().BeGreaterOrEqual(0);
        }

        [Fact]
        public async Task GetTransactionMetrics_ValidDateRange_ReturnsMetrics()
        {
            // Arrange
            var startDate = DateTime.UtcNow.AddDays(-30);
            var endDate = DateTime.UtcNow;

            // Act
            var result = await _controller.GetTransactionMetrics(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.TotalTransactions.Should().BeGreaterOrEqual(0);
            result.TotalVolume.Should().BeGreaterOrEqual(0);
        }

        [Fact]
        public async Task GetKycAnalytics_ReturnsValidStats()
        {
            // Arrange & Act
            var result = await _controller.GetKycAnalytics();

            // Assert
            result.Should().NotBeNull();
            result.TotalVerified.Should().BeGreaterOrEqual(0);
            result.PendingVerifications.Should().BeGreaterOrEqual(0);
            result.RejectedVerifications.Should().BeGreaterOrEqual(0);
        }

        [Fact]
        public async Task GetCurrencyConversionStats_ValidPeriod_ReturnsStats()
        {
            // Arrange
            var period = "monthly";

            // Act
            var result = await _controller.GetCurrencyConversionStats(period);

            // Assert
            result.Should().NotBeNull();
            result.ConversionCount.Should().BeGreaterOrEqual(0);
            result.TotalVolumeUSD.Should().BeGreaterOrEqual(0);
        }

        [Fact]
        public async Task GetUserActivityMetrics_ValidTimeframe_ReturnsMetrics()
        {
            // Arrange
            var timeframe = "weekly";

            // Act
            var result = await _controller.GetUserActivityMetrics(timeframe);

            // Assert
            result.Should().NotBeNull();
            result.ActiveUsers.Should().BeGreaterOrEqual(0);
            result.NewUsers.Should().BeGreaterOrEqual(0);
            result.RetentionRate.Should().BeInRange(0, 100);
        }
    }
}
