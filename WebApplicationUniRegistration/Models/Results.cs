using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationUniRegistration.Models
{
    public class Results
    {
        public int ResultId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public char SubjectGrade { get; set; }
        public int StudentId { get; set; }

    }
}