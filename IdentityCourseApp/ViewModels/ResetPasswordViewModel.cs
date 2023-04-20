using System.ComponentModel.DataAnnotations;

namespace IdentityCourseApp.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords DON'T match!")]
        public string ConfirmPassword { get; set; }
        public string? Code { get; set; }
    }
}
