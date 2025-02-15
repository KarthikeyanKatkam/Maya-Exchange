using System;

namespace Maya.Exchange.Utils
{
    public static class Constants
    {
        // API Endpoints
        public const string UsersEndpoint = "/api/users";
        public const string TransactionsEndpoint = "/api/transactions"; 
        public const string SendEndpoint = "/api/send";
        public const string ReceiveEndpoint = "/api/receive";
        public const string ConvertEndpoint = "/api/convert";
        public const string KycEndpoint = "/api/kyc";

        // Transaction Types
        public const string LocalCurrencyTransaction = "LCC";
        public const string CrossLocalCurrencyTransaction = "CLC"; 
        public const string CryptoTransaction = "CC";

        // KYC Levels
        public const string KycLevelBasic = "BASIC";
        public const string KycLevelIntermediate = "INTERMEDIATE";
        public const string KycLevelAdvanced = "ADVANCED";

        // Transaction Limits
        public const decimal BasicKycDailyLimit = 1000;
        public const decimal IntermediateKycDailyLimit = 10000;
        public const decimal AdvancedKycDailyLimit = 100000;

        // Timeouts
        public const int DefaultTimeoutSeconds = 30;
        public const int ExtendedTimeoutSeconds = 60;

        // Cache Keys
        public const string UserCacheKey = "user:{0}";
        public const string TransactionCacheKey = "transaction:{0}";
        public const string KycCacheKey = "kyc:{0}";

        // Error Messages
        public const string UnauthorizedError = "Unauthorized access";
        public const string KycRequiredError = "KYC verification required";
        public const string InsufficientFundsError = "Insufficient funds";
        public const string InvalidAmountError = "Invalid amount";
        public const string TransactionFailedError = "Transaction failed";

        // Success Messages
        public const string TransactionSuccessMessage = "Transaction completed successfully";
        public const string KycUpdateSuccessMessage = "KYC status updated successfully";

        // File Paths
        public const string LogFilePath = "logs/maya-exchange.log";
        public const string ConfigFilePath = "config/app.config";
        public const string TemplatesPath = "templates/";

        // Misc
        public const string DefaultLanguage = "en";
        public const string DefaultTheme = "light";
        public const int MaxRetryAttempts = 3;
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
    }
}
