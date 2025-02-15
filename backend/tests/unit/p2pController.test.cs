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
    public class P2PControllerTests
    {
        private readonly Mock<IP2PService> _mockP2PService;
        private readonly P2PController _controller;

        public P2PControllerTests()
        {
            _mockP2PService = new Mock<IP2PService>();
            _controller = new P2PController(_mockP2PService.Object);
        }

        [Fact]
        public async Task CreateP2POffer_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var offerRequest = new P2POfferRequest
            {
                CurrencyFrom = "BTC",
                CurrencyTo = "USD",
                Amount = 1.0m,
                Price = 30000.0m,
                OfferType = OfferType.Sell
            };

            _mockP2PService.Setup(x => x.CreateOffer(It.IsAny<P2POfferRequest>()))
                          .ReturnsAsync(new P2POffer { Id = "123", Status = OfferStatus.Active });

            // Act
            var result = await _controller.CreateOffer(offerRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<P2POffer>(okResult.Value);
            Assert.Equal("123", returnValue.Id);
            Assert.Equal(OfferStatus.Active, returnValue.Status);
        }

        [Fact]
        public async Task GetP2POffers_ReturnsOffersList()
        {
            // Arrange
            var offers = new[] 
            {
                new P2POffer { Id = "123", Status = OfferStatus.Active },
                new P2POffer { Id = "456", Status = OfferStatus.Active }
            };

            _mockP2PService.Setup(x => x.GetOffers())
                          .ReturnsAsync(offers);

            // Act
            var result = await _controller.GetOffers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<P2POffer[]>(okResult.Value);
            Assert.Equal(2, returnValue.Length);
        }

        [Fact]
        public async Task AcceptP2POffer_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var offerId = "123";
            _mockP2PService.Setup(x => x.AcceptOffer(It.IsAny<string>()))
                          .ReturnsAsync(new P2POffer { Id = offerId, Status = OfferStatus.Matched });

            // Act
            var result = await _controller.AcceptOffer(offerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<P2POffer>(okResult.Value);
            Assert.Equal(offerId, returnValue.Id);
            Assert.Equal(OfferStatus.Matched, returnValue.Status);
        }

        [Fact]
        public async Task CancelP2POffer_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var offerId = "123";
            _mockP2PService.Setup(x => x.CancelOffer(It.IsAny<string>()))
                          .ReturnsAsync(true);

            // Act
            var result = await _controller.CancelOffer(offerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task GetP2POfferById_ExistingOffer_ReturnsOffer()
        {
            // Arrange
            var offerId = "123";
            var offer = new P2POffer { Id = offerId, Status = OfferStatus.Active };
            
            _mockP2PService.Setup(x => x.GetOfferById(It.IsAny<string>()))
                          .ReturnsAsync(offer);

            // Act
            var result = await _controller.GetOfferById(offerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<P2POffer>(okResult.Value);
            Assert.Equal(offerId, returnValue.Id);
        }
    }
}
