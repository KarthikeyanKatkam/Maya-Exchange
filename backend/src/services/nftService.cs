using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Interfaces;

namespace Maya.Exchange.Services
{
    public class NftService : INftService
    {
        private readonly IConfiguration _configuration;
        private readonly INftRepository _nftRepository;
        private readonly IKycService _kycService;

        public NftService(
            IConfiguration configuration,
            INftRepository nftRepository,
            IKycService kycService)
        {
            _configuration = configuration;
            _nftRepository = nftRepository;
            _kycService = kycService;
        }

        public async Task<NftMetadata> MintNftAsync(NftMintRequest request, string userId)
        {
            // Verify KYC status before minting
            var kycStatus = await _kycService.GetUserKycStatusAsync(userId);
            if (!kycStatus.IsVerified)
            {
                throw new UnauthorizedAccessException("KYC verification required for NFT minting");
            }

            var metadata = new NftMetadata
            {
                TokenId = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                Image = request.ImageUri,
                CreatorId = userId,
                CreatedAt = DateTime.UtcNow,
                Properties = request.Properties,
                RoyaltyPercentage = request.RoyaltyPercentage
            };

            await _nftRepository.CreateAsync(metadata);
            return metadata;
        }

        public async Task<NftMetadata> GetNftMetadataAsync(string tokenId)
        {
            return await _nftRepository.GetByIdAsync(tokenId);
        }

        public async Task<IEnumerable<NftMetadata>> GetUserNftsAsync(string userId)
        {
            return await _nftRepository.GetByCreatorIdAsync(userId);
        }

        public async Task<NftTransferResult> TransferNftAsync(string tokenId, string fromUserId, string toUserId)
        {
            var nft = await _nftRepository.GetByIdAsync(tokenId);
            if (nft == null)
            {
                throw new KeyNotFoundException("NFT not found");
            }

            if (nft.CreatorId != fromUserId)
            {
                throw new UnauthorizedAccessException("Not authorized to transfer this NFT");
            }

            // Verify recipient's KYC status
            var recipientKycStatus = await _kycService.GetUserKycStatusAsync(toUserId);
            if (!recipientKycStatus.IsVerified)
            {
                throw new UnauthorizedAccessException("Recipient must complete KYC verification");
            }

            nft.CreatorId = toUserId;
            nft.LastTransferredAt = DateTime.UtcNow;

            await _nftRepository.UpdateAsync(nft);

            return new NftTransferResult
            {
                TokenId = tokenId,
                FromUserId = fromUserId,
                ToUserId = toUserId,
                TransferredAt = nft.LastTransferredAt.Value
            };
        }

        public async Task<bool> BurnNftAsync(string tokenId, string userId)
        {
            var nft = await _nftRepository.GetByIdAsync(tokenId);
            if (nft == null)
            {
                throw new KeyNotFoundException("NFT not found");
            }

            if (nft.CreatorId != userId)
            {
                throw new UnauthorizedAccessException("Not authorized to burn this NFT");
            }

            return await _nftRepository.DeleteAsync(tokenId);
        }
    }
}
