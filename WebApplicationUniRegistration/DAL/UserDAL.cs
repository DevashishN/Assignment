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
    public class UserDAL : IUserDAL
    {
        private readonly ICDAL _connection;
        public UserDAL(ICDAL connection)
        {
            _connection = connection;
        }
        public User GetUserByEmail(string email)
        {
            User user=null;

            string query = @"select EmailAddress, Password from users where EmailAddress=@EmailAddress";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", email));


            DataTable results = _connection.Query(query, parameters);

            if (results.Rows.Count > 0)
            {
                DataRow row=results.Rows[0];
                user = new User();
                user.Email = email;
                user.Password = row["Password"].ToString();
            }

            return user;
        }
    }
}