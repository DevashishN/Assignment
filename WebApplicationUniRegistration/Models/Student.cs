using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationUniRegistration.Models { 
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter a valid phone number")]
        [StringLength(8)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You should be atleast 18 yars old to register")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please provide your parents name")]
        public string GuardianName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your National Id")]
        [StringLength(14)]
        public string NationalId { get; set; }

        public List<Results> ResultList { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
    }
}
