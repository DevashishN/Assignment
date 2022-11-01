using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public interface IStudentBL
    {
        bool Enroll(Student student);
    }
}
