using Champerof.Infra;
using System.ComponentModel.DataAnnotations;

namespace Champerof.Models
{
    public class TermsAndConditions : EntityBase
    {
        [Key]
        public long Id { get; set; }

        public string? Terms { get; set; }

        public int? DisplaySeqNo { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
