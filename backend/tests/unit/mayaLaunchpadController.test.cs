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
    public class MayaLaunchpadControllerTests
    {
        private readonly Mock<ILaunchpadService> _mockLaunchpadService;
        private readonly MayaLaunchpadController _controller;

        public MayaLaunchpadControllerTests()
        {
            _mockLaunchpadService = new Mock<ILaunchpadService>();
            _controller = new MayaLaunchpadController(_mockLaunchpadService.Object);
        }

        [Fact]
        public async Task CreateLaunchpad_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new LaunchpadRequest
            {
                TokenName = "TEST",
                TokenSymbol = "TST",
                InitialSupply = 1000000,
                TokenPrice = 0.1m,
                SaleStartTime = DateTime.UtcNow.AddDays(1),
                SaleEndTime = DateTime.UtcNow.AddDays(8),
                MinPurchase = 100,
                MaxPurchase = 10000
            };

            _mockLaunchpadService.Setup(x => x.CreateLaunchpad(It.IsAny<LaunchpadRequest>()))
                .ReturnsAsync(new LaunchpadResponse { Success = true, LaunchpadId = "123" });

            // Act
            var result = await _controller.CreateLaunchpad(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<LaunchpadResponse>(okResult.Value);
            Assert.True(response.Success);
            Assert.NotNull(response.LaunchpadId);
        }

        [Fact]
        public async Task GetLaunchpad_ValidId_ReturnsLaunchpadDetails()
        {
            // Arrange
            var launchpadId = "123";
            var expectedLaunchpad = new LaunchpadDetails
            {
                Id = launchpadId,
                TokenName = "TEST",
                TokenSymbol = "TST",
                CurrentRaise = 50000,
                TargetRaise = 100000,
                Status = "Active"
            };

            _mockLaunchpadService.Setup(x => x.GetLaunchpadDetails(launchpadId))
                .ReturnsAsync(expectedLaunchpad);

            // Act
            var result = await _controller.GetLaunchpad(launchpadId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var launchpad = Assert.IsType<LaunchpadDetails>(okResult.Value);
            Assert.Equal(expectedLaunchpad.Id, launchpad.Id);
            Assert.Equal(expectedLaunchpad.TokenName, launchpad.TokenName);
        }

        [Fact]
        public async Task Participate_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var request = new ParticipationRequest
            {
                LaunchpadId = "123",
                Amount = 1000,
                WalletAddress = "0x123..."
            };

            _mockLaunchpadService.Setup(x => x.ProcessParticipation(It.IsAny<ParticipationRequest>()))
                .ReturnsAsync(new ParticipationResponse { Success = true, TransactionId = "tx123" });

            // Act
            var result = await _controller.Participate(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ParticipationResponse>(okResult.Value);
            Assert.True(response.Success);
            Assert.NotNull(response.TransactionId);
        }

        [Fact]
        public async Task GetUserParticipations_ReturnsUserParticipations()
        {
            // Arrange
            var userId = "user123";
            var expectedParticipations = new[]
            {
                new UserParticipation
                {
                    LaunchpadId = "123",
                    Amount = 1000,
                    TokensAllocated = 10000,
                    ParticipationTime = DateTime.UtcNow
                }
            };

            _mockLaunchpadService.Setup(x => x.GetUserParticipations(userId))
                .ReturnsAsync(expectedParticipations);

            // Act
            var result = await _controller.GetUserParticipations(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var participations = Assert.IsType<UserParticipation[]>(okResult.Value);
            Assert.Single(participations);
            Assert.Equal(expectedParticipations[0].LaunchpadId, participations[0].LaunchpadId);
        }
    }
}
