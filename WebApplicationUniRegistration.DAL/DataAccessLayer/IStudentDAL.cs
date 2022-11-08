using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.DAL.DataAccessLayer
{
    public interface IStudentDAL
    {
        bool CheckDuplicate(string nationalId, string email, string phoneNumber);
        bool InsertStudent(Student student);
        bool CheckStudentExist(int userId);
    }
}
