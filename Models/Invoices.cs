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
        public string? Notes { get; set; }

        // From JOIN
        [NotMapped] public string? ClientName { get; set; }
        [NotMapped] public string? StatusName { get; set; }

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
