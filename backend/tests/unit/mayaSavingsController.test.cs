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
    public class MayaSavingsControllerTests
    {
        private readonly Mock<ISavingsService> _mockSavingsService;
        private readonly MayaSavingsController _controller;

        public MayaSavingsControllerTests()
        {
            _mockSavingsService = new Mock<ISavingsService>();
            _controller = new MayaSavingsController(_mockSavingsService.Object);
        }

        [Fact]
        public async Task CreateSavingsGoal_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new SavingsGoalRequest
            {
                UserId = "test-user-id",
                GoalName = "Vacation Fund",
                TargetAmount = 5000.00m,
                Currency = "USD",
                TargetDate = DateTime.Now.AddMonths(6)
            };

            _mockSavingsService.Setup(x => x.CreateSavingsGoalAsync(It.IsAny<SavingsGoalRequest>()))
                .ReturnsAsync(new SavingsGoal { Id = "1", GoalName = request.GoalName });

            // Act
            var result = await _controller.CreateSavingsGoal(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SavingsGoal>(okResult.Value);
            Assert.Equal(request.GoalName, returnValue.GoalName);
        }

        [Fact]
        public async Task GetSavingsGoals_ReturnsOkResult()
        {
            // Arrange
            var userId = "test-user-id";
            var expectedGoals = new[]
            {
                new SavingsGoal { Id = "1", GoalName = "Vacation Fund", TargetAmount = 5000.00m },
                new SavingsGoal { Id = "2", GoalName = "Emergency Fund", TargetAmount = 10000.00m }
            };

            _mockSavingsService.Setup(x => x.GetSavingsGoalsAsync(userId))
                .ReturnsAsync(expectedGoals);

            // Act
            var result = await _controller.GetSavingsGoals(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SavingsGoal[]>(okResult.Value);
            Assert.Equal(expectedGoals.Length, returnValue.Length);
        }

        [Fact]
        public async Task AddToSavings_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new AddToSavingsRequest
            {
                UserId = "test-user-id",
                GoalId = "1",
                Amount = 500.00m,
                Currency = "USD"
            };

            _mockSavingsService.Setup(x => x.AddToSavingsAsync(It.IsAny<AddToSavingsRequest>()))
                .ReturnsAsync(new SavingsTransaction { Id = "1", Amount = request.Amount });

            // Act
            var result = await _controller.AddToSavings(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<SavingsTransaction>(okResult.Value);
            Assert.Equal(request.Amount, response.Amount);
        }

        [Fact]
        public async Task GetSavingsBalance_ReturnsOkResult()
        {
            // Arrange
            var userId = "test-user-id";
            var expectedBalance = 2500.00m;

            _mockSavingsService.Setup(x => x.GetSavingsBalanceAsync(userId))
                .ReturnsAsync(expectedBalance);

            // Act
            var result = await _controller.GetSavingsBalance(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedBalance, okResult.Value);
        }
    }
}
