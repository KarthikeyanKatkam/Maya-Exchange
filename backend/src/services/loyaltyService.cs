using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Common;

namespace Maya.Exchange.Services
{
    public interface ILoyaltyService
    {
        Task<LoyaltyPoints> GetUserPoints(string userId);
        Task<LoyaltyTier> GetUserTier(string userId); 
        Task AddPoints(string userId, decimal amount);
        Task RedeemPoints(string userId, int points);
        Task<List<LoyaltyReward>> GetAvailableRewards(string userId);
    }

    public class LoyaltyService : ILoyaltyService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        private readonly ITransactionRepository _transactionRepo;

        public LoyaltyService(
            IConfiguration config,
            IUserRepository userRepo, 
            ITransactionRepository transactionRepo)
        {
            _config = config;
            _userRepo = userRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<LoyaltyPoints> GetUserPoints(string userId)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            return new LoyaltyPoints
            {
                UserId = userId,
                Points = user.LoyaltyPoints,
                LastUpdated = user.LoyaltyPointsLastUpdated
            };
        }

        public async Task<LoyaltyTier> GetUserTier(string userId)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            return CalculateUserTier(user.LoyaltyPoints);
        }

        public async Task AddPoints(string userId, decimal transactionAmount)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            var pointsToAdd = CalculatePointsForTransaction(transactionAmount);
            user.LoyaltyPoints += pointsToAdd;
            user.LoyaltyPointsLastUpdated = DateTime.UtcNow;

            await _userRepo.UpdateUser(user);
        }

        public async Task RedeemPoints(string userId, int points)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            if (user.LoyaltyPoints < points)
                throw new InvalidOperationException("Insufficient loyalty points");

            user.LoyaltyPoints -= points;
            user.LoyaltyPointsLastUpdated = DateTime.UtcNow;

            await _userRepo.UpdateUser(user);
        }

        public async Task<List<LoyaltyReward>> GetAvailableRewards(string userId)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            var tier = CalculateUserTier(user.LoyaltyPoints);
            return GetRewardsForTier(tier);
        }

        private LoyaltyTier CalculateUserTier(int points)
        {
            if (points >= 10000) return LoyaltyTier.Diamond;
            if (points >= 5000) return LoyaltyTier.Platinum;
            if (points >= 1000) return LoyaltyTier.Gold;
            if (points >= 100) return LoyaltyTier.Silver;
            return LoyaltyTier.Bronze;
        }

        private int CalculatePointsForTransaction(decimal amount)
        {
            // Basic calculation: 1 point per dollar spent
            return (int)Math.Floor(amount);
        }

        private List<LoyaltyReward> GetRewardsForTier(LoyaltyTier tier)
        {
            var rewards = new List<LoyaltyReward>();
            
            switch (tier)
            {
                case LoyaltyTier.Diamond:
                    rewards.Add(new LoyaltyReward { Name = "Zero Trading Fees", PointsCost = 0 });
                    rewards.Add(new LoyaltyReward { Name = "VIP Support Access", PointsCost = 0 });
                    rewards.Add(new LoyaltyReward { Name = "Exclusive Market Analysis", PointsCost = 1000 });
                    break;
                case LoyaltyTier.Platinum:
                    rewards.Add(new LoyaltyReward { Name = "Reduced Trading Fees", PointsCost = 0 });
                    rewards.Add(new LoyaltyReward { Name = "Priority Support", PointsCost = 500 });
                    break;
                case LoyaltyTier.Gold:
                    rewards.Add(new LoyaltyReward { Name = "Trading Fee Discount", PointsCost = 200 });
                    break;
                case LoyaltyTier.Silver:
                    rewards.Add(new LoyaltyReward { Name = "Basic Rewards", PointsCost = 100 });
                    break;
                default:
                    rewards.Add(new LoyaltyReward { Name = "Welcome Reward", PointsCost = 50 });
                    break;
            }

            return rewards;
        }
    }
}
