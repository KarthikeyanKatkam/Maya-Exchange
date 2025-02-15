using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Maya.Exchange.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required] 
        public string PasswordHash { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        [Required]
        public KycLevel KycLevel { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? LastLoginAt { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyTransactionLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        public decimal MonthlyTransactionLimit { get; set; }

        public bool TwoFactorEnabled { get; set; }
        public string TwoFactorSecret { get; set; }

        public bool EmailVerified { get; set; }
        public bool PhoneVerified { get; set; }

        public string ReferralCode { get; set; }
        public string ReferredBy { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsLocked { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int FailedLoginAttempts { get; set; }
    }

    public enum UserRole
    {
        User = 0,
        Admin = 1,
        Support = 2,
        Compliance = 3
    }

    public enum UserStatus 
    {
        Pending = 0,
        Active = 1,
        Suspended = 2,
        Deactivated = 3
    }
}
