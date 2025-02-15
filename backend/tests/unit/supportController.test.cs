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
    public class SupportControllerTests
    {
        private readonly Mock<ISupportService> _mockSupportService;
        private readonly SupportController _controller;

        public SupportControllerTests()
        {
            _mockSupportService = new Mock<ISupportService>();
            _controller = new SupportController(_mockSupportService.Object);
        }

        [Fact]
        public async Task CreateTicket_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var ticketRequest = new SupportTicketRequest
            {
                UserId = "user123",
                Subject = "KYC Verification Issue",
                Description = "Having trouble uploading documents",
                Priority = TicketPriority.High
            };

            _mockSupportService.Setup(x => x.CreateTicketAsync(It.IsAny<SupportTicketRequest>()))
                .ReturnsAsync(new SupportTicket { Id = "ticket123" });

            // Act
            var result = await _controller.CreateTicket(ticketRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupportTicket>(okResult.Value);
            Assert.Equal("ticket123", returnValue.Id);
        }

        [Fact]
        public async Task GetTicket_ExistingTicket_ReturnsTicket()
        {
            // Arrange
            var ticketId = "ticket123";
            var ticket = new SupportTicket
            {
                Id = ticketId,
                Status = TicketStatus.Open
            };

            _mockSupportService.Setup(x => x.GetTicketAsync(ticketId))
                .ReturnsAsync(ticket);

            // Act
            var result = await _controller.GetTicket(ticketId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupportTicket>(okResult.Value);
            Assert.Equal(ticketId, returnValue.Id);
        }

        [Fact]
        public async Task UpdateTicketStatus_ValidUpdate_ReturnsOkResult()
        {
            // Arrange
            var ticketId = "ticket123";
            var updateRequest = new TicketStatusUpdateRequest
            {
                Status = TicketStatus.InProgress
            };

            _mockSupportService.Setup(x => x.UpdateTicketStatusAsync(ticketId, updateRequest))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateTicketStatus(ticketId, updateRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetUserTickets_ReturnsUserTickets()
        {
            // Arrange
            var userId = "user123";
            var tickets = new[] 
            {
                new SupportTicket { Id = "ticket1", UserId = userId },
                new SupportTicket { Id = "ticket2", UserId = userId }
            };

            _mockSupportService.Setup(x => x.GetUserTicketsAsync(userId))
                .ReturnsAsync(tickets);

            // Act
            var result = await _controller.GetUserTickets(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupportTicket[]>(okResult.Value);
            Assert.Equal(2, returnValue.Length);
        }

        [Fact]
        public async Task AddComment_ValidComment_ReturnsOkResult()
        {
            // Arrange
            var ticketId = "ticket123";
            var commentRequest = new TicketCommentRequest
            {
                UserId = "user123",
                Content = "Test comment"
            };

            _mockSupportService.Setup(x => x.AddCommentAsync(ticketId, commentRequest))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.AddComment(ticketId, commentRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
