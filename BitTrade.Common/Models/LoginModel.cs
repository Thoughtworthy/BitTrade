using System.ComponentModel.DataAnnotations;

namespace BitTrade.Common.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public string EmailErrorMessage { get; set; }
        public string PasswordErrorMessage { get; set; }


    }
}
