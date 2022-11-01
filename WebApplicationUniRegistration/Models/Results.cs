using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationUniRegistration.Models
{
    public class Results
    {
        public int resultId { get; set; }
        public int subjectId { get; set; }
        public string subjectName { get; set; }
        public int subjectMark { get; set; }
        public int studentId { get; set; }

    }
}