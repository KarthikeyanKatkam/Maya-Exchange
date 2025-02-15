using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Maya.Exchange.Utils
{
    public static class Validators
    {
        // Email validation
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }

        // Password validation - requires minimum 8 chars, 1 uppercase, 1 lowercase, 1 number, 1 special char
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSpecialChar = new Regex(@"[!@#$%^&*(),.?"":{}|<>]+");
            var hasMinLength = new Regex(@".{8,}");

            return hasNumber.IsMatch(password) &&
                   hasUpperChar.IsMatch(password) &&
                   hasLowerChar.IsMatch(password) &&
                   hasSpecialChar.IsMatch(password) &&
                   hasMinLength.IsMatch(password);
        }

        // Phone number validation
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            var phoneRegex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            return phoneRegex.IsMatch(phoneNumber);
        }

        // KYC document validation
        public static bool IsValidKycDocument(string documentNumber, string documentType)
        {
            if (string.IsNullOrWhiteSpace(documentNumber) || string.IsNullOrWhiteSpace(documentType))
                return false;

            switch (documentType.ToUpper())
            {
                case "PASSPORT":
                    return new Regex(@"^[A-Z0-9]{6,9}$").IsMatch(documentNumber);
                case "NATIONAL_ID":
                    return new Regex(@"^[A-Z0-9]{8,12}$").IsMatch(documentNumber);
                case "DRIVERS_LICENSE":
                    return new Regex(@"^[A-Z0-9]{5,20}$").IsMatch(documentNumber);
                default:
                    return false;
            }
        }

        // Cryptocurrency address validation
        public static bool IsValidCryptoAddress(string address, string currency)
        {
            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(currency))
                return false;

            switch (currency.ToUpper())
            {
                case "BTC":
                    return new Regex(@"^[13][a-km-zA-HJ-NP-Z1-9]{25,34}$").IsMatch(address);
                case "ETH":
                    return new Regex(@"^0x[a-fA-F0-9]{40}$").IsMatch(address);
                default:
                    return false;
            }
        }

        // Transaction amount validation
        public static bool IsValidTransactionAmount(decimal amount, decimal minAmount, decimal maxAmount)
        {
            return amount >= minAmount && amount <= maxAmount;
        }

        // IBAN validation
        public static bool IsValidIBAN(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
                return false;

            iban = iban.ToUpper().Replace(" ", "");
            if (!new Regex(@"^[A-Z0-9]+$").IsMatch(iban))
                return false;

            if (iban.Length < 5)
                return false;

            var newIban = iban.Substring(4) + iban.Substring(0, 4);
            return ConvertIBANToInteger(newIban) % 97 == 1;
        }

        private static int ConvertIBANToInteger(string iban)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var c in iban)
            {
                if (char.IsLetter(c))
                    sb.Append((c - 'A' + 10).ToString());
                else
                    sb.Append(c);
            }
            return int.Parse(sb.ToString());
        }
    }
}
