using Champerof.Infra;
using System.ComponentModel.DataAnnotations;

namespace Champerof.Models
{
    public class Services : EntityBase
    {
        [Key]
        public long ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? DefaultPrice { get; set; }
        public string? Description { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
