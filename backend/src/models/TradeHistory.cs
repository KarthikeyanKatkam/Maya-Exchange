using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Maya.Exchange.Models
{
    public class TradeHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public string FromCurrency { get; set; }

        [Required] 
        public string ToCurrency { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal FromAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal ToAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal ExchangeRate { get; set; }

        [Required]
        public TradeType Type { get; set; }

        [Required]
        public TradeStatus Status { get; set; }

        [Column(TypeName = "decimal(18,8)")]
        public decimal Fee { get; set; }

        public string TransactionHash { get; set; }

        public string NetworkType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }

        public string FailureReason { get; set; }
    }

    public enum TradeType
    {
        Buy,
        Sell,
        Convert
    }

    public enum TradeStatus 
    {
        Pending,
        Processing,
        Completed,
        Failed,
        Cancelled
    }
}
