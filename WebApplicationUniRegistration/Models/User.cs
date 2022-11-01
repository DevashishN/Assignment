using System.ComponentModel.DataAnnotations;

namespace WebApplicationUniRegistration.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 5)]
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public Student Student { get; set; }
    }
}
