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
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly TransactionController _controller;

        public TransactionControllerTests()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _controller = new TransactionController(_mockTransactionService.Object);
        }

        [Fact]
        public async Task GetTransactionHistory_ReturnsOkResult()
        {
            // Arrange
            var userId = "testUserId";
            var transactions = new[] {
                new Transaction { 
                    Id = "1",
                    UserId = userId,
                    Type = TransactionType.Send,
                    Amount = 100.00m,
                    Currency = "USD",
                    Status = TransactionStatus.Completed,
                    Timestamp = DateTime.UtcNow
                }
            };

            _mockTransactionService
                .Setup(s => s.GetTransactionHistoryAsync(userId))
                .ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactionHistory(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTransactions = Assert.IsType<Transaction[]>(okResult.Value);
            Assert.Single(returnedTransactions);
        }

        [Fact]
        public async Task CreateTransaction_WithValidData_ReturnsCreatedResult()
        {
            // Arrange
            var transactionRequest = new TransactionRequest
            {
                UserId = "testUserId",
                Amount = 100.00m,
                SourceCurrency = "USD",
                DestinationCurrency = "BTC",
                Type = TransactionType.Convert
            };

            var createdTransaction = new Transaction
            {
                Id = "newId",
                UserId = transactionRequest.UserId,
                Amount = transactionRequest.Amount,
                Currency = transactionRequest.SourceCurrency,
                Type = transactionRequest.Type,
                Status = TransactionStatus.Pending
            };

            _mockTransactionService
                .Setup(s => s.CreateTransactionAsync(It.IsAny<TransactionRequest>()))
                .ReturnsAsync(createdTransaction);

            // Act
            var result = await _controller.CreateTransaction(transactionRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedTransaction = Assert.IsType<Transaction>(createdResult.Value);
            Assert.Equal(createdTransaction.Id, returnedTransaction.Id);
        }

        [Fact]
        public async Task UpdateTransactionStatus_WithValidData_ReturnsOkResult()
        {
            // Arrange
            var transactionId = "testTransactionId";
            var status = TransactionStatus.Completed;

            _mockTransactionService
                .Setup(s => s.UpdateTransactionStatusAsync(transactionId, status))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateTransactionStatus(transactionId, status);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetTransactionById_WithValidId_ReturnsTransaction()
        {
            // Arrange
            var transactionId = "testTransactionId";
            var transaction = new Transaction
            {
                Id = transactionId,
                UserId = "testUserId",
                Amount = 100.00m,
                Currency = "USD",
                Type = TransactionType.Send,
                Status = TransactionStatus.Completed
            };

            _mockTransactionService
                .Setup(s => s.GetTransactionByIdAsync(transactionId))
                .ReturnsAsync(transaction);

            // Act
            var result = await _controller.GetTransactionById(transactionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTransaction = Assert.IsType<Transaction>(okResult.Value);
            Assert.Equal(transactionId, returnedTransaction.Id);
        }
    }
}
