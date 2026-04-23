using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Champerof.Infra;

namespace Champerof.Models
{
    public class InvoiceItems : EntityBase
    {
        [Key]
        public long ItemId { get; set; }

        public long? InvoiceId { get; set; }
        public long? ServiceId { get; set; }
      //  public string? ItemType { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsTaxable { get; set; }

        [NotMapped] public string? InvoiceNumber { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
