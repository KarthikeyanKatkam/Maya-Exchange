using Microsoft.Extensions.Configuration;

namespace Maya.Exchange.Config
{
    public class BankingConfig
    {
        private readonly IConfiguration _configuration;
        
        public BankingConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetBankApiEndpoint()
        {
            return _configuration["Banking:ApiEndpoint"];
        }

        public string GetBankApiKey() 
        {
            return _configuration["Banking:ApiKey"];
        }

        public string GetBankAccountNumber()
        {
            return _configuration["Banking:AccountNumber"];
        }

        public string GetBankRoutingNumber()
        {
            return _configuration["Banking:RoutingNumber"]; 
        }

        public string GetBankName()
        {
            return _configuration["Banking:BankName"];
        }

        public string GetBankBranchCode()
        {
            return _configuration["Banking:BranchCode"];
        }

        public string GetBankSwiftCode()
        {
            return _configuration["Banking:SwiftCode"];
        }

        public string GetBankIbanNumber()
        {
            return _configuration["Banking:IbanNumber"];
        }

        public decimal GetMinimumTransactionAmount()
        {
            return decimal.Parse(_configuration["Banking:MinimumTransactionAmount"]);
        }

        public decimal GetMaximumTransactionAmount()
        {
            return decimal.Parse(_configuration["Banking:MaximumTransactionAmount"]);
        }

        public decimal GetTransactionFeePercentage()
        {
            return decimal.Parse(_configuration["Banking:TransactionFeePercentage"]);
        }
    }
}
