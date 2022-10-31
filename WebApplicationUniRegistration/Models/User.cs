using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationUniRegistration.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public Student Student { get; set; }
        public User() { }

        public User(string emailAddress, string password, string roleName, int roleId)
        {
            Email = emailAddress;
            Password = password;
            RoleName = roleName;
            RoleId = roleId;
        }
    }
}
