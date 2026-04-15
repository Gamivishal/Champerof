using System.ComponentModel.DataAnnotations;

namespace Champerof.Infra
{
    public class ChangePassword
    {
     
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
