using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public interface IReferralService
    {
        Task<ReferralCode> GenerateReferralCode(string userId);
        Task<bool> ValidateReferralCode(string code);
        Task<ReferralReward> ProcessReferralReward(string referrerId, string refereeId);
        Task<List<ReferralHistory>> GetReferralHistory(string userId);
        Task<ReferralStats> GetReferralStats(string userId);
    }

    public class ReferralService : IReferralService
    {
        private readonly IConfiguration _config;
        private readonly IDbContext _dbContext;
        private readonly IUserService _userService;

        public ReferralService(
            IConfiguration config,
            IDbContext dbContext,
            IUserService userService)
        {
            _config = config;
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ReferralCode> GenerateReferralCode(string userId)
        {
            var code = await CreateUniqueReferralCode();
            var referralCode = new ReferralCode
            {
                Code = code,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _dbContext.ReferralCodes.InsertOneAsync(referralCode);
            return referralCode;
        }

        public async Task<bool> ValidateReferralCode(string code)
        {
            var referralCode = await _dbContext.ReferralCodes
                .Find(r => r.Code == code && r.IsActive)
                .FirstOrDefaultAsync();
            
            return referralCode != null;
        }

        public async Task<ReferralReward> ProcessReferralReward(string referrerId, string refereeId)
        {
            // Verify eligibility
            if (!await IsEligibleForReward(referrerId, refereeId))
            {
                throw new InvalidOperationException("Not eligible for referral reward");
            }

            var reward = new ReferralReward
            {
                ReferrerId = referrerId,
                RefereeId = refereeId,
                RewardAmount = _config.GetValue<decimal>("ReferralRewardAmount"),
                Status = RewardStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.ReferralRewards.InsertOneAsync(reward);
            await UpdateReferralStats(referrerId);

            return reward;
        }

        public async Task<List<ReferralHistory>> GetReferralHistory(string userId)
        {
            return await _dbContext.ReferralHistory
                .Find(h => h.ReferrerId == userId)
                .ToListAsync();
        }

        public async Task<ReferralStats> GetReferralStats(string userId)
        {
            var stats = await _dbContext.ReferralStats
                .Find(s => s.UserId == userId)
                .FirstOrDefaultAsync();

            return stats ?? new ReferralStats { UserId = userId };
        }

        private async Task<string> CreateUniqueReferralCode()
        {
            string code;
            do
            {
                code = GenerateCode();
            } while (await ValidateReferralCode(code));

            return code;
        }

        private string GenerateCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private async Task<bool> IsEligibleForReward(string referrerId, string refereeId)
        {
            var referrer = await _userService.GetUserById(referrerId);
            var referee = await _userService.GetUserById(refereeId);

            return referrer != null && 
                   referee != null && 
                   referee.KycStatus == KycStatus.Verified &&
                   !await HasExistingReferral(refereeId);
        }

        private async Task<bool> HasExistingReferral(string refereeId)
        {
            var existingReward = await _dbContext.ReferralRewards
                .Find(r => r.RefereeId == refereeId)
                .FirstOrDefaultAsync();

            return existingReward != null;
        }

        private async Task UpdateReferralStats(string userId)
        {
            var update = Builders<ReferralStats>.Update
                .Inc(s => s.TotalReferrals, 1)
                .Inc(s => s.PendingRewards, 1);

            await _dbContext.ReferralStats.UpdateOneAsync(
                s => s.UserId == userId,
                update,
                new UpdateOptions { IsUpsert = true }
            );
        }
    }
}
