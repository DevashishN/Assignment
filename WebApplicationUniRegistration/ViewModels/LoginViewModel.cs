using System.ComponentModel.DataAnnotations;

namespace WebApplicationUniRegistration.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150)]
        public string Password { get; set; }
    }
}