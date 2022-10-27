using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public interface IUserDAL
    {
        User GetUserByEmail(string email);
    }
}