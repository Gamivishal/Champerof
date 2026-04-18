using Champerof.Infra;
using System.ComponentModel.DataAnnotations;

namespace Champerof.Models
{
    public class CompanyMaster : EntityBase
    {
        [Key]
        public long Id { get; set; }

        public string? AccountNo { get; set; }
        public string? AccountName { get; set; }
        public string? Bank { get; set; }
        public string? IFSCCode { get; set; }
        public string? PAN { get; set; }

        public string? SignFileName { get; set; }
        public string? SignContentType { get; set; }
        public byte[]? SignData { get; set; }

        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class CompanyMasterFormDto
    {
        public long Id { get; set; }

        public string? AccountNo { get; set; }
        public string? AccountName { get; set; }
        public string? Bank { get; set; }
        public string? IFSCCode { get; set; }
        public string? PAN { get; set; }

        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
