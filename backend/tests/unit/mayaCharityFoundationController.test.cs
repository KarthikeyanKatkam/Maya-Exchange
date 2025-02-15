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
    public class MayaCharityFoundationControllerTests
    {
        private readonly Mock<ICharityFoundationService> _mockCharityService;
        private readonly MayaCharityFoundationController _controller;

        public MayaCharityFoundationControllerTests()
        {
            _mockCharityService = new Mock<ICharityFoundationService>();
            _controller = new MayaCharityFoundationController(_mockCharityService.Object);
        }

        [Fact]
        public async Task CreateCharityFoundation_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new CharityFoundationRequest
            {
                Name = "Test Foundation",
                Description = "Test Description",
                RegistrationNumber = "CF123456",
                KycStatus = KycStatus.Verified
            };

            _mockCharityService.Setup(x => x.CreateCharityFoundationAsync(It.IsAny<CharityFoundationRequest>()))
                .ReturnsAsync(new CharityFoundation { Id = "1", Name = request.Name });

            // Act
            var result = await _controller.CreateCharityFoundation(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CharityFoundation>(okResult.Value);
            Assert.Equal(request.Name, returnValue.Name);
        }

        [Fact]
        public async Task GetCharityFoundation_ExistingId_ReturnsFoundation()
        {
            // Arrange
            var foundationId = "1";
            var foundation = new CharityFoundation 
            { 
                Id = foundationId,
                Name = "Test Foundation",
                KycStatus = KycStatus.Verified
            };

            _mockCharityService.Setup(x => x.GetCharityFoundationAsync(foundationId))
                .ReturnsAsync(foundation);

            // Act
            var result = await _controller.GetCharityFoundation(foundationId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CharityFoundation>(okResult.Value);
            Assert.Equal(foundationId, returnValue.Id);
        }

        [Fact]
        public async Task UpdateKycStatus_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var foundationId = "1";
            var request = new KycUpdateRequest
            {
                KycStatus = KycStatus.Verified,
                VerificationDocuments = new[] { "doc1.pdf", "doc2.pdf" }
            };

            _mockCharityService.Setup(x => x.UpdateKycStatusAsync(foundationId, request))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateKycStatus(foundationId, request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task ProcessDonation_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new DonationRequest
            {
                FoundationId = "1",
                Amount = 1000.00m,
                Currency = "USD",
                DonorId = "donor123"
            };

            _mockCharityService.Setup(x => x.ProcessDonationAsync(It.IsAny<DonationRequest>()))
                .ReturnsAsync(new DonationReceipt { Id = "D1", Amount = request.Amount });

            // Act
            var result = await _controller.ProcessDonation(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<DonationReceipt>(okResult.Value);
            Assert.Equal(request.Amount, returnValue.Amount);
        }
    }
}
