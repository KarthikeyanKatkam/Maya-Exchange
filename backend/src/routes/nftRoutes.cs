using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using MayaExchange.Models;
using MayaExchange.Services;
using MayaExchange.Middleware;

namespace MayaExchange.Routes
{
    [ApiController]
    [Route("api/nft")]
    public class NftRoutes : ControllerBase
    {
        private readonly INftService _nftService;
        private readonly IKycService _kycService;
        private readonly IAuthenticationService _authService;

        public NftRoutes(
            INftService nftService,
            IKycService kycService,
            IAuthenticationService authService)
        {
            _nftService = nftService;
            _kycService = kycService;
            _authService = authService;
        }

        [HttpGet("collections")]
        public async Task<IActionResult> GetNftCollections()
        {
            try
            {
                var collections = await _nftService.GetAllCollections();
                return Ok(collections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("collection/{id}")]
        public async Task<IActionResult> GetCollectionById(string id)
        {
            try
            {
                var collection = await _nftService.GetCollectionById(id);
                if (collection == null)
                    return NotFound();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("mint")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> MintNft([FromBody] NftMintRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var mintedNft = await _nftService.MintNft(userId, request);
                return Ok(mintedNft);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("transfer")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> TransferNft([FromBody] NftTransferRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                await _nftService.TransferNft(userId, request);
                return Ok(new { message = "NFT transferred successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("owned")]
        [Authorize]
        public async Task<IActionResult> GetOwnedNfts()
        {
            try
            {
                var userId = User.Identity.Name;
                var ownedNfts = await _nftService.GetUserNfts(userId);
                return Ok(ownedNfts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("marketplace/list")]
        [Authorize]
        [KycVerification]
        public async Task<IActionResult> ListNftForSale([FromBody] NftListingRequest request)
        {
            try
            {
                var userId = User.Identity.Name;
                var listing = await _nftService.CreateNftListing(userId, request);
                return Ok(listing);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("marketplace")]
        public async Task<IActionResult> GetMarketplaceListings()
        {
            try
            {
                var listings = await _nftService.GetActiveListings();
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
