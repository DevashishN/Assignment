using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.DAL.DataAccessLayer
{
    public interface IRoleDAL
    {
        Role? getUserRole(int userId);
    }
}
