using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.ViewModels.OAuthViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
