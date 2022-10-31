using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public interface IRegisterDAL
    {
        bool CheckMailDuplicate(string email);
        bool InsertUser(User user);
    }
}
