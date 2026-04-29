using Champerof.Infra;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Champerof.Models
{
    public class Invoices : EntityBase
    {
        [Key]
        public long InvoiceId { get; set; }
        public long? ClientId { get; set; }
    
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? FinalAmount { get; set; }
        public string? Status { get; set; }
        public string? InvoiceType { get; set; }
        public string? Duedays { get; set; }
        public string? Notes { get; set; }

        // From JOIN
        [NotMapped] public string? ClientName { get; set; }
        [NotMapped] public string? StatusName { get; set; }
        [NotMapped] public decimal? AdvanceAmount { get; set; }
        [NotMapped] public decimal? RemainingAmount { get; set; }
        [NotMapped] public decimal? PaidAmount { get; set; }
        [NotMapped] public decimal? PendingAmount { get; set; }
        [NotMapped] public long? Advance_ID { get; set; }
        [NotMapped] public DateTime? PaymentDate { get; set; }
        [NotMapped]public string? City { get; set; }
      [NotMapped]  public string? State { get; set; }
      [NotMapped]  public string? Pincode { get; set; }
      [NotMapped]  public string? Address { get; set; }
      [NotMapped]  public string? InvoiceTypeName { get; set; }


        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class InvoiceCombo
    {
        public Invoices Invoice { get; set; } = new();
        public List<InvoiceItems> Items { get; set; } = new();
    }

    public class InvoiceFullDto
    {
        public Invoices Invoice { get; set; } = new();
        public List<InvoiceItems> Items { get; set; } = new();
        public CompanyMaster? Company { get; set; }
        public List<TermsAndConditions> Terms { get; set; } = new();
    }

}
