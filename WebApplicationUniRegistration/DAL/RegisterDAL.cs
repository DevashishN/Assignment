using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;
using System.Web.Helpers;

namespace WebApplicationUniRegistration.DAL
{
    public class RegisterDAL : IRegisterDAL
    {
        private readonly IConnectionDAL _connection;

        public RegisterDAL(IConnectionDAL connection)
        {
            _connection = connection;
        }

        public bool CheckMailDuplicate(String email)
        {
            string query = @"select TOP 1* from users where EmailAddress=@EmailAddress";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", email));

            DataTable results = _connection.Query(query, parameters);

            if (results.Rows.Count > 0)
            {
                return true;
            }
            return false;

        }

        public bool InsertUser(User user)
        {
            string userEmail = "user.Email";
            string userHashedPassword = Crypto.HashPassword(user.Password);
            //Step 2 creat a command
            string query = "INSERT INTO Users([EmailAddress], [Password], [RoleId]) VALUES (@userEmail, @userHashedPassword, @userRoleId);";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@userEmail", user.Email));
            parameters.Add(new SqlParameter("@userHashedPassword", userHashedPassword));
            parameters.Add(new SqlParameter("@userRoleId",Role.user ));

            DataTable results = _connection.Query(query, parameters);
            if (results.Rows.Count > 0)
            {
                return true;
            }
            return false;



        }
    }
}