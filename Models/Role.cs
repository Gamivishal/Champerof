using Champerof.Infra;
using System.ComponentModel.DataAnnotations.Schema;
using Champerof.Infra;

namespace Champerof.Models
{
    public class Role : EntityBase
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        [NotMapped]
        public bool? IsDeleted { get; set; }
        public bool? IsAdmin { get; set; }
        public string? SelectedMenu { get; set; }
    }
}
