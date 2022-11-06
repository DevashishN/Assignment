using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class RoleBL : IRoleBL
    {
        private readonly IRoleDAL _roleDAL;
        public RoleBL(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public Role? getUserRole(int userId)
        {
            return _roleDAL.getUserRole(userId);
        }
    }
}