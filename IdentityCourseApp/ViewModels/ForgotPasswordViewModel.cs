using System.ComponentModel.DataAnnotations;

namespace IdentityCourseApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
