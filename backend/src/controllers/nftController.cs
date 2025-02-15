using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Maya.Exchange.Services;
using Maya.Exchange.Models;
using Maya.Exchange.Utils;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NftController : ControllerBase
    {
        private readonly ILogger<NftController> _logger;
        private readonly INftService _nftService;
        private readonly IKycService _kycService;

        public NftController(
            ILogger<NftController> logger,
            INftService nftService,
            IKycService kycService)
        {
            _logger = logger;
            _nftService = nftService;
            _kycService = kycService;
        }

        [HttpPost("mint")]
        [KycVerification]
        public async Task<IActionResult> MintNft([FromBody] NftMintRequest request)
        {
            try
            {
                var kycStatus = await _kycService.ValidateKycStatus(request.UserId);
                if (!kycStatus.IsValid)
                {
                    return BadRequest(new { message = "KYC verification required" });
                }

                var result = await _nftService.MintNft(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error minting NFT");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("collection/{userId}")]
        public async Task<IActionResult> GetUserCollection(string userId)
        {
            try
            {
                var collection = await _nftService.GetUserNftCollection(userId);
                return Ok(collection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving NFT collection");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("transfer")]
        [KycVerification]
        public async Task<IActionResult> TransferNft([FromBody] NftTransferRequest request)
        {
            try
            {
                var result = await _nftService.TransferNft(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error transferring NFT");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("marketplace")]
        public async Task<IActionResult> GetMarketplace([FromQuery] MarketplaceQueryParams queryParams)
        {
            try
            {
                var listings = await _nftService.GetMarketplaceListings(queryParams);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving marketplace listings");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("list")]
        public async Task<IActionResult> ListNft([FromBody] NftListingRequest request)
        {
            try
            {
                var result = await _nftService.ListNftForSale(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listing NFT");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("buy")]
        [KycVerification]
        public async Task<IActionResult> BuyNft([FromBody] NftPurchaseRequest request)
        {
            try
            {
                var result = await _nftService.PurchaseNft(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error purchasing NFT");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
