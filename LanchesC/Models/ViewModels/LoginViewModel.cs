using System.ComponentModel.DataAnnotations;

namespace LanchesC.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Inform the username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inform the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
