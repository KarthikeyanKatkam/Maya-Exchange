using System;
using System.Collections.Generic;

namespace Maya.Exchange.Utils
{
    // Transaction Types
    public enum TransactionType
    {
        LocalCurrency,
        CrossLocalCurrency, 
        Crypto
    }

    // KYC Levels
    public enum KycLevel
    {
        Basic,
        Intermediate,
        Advanced
    }

    // Transaction Status
    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed,
        Cancelled
    }

    // User Roles
    public enum UserRole
    {
        User,
        Admin,
        Support
    }

    // Currency Types
    public enum CurrencyType
    {
        Fiat,
        Crypto
    }

    // Transaction Request Types
    public class TransactionRequest
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public TransactionType Type { get; set; }
    }

    // KYC Status Response
    public class KycStatusResponse
    {
        public bool IsValid { get; set; }
        public KycLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    // Transaction Result
    public class TransactionResult
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
        public TransactionStatus Status { get; set; }
        public string Message { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public DateTime Timestamp { get; set; }
    }

    // User Balance
    public class UserBalance
    {
        public string UserId { get; set; }
        public Dictionary<string, decimal> Balances { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    // API Response
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
