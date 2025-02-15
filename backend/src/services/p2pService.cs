using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Maya.Exchange.Models;
using Maya.Exchange.Data;
using Maya.Exchange.Utils;

namespace Maya.Exchange.Services
{
    public interface IP2PService
    {
        Task<P2POrder> CreateOrder(P2POrderRequest request);
        Task<List<P2POrder>> GetActiveOrders();
        Task<P2POrder> AcceptOrder(string orderId, string userId);
        Task<P2POrder> CancelOrder(string orderId, string userId);
        Task<P2PTransaction> CompleteTransaction(string orderId, string userId);
        Task<List<P2POrder>> GetUserOrders(string userId);
    }

    public class P2PService : IP2PService
    {
        private readonly IConfiguration _config;
        private readonly IDbContext _dbContext;
        private readonly IKycService _kycService;
        private readonly IWalletService _walletService;

        public P2PService(
            IConfiguration config,
            IDbContext dbContext, 
            IKycService kycService,
            IWalletService walletService)
        {
            _config = config;
            _dbContext = dbContext;
            _kycService = kycService;
            _walletService = walletService;
        }

        public async Task<P2POrder> CreateOrder(P2POrderRequest request)
        {
            // Validate KYC status
            var kycStatus = await _kycService.GetUserKycStatus(request.UserId);
            if (!kycStatus.IsVerified)
            {
                throw new UnauthorizedException("KYC verification required");
            }

            // Validate wallet balance
            var hasBalance = await _walletService.ValidateBalance(
                request.UserId, 
                request.AssetType,
                request.Amount
            );
            if (!hasBalance)
            {
                throw new InsufficientFundsException();
            }

            var order = new P2POrder
            {
                Id = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                OrderType = request.OrderType,
                AssetType = request.AssetType,
                Amount = request.Amount,
                Price = request.Price,
                PaymentMethods = request.PaymentMethods,
                Status = OrderStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.P2POrders.InsertOneAsync(order);
            return order;
        }

        public async Task<List<P2POrder>> GetActiveOrders()
        {
            var filter = Builders<P2POrder>.Filter.Eq(x => x.Status, OrderStatus.Active);
            return await _dbContext.P2POrders.Find(filter).ToListAsync();
        }

        public async Task<P2POrder> AcceptOrder(string orderId, string userId)
        {
            var order = await GetOrderById(orderId);
            if (order == null || order.Status != OrderStatus.Active)
            {
                throw new NotFoundException("Order not found or inactive");
            }

            // Validate KYC for accepting user
            var kycStatus = await _kycService.GetUserKycStatus(userId);
            if (!kycStatus.IsVerified)
            {
                throw new UnauthorizedException("KYC verification required");
            }

            order.CounterpartyId = userId;
            order.Status = OrderStatus.InProgress;
            order.UpdatedAt = DateTime.UtcNow;

            await _dbContext.P2POrders.ReplaceOneAsync(
                x => x.Id == orderId,
                order
            );

            return order;
        }

        public async Task<P2POrder> CancelOrder(string orderId, string userId)
        {
            var order = await GetOrderById(orderId);
            if (order == null || order.UserId != userId)
            {
                throw new UnauthorizedException("Unauthorized to cancel order");
            }

            order.Status = OrderStatus.Cancelled;
            order.UpdatedAt = DateTime.UtcNow;

            await _dbContext.P2POrders.ReplaceOneAsync(
                x => x.Id == orderId,
                order
            );

            return order;
        }

        public async Task<P2PTransaction> CompleteTransaction(string orderId, string userId)
        {
            var order = await GetOrderById(orderId);
            if (order == null || order.Status != OrderStatus.InProgress)
            {
                throw new NotFoundException("Order not found or not in progress");
            }

            // Transfer assets between parties
            await _walletService.TransferAssets(
                order.UserId,
                order.CounterpartyId,
                order.AssetType,
                order.Amount
            );

            order.Status = OrderStatus.Completed;
            order.UpdatedAt = DateTime.UtcNow;

            await _dbContext.P2POrders.ReplaceOneAsync(
                x => x.Id == orderId,
                order
            );

            var transaction = new P2PTransaction
            {
                Id = Guid.NewGuid().ToString(),
                OrderId = orderId,
                SellerId = order.UserId,
                BuyerId = order.CounterpartyId,
                AssetType = order.AssetType,
                Amount = order.Amount,
                Price = order.Price,
                CompletedAt = DateTime.UtcNow
            };

            await _dbContext.P2PTransactions.InsertOneAsync(transaction);
            return transaction;
        }

        public async Task<List<P2POrder>> GetUserOrders(string userId)
        {
            var filter = Builders<P2POrder>.Filter.Eq(x => x.UserId, userId);
            return await _dbContext.P2POrders.Find(filter).ToListAsync();
        }

        private async Task<P2POrder> GetOrderById(string orderId)
        {
            var filter = Builders<P2POrder>.Filter.Eq(x => x.Id, orderId);
            return await _dbContext.P2POrders.Find(filter).FirstOrDefaultAsync();
        }
    }
}
