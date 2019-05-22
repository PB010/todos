using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.ViewModels.OAuthViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}