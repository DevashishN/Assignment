using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;
using WebApplicationUniRegistration.DAL;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class LoginBL : ILoginBL
    {
        private readonly ILoginDAL _userDAL;
        public LoginBL(ILoginDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public bool Authenticate(User user)
        {
            bool isUserValid=false;
            User validUser=_userDAL.GetUserByEmail(user.Email);
            if (validUser != null)
            {
                isUserValid=BCrypt.Net.BCrypt.Verify(user.Password, validUser.Password);
            }

            return isUserValid;

        }



      
    }
}