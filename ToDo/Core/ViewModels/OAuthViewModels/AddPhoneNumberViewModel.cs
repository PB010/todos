using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.ViewModels.OAuthViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}