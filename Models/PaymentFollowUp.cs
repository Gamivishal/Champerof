using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Champerof.Infra;

namespace Champerof.Models
{
    public class PaymentFollowUp : EntityBase
    {
        [Key]
        public long Id { get; set; }

        public long? InvoiceId { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }

        // JOIN fields
        [NotMapped] public string? InvoiceNumber { get; set; }
        [NotMapped] public string? StatusName { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
