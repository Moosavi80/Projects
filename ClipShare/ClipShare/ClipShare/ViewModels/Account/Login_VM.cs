using System.ComponentModel.DataAnnotations;

namespace ClipShare_Youtube_.ViewModels.Account
{
    public class Login_VM
    {
        private string _username;

        [Display(Name = "UserName Or Email")]
        [Required(ErrorMessage = "UserName Is Required.")]
        public string UserName { get => _username; set => _username = value?.ToLower(); }

        [Required(ErrorMessage = "Password Is Required.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
