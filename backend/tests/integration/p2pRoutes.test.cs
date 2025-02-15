using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Api.Models;
using Maya.Exchange.Api.Services;
using Maya.Exchange.Api.Tests.Helpers;

namespace Maya.Exchange.Api.Tests.Integration
{
    public class P2PRoutesTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly IUserService _userService;
        private readonly IKycService _kycService;
        private readonly IP2PService _p2pService;

        public P2PRoutesTests(TestServerFixture fixture)
        {
            _server = fixture.Server;
            _client = _server.CreateClient();
            _userService = _server.Services.GetRequiredService<IUserService>();
            _kycService = _server.Services.GetRequiredService<IKycService>();
            _p2pService = _server.Services.GetRequiredService<IP2PService>();
        }

        [Fact]
        public async Task CreateP2POffer_WithValidData_ShouldSucceed()
        {
            // Arrange
            var user = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            var offerRequest = new P2POfferRequest
            {
                CurrencyFrom = "BTC",
                CurrencyTo = "USD",
                Amount = 1.0m,
                Price = 30000.0m,
                PaymentMethods = new[] { "BANK_TRANSFER", "PAYPAL" }
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/p2p/offers", offerRequest);

            // Assert
            response.Should().BeSuccessful();
            var offer = await response.Content.ReadFromJsonAsync<P2POffer>();
            offer.Should().NotBeNull();
            offer.Status.Should().Be("ACTIVE");
        }

        [Fact]
        public async Task AcceptP2POffer_WithValidKYC_ShouldSucceed()
        {
            // Arrange
            var seller = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            var buyer = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            var offer = await TestDataHelper.CreateP2POffer(_p2pService, seller.Id);

            // Act
            var response = await _client.PostAsJsonAsync($"/api/p2p/offers/{offer.Id}/accept", new { UserId = buyer.Id });

            // Assert
            response.Should().BeSuccessful();
            var trade = await response.Content.ReadFromJsonAsync<P2PTrade>();
            trade.Should().NotBeNull();
            trade.Status.Should().Be("PENDING");
            trade.BuyerId.Should().Be(buyer.Id);
            trade.SellerId.Should().Be(seller.Id);
        }

        [Fact]
        public async Task GetP2POffers_WithFilters_ShouldReturnMatchingOffers()
        {
            // Arrange
            var user = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            await TestDataHelper.CreateMultipleP2POffers(_p2pService, user.Id);

            // Act
            var response = await _client.GetAsync("/api/p2p/offers?currencyFrom=BTC&currencyTo=USD");

            // Assert
            response.Should().BeSuccessful();
            var offers = await response.Content.ReadFromJsonAsync<P2POffer[]>();
            offers.Should().NotBeEmpty();
            offers.Should().OnlyContain(o => 
                o.CurrencyFrom == "BTC" && 
                o.CurrencyTo == "USD" &&
                o.Status == "ACTIVE"
            );
        }

        [Fact]
        public async Task CompleteP2PTrade_WithValidEscrow_ShouldSucceed()
        {
            // Arrange
            var seller = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            var buyer = await TestDataHelper.CreateVerifiedUser(_userService, _kycService);
            var trade = await TestDataHelper.CreateP2PTrade(_p2pService, seller.Id, buyer.Id);

            // Act
            var response = await _client.PostAsJsonAsync($"/api/p2p/trades/{trade.Id}/complete", new { });

            // Assert
            response.Should().BeSuccessful();
            var completedTrade = await response.Content.ReadFromJsonAsync<P2PTrade>();
            completedTrade.Should().NotBeNull();
            completedTrade.Status.Should().Be("COMPLETED");
        }
    }
}
