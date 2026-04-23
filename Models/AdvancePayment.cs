using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Champerof.Infra;

namespace Champerof.Models
{
    public class AdvancePayment : EntityBase
    {
        [Key]
        public long Id { get; set; }

        public long? ClientId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? RemainingAmount { get; set; }
        public string? Status { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentMode { get; set; }
        public string? Remark { get; set; }
        // From JOIN
        [NotMapped] public string? ClientName { get; set; }
        [NotMapped] public string? StatusName { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
