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
    public class MayaDexControllerTests
    {
        private readonly Mock<IMayaDexService> _mockDexService;
        private readonly MayaDexController _controller;

        public MayaDexControllerTests()
        {
            _mockDexService = new Mock<IMayaDexService>();
            _controller = new MayaDexController(_mockDexService.Object);
        }

        [Fact]
        public async Task GetOrderBook_ReturnsOkResult()
        {
            // Arrange
            var orderBook = new OrderBook();
            _mockDexService.Setup(x => x.GetOrderBookAsync())
                .ReturnsAsync(orderBook);

            // Act
            var result = await _controller.GetOrderBook();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<OrderBook>(okResult.Value);
            Assert.Equal(orderBook, returnValue);
        }

        [Fact]
        public async Task PlaceOrder_WithValidOrder_ReturnsCreatedResult()
        {
            // Arrange
            var order = new Order 
            { 
                UserId = "testUser",
                OrderType = OrderType.Buy,
                Amount = 1.0m,
                Price = 100.0m,
                TradingPair = "BTC-USD"
            };
            
            _mockDexService.Setup(x => x.PlaceOrderAsync(It.IsAny<Order>()))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.PlaceOrder(order);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Order>(createdResult.Value);
            Assert.Equal(order, returnValue);
        }

        [Fact]
        public async Task CancelOrder_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var orderId = "testOrderId";
            _mockDexService.Setup(x => x.CancelOrderAsync(orderId))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.CancelOrder(orderId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetUserOrders_ReturnsOkResult()
        {
            // Arrange
            var userId = "testUser";
            var orders = new Order[] { new Order(), new Order() };
            _mockDexService.Setup(x => x.GetUserOrdersAsync(userId))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetUserOrders(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Order[]>(okResult.Value);
            Assert.Equal(orders, returnValue);
        }

        [Fact]
        public async Task GetTradingPairs_ReturnsOkResult()
        {
            // Arrange
            var pairs = new string[] { "BTC-USD", "ETH-USD" };
            _mockDexService.Setup(x => x.GetTradingPairsAsync())
                .ReturnsAsync(pairs);

            // Act
            var result = await _controller.GetTradingPairs();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<string[]>(okResult.Value);
            Assert.Equal(pairs, returnValue);
        }

        [Fact]
        public async Task GetMarketData_ReturnsOkResult()
        {
            // Arrange
            var tradingPair = "BTC-USD";
            var marketData = new MarketData 
            { 
                TradingPair = tradingPair,
                LastPrice = 50000.0m,
                Volume24H = 100.0m,
                PriceChange24H = 2.5m
            };
            
            _mockDexService.Setup(x => x.GetMarketDataAsync(tradingPair))
                .ReturnsAsync(marketData);

            // Act
            var result = await _controller.GetMarketData(tradingPair);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MarketData>(okResult.Value);
            Assert.Equal(marketData, returnValue);
        }
    }
}
