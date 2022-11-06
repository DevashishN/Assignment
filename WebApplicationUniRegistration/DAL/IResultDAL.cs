using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public interface IResultDAL
    {
        bool enterStudentResults(List<Results> resultList, int userId);
    }
}
