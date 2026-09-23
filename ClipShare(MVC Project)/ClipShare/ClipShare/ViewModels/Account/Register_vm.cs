using System.ComponentModel.DataAnnotations;

namespace ClipShare_Youtube_.ViewModels.Account
{
    public class Register_vm
    {
        [Display(Name = "Name (UserName)")]
        [Required(ErrorMessage = "Name (UserName) Is Required.")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Is Required.")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "ConfirmPassword Is Required.")]
        public string ConfirmPassword { get; set; }


        public bool IsAdmin { get; set; } = false;
    }
}
