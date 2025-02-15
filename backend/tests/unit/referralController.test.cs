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
    public class ReferralControllerTests
    {
        private readonly Mock<IReferralService> _mockReferralService;
        private readonly ReferralController _controller;

        public ReferralControllerTests()
        {
            _mockReferralService = new Mock<IReferralService>();
            _controller = new ReferralController(_mockReferralService.Object);
        }

        [Fact]
        public async Task CreateReferral_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var referralRequest = new ReferralRequest
            {
                ReferrerId = "user123",
                ReferredEmail = "referred@test.com"
            };

            _mockReferralService.Setup(x => x.CreateReferral(It.IsAny<ReferralRequest>()))
                .ReturnsAsync(new ReferralResponse { Success = true });

            // Act
            var result = await _controller.CreateReferral(referralRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ReferralResponse>(okResult.Value);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task GetReferralStatus_ValidId_ReturnsReferralDetails()
        {
            // Arrange
            var referralId = "ref123";
            var expectedReferral = new ReferralDetails
            {
                Id = referralId,
                Status = "Pending",
                ReferralBonus = 50.0m
            };

            _mockReferralService.Setup(x => x.GetReferralStatus(referralId))
                .ReturnsAsync(expectedReferral);

            // Act
            var result = await _controller.GetReferralStatus(referralId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var referral = Assert.IsType<ReferralDetails>(okResult.Value);
            Assert.Equal(expectedReferral.Id, referral.Id);
            Assert.Equal(expectedReferral.Status, referral.Status);
        }

        [Fact]
        public async Task ValidateReferralCode_InvalidCode_ReturnsBadRequest()
        {
            // Arrange
            var invalidCode = "invalid123";
            _mockReferralService.Setup(x => x.ValidateReferralCode(invalidCode))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.ValidateReferralCode(invalidCode);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetReferralRewards_ValidUserId_ReturnsRewards()
        {
            // Arrange
            var userId = "user123";
            var expectedRewards = new ReferralRewards
            {
                TotalReferrals = 5,
                TotalRewards = 250.0m,
                PendingRewards = 100.0m
            };

            _mockReferralService.Setup(x => x.GetReferralRewards(userId))
                .ReturnsAsync(expectedRewards);

            // Act
            var result = await _controller.GetReferralRewards(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var rewards = Assert.IsType<ReferralRewards>(okResult.Value);
            Assert.Equal(expectedRewards.TotalReferrals, rewards.TotalReferrals);
            Assert.Equal(expectedRewards.TotalRewards, rewards.TotalRewards);
        }

        [Fact]
        public async Task ProcessReferralReward_ValidRequest_ReturnsSuccess()
        {
            // Arrange
            var rewardRequest = new ReferralRewardRequest
            {
                ReferralId = "ref123",
                Amount = 50.0m
            };

            _mockReferralService.Setup(x => x.ProcessReferralReward(It.IsAny<ReferralRewardRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.ProcessReferralReward(rewardRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }
    }
}
