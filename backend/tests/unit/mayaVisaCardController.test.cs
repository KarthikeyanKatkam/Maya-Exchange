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
    public class MayaVisaCardControllerTests
    {
        private readonly Mock<IVisaCardService> _mockVisaCardService;
        private readonly MayaVisaCardController _controller;

        public MayaVisaCardControllerTests()
        {
            _mockVisaCardService = new Mock<IVisaCardService>();
            _controller = new MayaVisaCardController(_mockVisaCardService.Object);
        }

        [Fact]
        public async Task CreateVisaCard_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new VisaCardRequest
            {
                UserId = "test-user-id",
                CardType = "Virtual",
                Currency = "USD"
            };

            _mockVisaCardService
                .Setup(x => x.CreateVisaCardAsync(It.IsAny<VisaCardRequest>()))
                .ReturnsAsync(new VisaCard { Id = "test-card-id" });

            // Act
            var result = await _controller.CreateVisaCard(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VisaCard>(okResult.Value);
            Assert.Equal("test-card-id", returnValue.Id);
        }

        [Fact]
        public async Task GetVisaCard_ExistingCard_ReturnsOkResult()
        {
            // Arrange
            var cardId = "test-card-id";
            _mockVisaCardService
                .Setup(x => x.GetVisaCardAsync(cardId))
                .ReturnsAsync(new VisaCard { Id = cardId });

            // Act
            var result = await _controller.GetVisaCard(cardId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VisaCard>(okResult.Value);
            Assert.Equal(cardId, returnValue.Id);
        }

        [Fact]
        public async Task UpdateVisaCardStatus_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new UpdateCardStatusRequest
            {
                CardId = "test-card-id",
                Status = "Active"
            };

            _mockVisaCardService
                .Setup(x => x.UpdateCardStatusAsync(It.IsAny<UpdateCardStatusRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateVisaCardStatus(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteVisaCard_ExistingCard_ReturnsOkResult()
        {
            // Arrange
            var cardId = "test-card-id";
            _mockVisaCardService
                .Setup(x => x.DeleteVisaCardAsync(cardId))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteVisaCard(cardId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetTransactionHistory_ExistingCard_ReturnsOkResult()
        {
            // Arrange
            var cardId = "test-card-id";
            var transactions = new[] 
            {
                new CardTransaction { Id = "tx1", Amount = 100 },
                new CardTransaction { Id = "tx2", Amount = 200 }
            };

            _mockVisaCardService
                .Setup(x => x.GetTransactionHistoryAsync(cardId))
                .ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactionHistory(cardId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CardTransaction[]>(okResult.Value);
            Assert.Equal(2, returnValue.Length);
        }

        [Fact]
        public async Task SetTransactionLimits_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new TransactionLimitRequest
            {
                CardId = "test-card-id",
                DailyLimit = 1000,
                MonthlyLimit = 10000
            };

            _mockVisaCardService
                .Setup(x => x.SetTransactionLimitsAsync(It.IsAny<TransactionLimitRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.SetTransactionLimits(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
