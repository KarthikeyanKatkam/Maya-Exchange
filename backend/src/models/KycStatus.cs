using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maya.Exchange.Models
{
    public class KycStatus
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public KycLevel Level { get; set; }

        [Required]
        public KycVerificationStatus Status { get; set; }

        [Required]
        public DateTime SubmittedAt { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public string RejectionReason { get; set; }

        [Required]
        public bool IsDocumentSubmitted { get; set; }

        [Required] 
        public bool IsAddressVerified { get; set; }

        [Required]
        public bool IsIdentityVerified { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TransactionLimit { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public enum KycLevel
    {
        None = 0,
        Basic = 1,
        Advanced = 2,
        Full = 3
    }

    public enum KycVerificationStatus
    {
        Pending = 0,
        InProgress = 1,
        Verified = 2,
        Rejected = 3,
        Expired = 4
    }
}
