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
    public class CryptoControllerTests
    {
        private readonly Mock<ICryptoService> _mockCryptoService;
        private readonly CryptoController _controller;

        public CryptoControllerTests()
        {
            _mockCryptoService = new Mock<ICryptoService>();
            _controller = new CryptoController(_mockCryptoService.Object);
        }

        [Fact]
        public async Task GetCryptoBalance_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var userId = "testUserId";
            var expectedBalance = new CryptoBalance { 
                UserId = userId,
                BTC = 1.5m,
                ETH = 10.0m,
                USDT = 1000.0m
            };

            _mockCryptoService.Setup(x => x.GetUserBalanceAsync(userId))
                .ReturnsAsync(expectedBalance);

            // Act
            var result = await _controller.GetCryptoBalance(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CryptoBalance>(okResult.Value);
            Assert.Equal(expectedBalance.BTC, returnValue.BTC);
            Assert.Equal(expectedBalance.ETH, returnValue.ETH);
            Assert.Equal(expectedBalance.USDT, returnValue.USDT);
        }

        [Fact]
        public async Task SendCrypto_ReturnsOkResult_WhenTransactionIsValid()
        {
            // Arrange
            var transaction = new CryptoTransaction
            {
                FromUserId = "sender123",
                ToUserId = "receiver456", 
                CryptoType = "BTC",
                Amount = 0.5m
            };

            _mockCryptoService.Setup(x => x.SendCryptoAsync(It.IsAny<CryptoTransaction>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.SendCrypto(transaction);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ConvertCrypto_ReturnsOkResult_WhenConversionIsValid()
        {
            // Arrange
            var conversion = new CryptoConversion
            {
                UserId = "user123",
                FromCrypto = "BTC",
                ToCrypto = "ETH",
                Amount = 1.0m
            };

            var expectedResult = new ConversionResult
            {
                Success = true,
                ConvertedAmount = 15.5m,
                Fee = 0.1m
            };

            _mockCryptoService.Setup(x => x.ConvertCryptoAsync(It.IsAny<CryptoConversion>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.ConvertCrypto(conversion);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ConversionResult>(okResult.Value);
            Assert.Equal(expectedResult.ConvertedAmount, returnValue.ConvertedAmount);
            Assert.Equal(expectedResult.Fee, returnValue.Fee);
        }

        [Fact]
        public async Task GetTransactionHistory_ReturnsOkResult_WithTransactions()
        {
            // Arrange
            var userId = "testUserId";
            var transactions = new[]
            {
                new CryptoTransaction { 
                    FromUserId = userId,
                    ToUserId = "other123",
                    CryptoType = "ETH",
                    Amount = 2.0m,
                    Timestamp = DateTime.UtcNow
                }
            };

            _mockCryptoService.Setup(x => x.GetTransactionHistoryAsync(userId))
                .ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactionHistory(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CryptoTransaction[]>(okResult.Value);
            Assert.Single(returnValue);
            Assert.Equal(transactions[0].Amount, returnValue[0].Amount);
        }
    }
}
