using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MayaExchange.Models
{
    public class Currency
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Code { get; set; }  // e.g. USD, BTC, ETH

        [Required]
        public string Name { get; set; }  // e.g. US Dollar, Bitcoin

        [Required]
        public CurrencyType Type { get; set; }  // Local, Crypto, or CLC

        [Required]
        public decimal ExchangeRate { get; set; }  // Rate relative to base currency

        public string Symbol { get; set; }  // e.g. $, ₿

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // For local currencies
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        // For cryptocurrencies
        public string NetworkType { get; set; }  // e.g. ERC20, BEP20
        public string ContractAddress { get; set; }
        public int Decimals { get; set; }

        // For CLC (Community Local Currency)
        public string CommunityId { get; set; }
        public string CommunityName { get; set; }
        public decimal CirculatingSupply { get; set; }
        public decimal MaxSupply { get; set; }
    }

    public enum CurrencyType
    {
        Local,      // Traditional fiat currencies
        Crypto,     // Cryptocurrencies
        CLC         // Community Local Currencies
    }
}
