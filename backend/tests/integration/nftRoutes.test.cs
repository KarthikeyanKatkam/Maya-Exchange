using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Maya.Exchange.Tests.Helpers;
using Maya.Exchange.Models;

namespace Maya.Exchange.Tests.Integration
{
    public class NftRoutesTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public NftRoutesTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetNftList_ReturnsSuccessStatusCode()
        {
            // Arrange
            var response = await _client.GetAsync("/api/nfts");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateNft_WithValidData_ReturnsCreatedStatusCode()
        {
            // Arrange
            var nftData = new NftCreateDto
            {
                Name = "Test NFT",
                Description = "Test Description",
                TokenId = "TEST123",
                CreatorAddress = "0x123456789",
                OwnerAddress = "0x987654321",
                Price = 1.5m,
                Currency = "ETH"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/nfts", nftData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetNftById_WithValidId_ReturnsNft()
        {
            // Arrange
            var nftId = "test-nft-id";

            // Act
            var response = await _client.GetAsync($"/api/nfts/{nftId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var nft = await response.Content.ReadFromJsonAsync<NftDto>();
            nft.Should().NotBeNull();
        }

        [Fact]
        public async Task TransferNft_WithValidData_ReturnsSuccessStatusCode()
        {
            // Arrange
            var transferData = new NftTransferDto
            {
                TokenId = "TEST123",
                FromAddress = "0x123456789",
                ToAddress = "0x987654321"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/nfts/transfer", transferData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ListNftForSale_WithValidData_ReturnsSuccessStatusCode()
        {
            // Arrange
            var listingData = new NftListingDto
            {
                TokenId = "TEST123",
                Price = 2.0m,
                Currency = "ETH"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/nfts/list", listingData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task BuyNft_WithValidData_ReturnsSuccessStatusCode()
        {
            // Arrange
            var purchaseData = new NftPurchaseDto
            {
                TokenId = "TEST123",
                BuyerAddress = "0x987654321"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/nfts/buy", purchaseData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
