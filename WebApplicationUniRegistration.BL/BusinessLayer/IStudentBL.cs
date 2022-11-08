using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.BL.BusinessLayer
{
    public interface IStudentBL
    {
        bool Enroll(Student student);
        bool CheckIfStudentExist(int userId);
    }
}
