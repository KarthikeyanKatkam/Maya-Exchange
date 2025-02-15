using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Maya.Exchange.Models
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FromCurrency { get; set; }

        [Required] 
        public string ToCurrency { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal ExchangeRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Fee { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public TransactionStatus Status { get; set; }

        public string ReferenceId { get; set; }

        public string FromAccountId { get; set; }

        public string ToAccountId { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer,
        Exchange,
        Fee
    }

    public enum TransactionStatus 
    {
        Pending,
        Processing,
        Completed,
        Failed,
        Cancelled
    }
}
