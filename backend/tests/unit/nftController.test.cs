using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MayaExchange.Controllers;
using MayaExchange.Services;
using MayaExchange.Models;

namespace MayaExchange.Tests.Unit
{
    public class NftControllerTests
    {
        private readonly Mock<INftService> _mockNftService;
        private readonly NftController _controller;

        public NftControllerTests()
        {
            _mockNftService = new Mock<INftService>();
            _controller = new NftController(_mockNftService.Object);
        }

        [Fact]
        public async Task MintNft_ValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var request = new NftMintRequest
            {
                UserId = "testUser",
                TokenUri = "ipfs://test-uri",
                Name = "Test NFT",
                Description = "Test Description",
                Collection = "Test Collection"
            };

            var expectedNft = new Nft
            {
                Id = "1",
                TokenId = "1",
                Owner = request.UserId,
                TokenUri = request.TokenUri,
                Name = request.Name
            };

            _mockNftService.Setup(x => x.MintNftAsync(It.IsAny<NftMintRequest>()))
                .ReturnsAsync(expectedNft);

            // Act
            var result = await _controller.MintNft(request);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Nft>(createdResult.Value);
            Assert.Equal(expectedNft.Id, returnValue.Id);
            Assert.Equal(request.UserId, returnValue.Owner);
        }

        [Fact]
        public async Task GetNftById_ExistingNft_ReturnsOkResult()
        {
            // Arrange
            var nftId = "1";
            var expectedNft = new Nft
            {
                Id = nftId,
                TokenId = "1",
                Owner = "testUser",
                TokenUri = "ipfs://test-uri",
                Name = "Test NFT"
            };

            _mockNftService.Setup(x => x.GetNftByIdAsync(nftId))
                .ReturnsAsync(expectedNft);

            // Act
            var result = await _controller.GetNftById(nftId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Nft>(okResult.Value);
            Assert.Equal(expectedNft.Id, returnValue.Id);
        }

        [Fact]
        public async Task TransferNft_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new NftTransferRequest
            {
                NftId = "1",
                FromUserId = "user1",
                ToUserId = "user2"
            };

            _mockNftService.Setup(x => x.TransferNftAsync(It.IsAny<NftTransferRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.TransferNft(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetUserNfts_ReturnsOkResult()
        {
            // Arrange
            var userId = "testUser";
            var expectedNfts = new[]
            {
                new Nft { Id = "1", Owner = userId, Name = "NFT 1" },
                new Nft { Id = "2", Owner = userId, Name = "NFT 2" }
            };

            _mockNftService.Setup(x => x.GetUserNftsAsync(userId))
                .ReturnsAsync(expectedNfts);

            // Act
            var result = await _controller.GetUserNfts(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Nft[]>(okResult.Value);
            Assert.Equal(2, returnValue.Length);
            Assert.All(returnValue, nft => Assert.Equal(userId, nft.Owner));
        }
    }
}
