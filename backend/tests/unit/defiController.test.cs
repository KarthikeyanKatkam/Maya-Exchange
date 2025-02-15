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
    public class DefiControllerTests
    {
        private readonly Mock<IDefiService> _mockDefiService;
        private readonly DefiController _controller;

        public DefiControllerTests()
        {
            _mockDefiService = new Mock<IDefiService>();
            _controller = new DefiController(_mockDefiService.Object);
        }

        [Fact]
        public async Task GetLiquidityPools_ReturnsOkResult()
        {
            // Arrange
            var expectedPools = new LiquidityPool[] 
            {
                new LiquidityPool { Id = "1", Token1 = "ETH", Token2 = "USDT", TotalLiquidity = 1000000 },
                new LiquidityPool { Id = "2", Token1 = "BTC", Token2 = "USDT", TotalLiquidity = 2000000 }
            };
            
            _mockDefiService.Setup(x => x.GetLiquidityPools())
                .ReturnsAsync(expectedPools);

            // Act
            var result = await _controller.GetLiquidityPools();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LiquidityPool[]>(okResult.Value);
            Assert.Equal(expectedPools.Length, returnValue.Length);
        }

        [Fact]
        public async Task AddLiquidity_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new AddLiquidityRequest
            {
                PoolId = "1",
                Amount1 = 100,
                Amount2 = 100,
                SlippageTolerance = 0.01m
            };

            _mockDefiService.Setup(x => x.AddLiquidity(It.IsAny<AddLiquidityRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.AddLiquidity(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Swap_WithValidRequest_ReturnsOkWithSwapResult()
        {
            // Arrange
            var request = new SwapRequest
            {
                FromToken = "ETH",
                ToToken = "USDT",
                Amount = 1.0m,
                SlippageTolerance = 0.01m
            };

            var expectedResult = new SwapResult
            {
                Success = true,
                AmountReceived = 1800.0m,
                Fee = 5.0m
            };

            _mockDefiService.Setup(x => x.ExecuteSwap(It.IsAny<SwapRequest>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Swap(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var swapResult = Assert.IsType<SwapResult>(okResult.Value);
            Assert.True(swapResult.Success);
        }

        [Fact]
        public async Task GetYieldFarms_ReturnsOkResult()
        {
            // Arrange
            var expectedFarms = new YieldFarm[]
            {
                new YieldFarm { Id = "1", Name = "ETH-USDT LP", APY = 25.5m },
                new YieldFarm { Id = "2", Name = "BTC-USDT LP", APY = 18.2m }
            };

            _mockDefiService.Setup(x => x.GetYieldFarms())
                .ReturnsAsync(expectedFarms);

            // Act
            var result = await _controller.GetYieldFarms();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<YieldFarm[]>(okResult.Value);
            Assert.Equal(expectedFarms.Length, returnValue.Length);
        }

        [Fact]
        public async Task StakeInFarm_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new StakeRequest
            {
                FarmId = "1",
                Amount = 100
            };

            _mockDefiService.Setup(x => x.Stake(It.IsAny<StakeRequest>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Stake(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
