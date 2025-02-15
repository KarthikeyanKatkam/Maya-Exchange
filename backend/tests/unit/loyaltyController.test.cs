using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using Maya.Exchange.Controllers;
using Maya.Exchange.Services;
using Maya.Exchange.Models;

namespace Maya.Exchange.Tests.Unit
{
    public class LoyaltyControllerTests
    {
        private readonly Mock<ILoyaltyService> _mockLoyaltyService;
        private readonly LoyaltyController _controller;

        public LoyaltyControllerTests()
        {
            _mockLoyaltyService = new Mock<ILoyaltyService>();
            _controller = new LoyaltyController(_mockLoyaltyService.Object);
        }

        [Fact]
        public async Task GetUserLoyaltyPoints_ReturnsOkResult()
        {
            // Arrange
            var userId = "testUserId";
            var expectedPoints = 100;
            _mockLoyaltyService.Setup(x => x.GetUserPoints(userId))
                .ReturnsAsync(expectedPoints);

            // Act
            var result = await _controller.GetUserLoyaltyPoints(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedPoints, okResult.Value);
        }

        [Fact]
        public async Task AddLoyaltyPoints_ReturnsOkResult()
        {
            // Arrange
            var request = new AddPointsRequest 
            { 
                UserId = "testUserId",
                Points = 50,
                TransactionId = "testTransactionId"
            };
            _mockLoyaltyService.Setup(x => x.AddPoints(request))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.AddLoyaltyPoints(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RedeemPoints_ReturnsOkResult()
        {
            // Arrange
            var request = new RedeemPointsRequest
            {
                UserId = "testUserId",
                Points = 25,
                RewardId = "testRewardId"
            };
            _mockLoyaltyService.Setup(x => x.RedeemPoints(request))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.RedeemPoints(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetLoyaltyTiers_ReturnsOkResult()
        {
            // Arrange
            var tiers = new[]
            {
                new LoyaltyTier { Id = "1", Name = "Bronze", MinPoints = 0 },
                new LoyaltyTier { Id = "2", Name = "Silver", MinPoints = 1000 },
                new LoyaltyTier { Id = "3", Name = "Gold", MinPoints = 5000 }
            };
            _mockLoyaltyService.Setup(x => x.GetLoyaltyTiers())
                .ReturnsAsync(tiers);

            // Act
            var result = await _controller.GetLoyaltyTiers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tiers, okResult.Value);
        }

        [Fact]
        public async Task GetUserCurrentTier_ReturnsOkResult()
        {
            // Arrange
            var userId = "testUserId";
            var expectedTier = new LoyaltyTier 
            { 
                Id = "2", 
                Name = "Silver", 
                MinPoints = 1000 
            };
            _mockLoyaltyService.Setup(x => x.GetUserCurrentTier(userId))
                .ReturnsAsync(expectedTier);

            // Act
            var result = await _controller.GetUserCurrentTier(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedTier, okResult.Value);
        }
    }
}
