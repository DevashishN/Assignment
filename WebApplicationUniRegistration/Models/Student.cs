using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationUniRegistration.Models { 
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string GuardianName { get; set; }
        public string Email { get; set; }
        public string Nid { get; set; }
        //public List <Result> Results { get; set; }

        public Student() { }

        public Student(int studentId, string firstName, string lastName, string address, string phoneNumber, DateTime dateTime, string guardianName, string email, string nid)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            DateTime = dateTime;
            GuardianName = guardianName;
            Email = email;
            Nid = nid;
        }
    }
}
