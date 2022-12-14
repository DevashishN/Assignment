using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public class LoginDAL : ILoginDAL
    {
        private readonly IConnectionDAL _connection;
        public LoginDAL(IConnectionDAL connection)
        {
            _connection = connection;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;

            string query = @"select UserId, EmailAddress, Password from Users where EmailAddress = @EmailAddress";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", email));

            DataTable results = _connection.Query(query, parameters);

            if (results.Rows.Count > 0)
            {
                DataRow row = results.Rows[0];
                user = new User();
                user.UserId = (int)row["UserId"];
                user.Email = (string)row["EmailAddress"];
                user.Password = row["Password"].ToString();
            }

            return user;
        }
    }
}