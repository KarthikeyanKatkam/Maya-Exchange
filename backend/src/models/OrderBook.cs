using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Maya.Exchange.Models
{
    public class OrderBook
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string BaseCurrency { get; set; }  // The currency being traded (e.g. BTC)

        [Required] 
        public string QuoteCurrency { get; set; }  // The currency used to price (e.g. USD)

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal LastPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")] 
        public decimal BestBid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal BestAsk { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Volume24H { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceChange24H { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceChangePercent24H { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal High24H { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Low24H { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Trading limits
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal MinTradeAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal MaxTradeAmount { get; set; }

        // KYC level required for trading this pair
        [Required]
        public KycLevel RequiredKycLevel { get; set; }

        // Trading fees in percentage
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal MakerFee { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TakerFee { get; set; }
    }
}
