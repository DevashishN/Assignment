using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL.DataAccessLayer;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.BL.BusinessLayer
{
    public class RegisterBL : IRegisterBL
    {
        private readonly IRegisterDAL _registerDAL;

        public RegisterBL(IRegisterDAL registerDAL)
        {
            _registerDAL = registerDAL;
        }

        public bool CreateUser(User user)
        {
            bool userExist = _registerDAL.CheckMailDuplicate(user.Email);
            if(!userExist)
            {
                _registerDAL.InsertUser(user);
                return true;
            }
            return false;
        }
    }
}