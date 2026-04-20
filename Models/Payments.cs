using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Champerof.Infra;

namespace Champerof.Models
{
    public class Payments : EntityBase
    {
        [Key]
        public long PaymentId { get; set; }

        public long? ClientId { get; set; }
        public long? InvoiceId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentMode { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Notes { get; set; }

        // JOIN fields
        [NotMapped] public string? ClientName { get; set; }
        [NotMapped] public string? InvoiceNumber { get; set; }
        [NotMapped] public string? PaymentModeName { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
