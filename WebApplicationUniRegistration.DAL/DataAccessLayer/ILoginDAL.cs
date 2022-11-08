using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.DAL.DataAccessLayer
{
    public interface ILoginDAL
    {
        User GetUserByEmail(string email);
    }
}