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
    public class KycControllerTests
    {
        private readonly Mock<IKycService> _mockKycService;
        private readonly KycController _controller;

        public KycControllerTests()
        {
            _mockKycService = new Mock<IKycService>();
            _controller = new KycController(_mockKycService.Object);
        }

        [Fact]
        public async Task SubmitKyc_ValidRequest_ReturnsOk()
        {
            // Arrange
            var kycRequest = new KycSubmissionRequest
            {
                UserId = "test-user-id",
                FullName = "Test User",
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Address = "123 Test St",
                DocumentType = "Passport",
                DocumentNumber = "AB123456",
                DocumentImage = "base64-encoded-image"
            };

            _mockKycService.Setup(x => x.SubmitKycAsync(It.IsAny<KycSubmissionRequest>()))
                .ReturnsAsync(new KycSubmissionResponse { Status = "Pending" });

            // Act
            var result = await _controller.SubmitKyc(kycRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<KycSubmissionResponse>(okResult.Value);
            Assert.Equal("Pending", response.Status);
        }

        [Fact]
        public async Task VerifyKyc_ValidId_ReturnsVerificationStatus()
        {
            // Arrange
            var userId = "test-user-id";
            _mockKycService.Setup(x => x.GetKycStatusAsync(userId))
                .ReturnsAsync(new KycStatusResponse { Status = "Verified" });

            // Act
            var result = await _controller.GetKycStatus(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<KycStatusResponse>(okResult.Value);
            Assert.Equal("Verified", response.Status);
        }

        [Fact]
        public async Task SubmitKyc_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var invalidRequest = new KycSubmissionRequest(); // Empty request

            // Act
            var result = await _controller.SubmitKyc(invalidRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetKycStatus_NonexistentUser_ReturnsNotFound()
        {
            // Arrange
            var nonexistentUserId = "non-existent-id";
            _mockKycService.Setup(x => x.GetKycStatusAsync(nonexistentUserId))
                .ReturnsAsync((KycStatusResponse)null);

            // Act
            var result = await _controller.GetKycStatus(nonexistentUserId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateKycStatus_AdminRequest_ReturnsOk()
        {
            // Arrange
            var updateRequest = new KycStatusUpdateRequest
            {
                UserId = "test-user-id",
                NewStatus = "Approved",
                AdminId = "admin-id",
                Notes = "All documents verified"
            };

            _mockKycService.Setup(x => x.UpdateKycStatusAsync(It.IsAny<KycStatusUpdateRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateKycStatus(updateRequest);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
