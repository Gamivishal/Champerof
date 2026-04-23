using Champerof.Infra;
using System.ComponentModel.DataAnnotations;

namespace Champerof.Models
{
    public class Clients : EntityBase
    {
        [Key]
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? GSTNumber { get; set; }
        public string? Address { get; set; }


        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
