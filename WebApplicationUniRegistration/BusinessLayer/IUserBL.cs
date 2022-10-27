using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public interface IUserBL
    {
        bool Authenticate(User user);
    }
}