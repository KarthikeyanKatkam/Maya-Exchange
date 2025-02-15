using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Maya.Exchange.Config
{
    public class CryptoConfig
    {
        private readonly IConfiguration _configuration;
        
        public CryptoConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetBlockchainNetwork()
        {
            return _configuration["Crypto:Network"];
        }

        public string GetNodeEndpoint()
        {
            return _configuration["Crypto:NodeEndpoint"];
        }

        public string GetWalletPrivateKey()
        {
            return _configuration["Crypto:WalletPrivateKey"];
        }

        public string GetWalletAddress()
        {
            return _configuration["Crypto:WalletAddress"];
        }

        public decimal GetMinimumTransactionAmount()
        {
            return decimal.Parse(_configuration["Crypto:MinimumTransactionAmount"]);
        }

        public decimal GetMaximumTransactionAmount()
        {
            return decimal.Parse(_configuration["Crypto:MaximumTransactionAmount"]);
        }

        public decimal GetGasLimit()
        {
            return decimal.Parse(_configuration["Crypto:GasLimit"]);
        }

        public decimal GetGasPrice()
        {
            return decimal.Parse(_configuration["Crypto:GasPrice"]);
        }

        public List<string> GetSupportedTokens()
        {
            return _configuration.GetSection("Crypto:SupportedTokens").Get<List<string>>();
        }

        public string GetContractAddress(string tokenSymbol)
        {
            return _configuration[$"Crypto:Contracts:{tokenSymbol}"];
        }

        public string GetExplorerUrl()
        {
            return _configuration["Crypto:ExplorerUrl"];
        }

        public int GetConfirmationBlocks()
        {
            return int.Parse(_configuration["Crypto:ConfirmationBlocks"]);
        }
    }
}
