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
    public class UpiControllerTests
    {
        private readonly Mock<IUpiService> _mockUpiService;
        private readonly UpiController _controller;

        public UpiControllerTests()
        {
            _mockUpiService = new Mock<IUpiService>();
            _controller = new UpiController(_mockUpiService.Object);
        }

        [Fact]
        public async Task InitiateUpiPayment_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new UpiPaymentRequest
            {
                Amount = 1000.00m,
                Currency = "INR",
                VirtualPaymentAddress = "user@upi",
                Purpose = "Transfer"
            };

            _mockUpiService.Setup(x => x.InitiatePayment(It.IsAny<UpiPaymentRequest>()))
                .ReturnsAsync(new UpiPaymentResponse { TransactionId = "TXN123", Status = "SUCCESS" });

            // Act
            var result = await _controller.InitiatePayment(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<UpiPaymentResponse>(okResult.Value);
            Assert.Equal("TXN123", response.TransactionId);
            Assert.Equal("SUCCESS", response.Status);
        }

        [Fact]
        public async Task VerifyUpiPayment_ValidTransactionId_ReturnsPaymentStatus()
        {
            // Arrange
            string transactionId = "TXN123";
            _mockUpiService.Setup(x => x.VerifyPayment(transactionId))
                .ReturnsAsync(new PaymentStatus { Status = "COMPLETED", Message = "Payment successful" });

            // Act
            var result = await _controller.VerifyPayment(transactionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var status = Assert.IsType<PaymentStatus>(okResult.Value);
            Assert.Equal("COMPLETED", status.Status);
        }

        [Fact]
        public async Task InitiateUpiPayment_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new UpiPaymentRequest(); // Empty request

            // Act
            var result = await _controller.InitiatePayment(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetTransactionHistory_ValidUserId_ReturnsTransactionList()
        {
            // Arrange
            string userId = "USER123";
            var transactions = new[] {
                new UpiTransaction { Id = "1", Amount = 100, Status = "SUCCESS" },
                new UpiTransaction { Id = "2", Amount = 200, Status = "SUCCESS" }
            };

            _mockUpiService.Setup(x => x.GetTransactionHistory(userId))
                .ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactionHistory(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var history = Assert.IsType<UpiTransaction[]>(okResult.Value);
            Assert.Equal(2, history.Length);
        }

        [Fact]
        public async Task ValidateVpa_ValidAddress_ReturnsValidationResult()
        {
            // Arrange
            string vpa = "user@upi";
            _mockUpiService.Setup(x => x.ValidateVpa(vpa))
                .ReturnsAsync(new VpaValidationResult { IsValid = true, Name = "Test User" });

            // Act
            var result = await _controller.ValidateVpa(vpa);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var validationResult = Assert.IsType<VpaValidationResult>(okResult.Value);
            Assert.True(validationResult.IsValid);
        }
    }
}
