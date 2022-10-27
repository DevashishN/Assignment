using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;
using WebApplicationUniRegistration.DAL;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public bool Authenticate(User user)
        {
            bool isUserValid=false;
            string email = user.Email;
            User validUser=_userDAL.GetUserByEmail(email);
            if (validUser != null)
            {
                isUserValid=BCrypt.Net.BCrypt.Verify(user.Password, validUser.Password);
            }

            return isUserValid;

        }

      
    }
}