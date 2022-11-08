using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.DAL.DataAccessLayer
{
    public class RoleDAL : IRoleDAL
    {
        private readonly IConnectionDAL _connectionDAL;
        public RoleDAL(IConnectionDAL connectionDAL)
        {
            _connectionDAL = connectionDAL;
        }
        public Role? getUserRole(int userId)
        {
            string query = @"SELECT RoleId FROM Users WHERE UserId = @userId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@userId", userId));

            DataTable results = _connectionDAL.Query(query, parameters);
            Role? UserRole = null;
            if (results.Rows.Count > 0)
            {
                int RoleNumber = Convert.ToInt32(results.Rows[0]["RoleId"]);               
                UserRole = (Role)RoleNumber;
            }
            return UserRole;
        }
    }
}