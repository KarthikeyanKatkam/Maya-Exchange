using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Maya.Models;
using Maya.Utils;
using Maya.Interfaces;

namespace Maya.Services
{
    public class MayaVisaCardService : IMayaVisaCardService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IKycService _kycService;
        private readonly ITransactionService _transactionService;

        public MayaVisaCardService(
            IConfiguration configuration,
            HttpClient httpClient,
            IKycService kycService, 
            ITransactionService transactionService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _kycService = kycService;
            _transactionService = transactionService;
        }

        public async Task<VisaCardResponse> IssueVisaCard(string userId, VisaCardRequest request)
        {
            // Verify KYC status before issuing card
            var kycStatus = await _kycService.GetUserKycStatus(userId);
            if (!kycStatus.IsVerified)
            {
                throw new UnauthorizedAccessException("KYC verification required to issue Visa card");
            }

            // Call Visa card issuing API
            var response = await CreateVisaCard(userId, request);

            // Record transaction
            await _transactionService.RecordCardIssuance(
                userId,
                response.CardId,
                request.CardType,
                request.Currency
            );

            return response;
        }

        public async Task<VisaCardDetails> GetCardDetails(string userId, string cardId)
        {
            // Verify card ownership
            await ValidateCardOwnership(userId, cardId);

            var endpoint = $"{_configuration["VisaApi:BaseUrl"]}/cards/{cardId}";
            var response = await _httpClient.GetAsync(endpoint);
            
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VisaCardDetails>(content);
        }

        public async Task<TransactionResponse> ProcessCardTransaction(string userId, CardTransaction transaction)
        {
            // Verify card ownership
            await ValidateCardOwnership(userId, transaction.CardId);

            // Process transaction through Visa API
            var response = await ExecuteTransaction(transaction);

            // Record transaction
            await _transactionService.RecordCardTransaction(
                userId,
                transaction.CardId,
                transaction.Amount,
                transaction.Currency,
                transaction.MerchantInfo
            );

            return response;
        }

        private async Task<VisaCardResponse> CreateVisaCard(string userId, VisaCardRequest request)
        {
            var endpoint = $"{_configuration["VisaApi:BaseUrl"]}/cards";
            
            var cardRequest = new
            {
                userId = userId,
                cardType = request.CardType,
                currency = request.Currency,
                billingAddress = request.BillingAddress,
                // Add other required card creation parameters
            };

            var response = await _httpClient.PostAsJsonAsync(endpoint, cardRequest);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VisaCardResponse>(content);
        }

        private async Task ValidateCardOwnership(string userId, string cardId)
        {
            var cardDetails = await GetCardDetails(userId, cardId);
            if (cardDetails.UserId != userId)
            {
                throw new UnauthorizedAccessException("User is not authorized to access this card");
            }
        }

        private async Task<TransactionResponse> ExecuteTransaction(CardTransaction transaction)
        {
            var endpoint = $"{_configuration["VisaApi:BaseUrl"]}/transactions";
            
            var response = await _httpClient.PostAsJsonAsync(endpoint, transaction);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TransactionResponse>(content);
        }
    }
}
