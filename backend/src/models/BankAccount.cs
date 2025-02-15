using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maya.Exchange.Models.Enums;

namespace Maya.Exchange.Models
{
    public class BankAccount
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)] 
        public string BankName { get; set; }

        [Required]
        [StringLength(11)]
        public string IFSCCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountHolderName { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public AccountStatus Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        public string Currency { get; set; }

        public bool IsVerified { get; set; }

        public bool IsPrimary { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? LastTransactionDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        // Navigation property for User
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public enum AccountType
    {
        Savings,
        Current,
        Wallet,
        Investment
    }

    public enum AccountStatus 
    {
        Active,
        Inactive,
        Blocked,
        PendingVerification
    }
}
