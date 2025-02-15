using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MayaExchange.Utils
{
    public static class Helpers
    {
        // Crypto/currency conversion helpers
        public static decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency, decimal exchangeRate)
        {
            return Math.Round(amount * exchangeRate, 8);
        }

        public static string GenerateWalletAddress()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[32];
                rng.GetBytes(bytes);
                return "0x" + BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // KYC/AML validation helpers
        public static bool ValidateKYCDocument(string documentType, string documentNumber)
        {
            switch (documentType.ToLower())
            {
                case "passport":
                    return Regex.IsMatch(documentNumber, @"^[A-Z0-9]{8,9}$");
                case "nationalid":
                    return Regex.IsMatch(documentNumber, @"^[0-9]{10,12}$");
                default:
                    return false;
            }
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Transaction helpers
        public static string GenerateTransactionId()
        {
            return $"TX-{DateTime.UtcNow.Ticks}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Format helpers
        public static string FormatCurrency(decimal amount, string currencyCode)
        {
            return amount.ToString("N2", new CultureInfo("en-US")) + " " + currencyCode;
        }

        public static string FormatTimestamp(DateTime timestamp)
        {
            return timestamp.ToString("yyyy-MM-dd HH:mm:ss UTC");
        }

        // Validation helpers
        public static bool ValidateAmount(decimal amount, decimal minAmount, decimal maxAmount)
        {
            return amount >= minAmount && amount <= maxAmount;
        }

        public static bool ValidateWalletAddress(string address)
        {
            return Regex.IsMatch(address, @"^0x[a-fA-F0-9]{40}$");
        }

        // Error handling helpers
        public static string GetErrorMessage(string errorCode)
        {
            var errorMessages = new Dictionary<string, string>
            {
                {"TX_FAILED", "Transaction failed to process"},
                {"INVALID_AMOUNT", "Invalid transaction amount"},
                {"INSUFFICIENT_FUNDS", "Insufficient funds in account"},
                {"KYC_INCOMPLETE", "KYC verification incomplete"},
                {"INVALID_ADDRESS", "Invalid wallet address"}
            };

            return errorMessages.TryGetValue(errorCode, out string message) 
                ? message 
                : "An unknown error occurred";
        }
    }
}
