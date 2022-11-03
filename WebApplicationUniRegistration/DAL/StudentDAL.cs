using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private readonly IConnectionDAL _connection;

        public StudentDAL(IConnectionDAL connection)
        {
            _connection = connection;
        }

        public bool CheckDuplicate(string nationalId, string email, string phoneNumber)
        {
            string query = @"select TOP 1* from students where (NationalId=@NationalId OR EmailAddress = @EmailAddress
                                                            OR PhoneNumber = @PhoneNumber)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@NationalId", nationalId));
            parameters.Add(new SqlParameter("@EmailAddress", email));
            parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));

            DataTable results = _connection.Query(query, parameters);

            if (results.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        public bool InsertStudent(Student student)
        {
            //Step 2 creat a command
            string query = @"INSERT INTO Students([FirstName], [LastName], [Address], [PhoneNumber], [DateOfBirth], [GuardianName],
                             [EmailAddress], [NationalId], [StatusId], [UserId]) 
                             VALUES (@FirstName, @LastName, @Address, @PhoneNumber,
                             @DateOfBirth, @GuardianName, @EmailAddress, @NationalId, @StatusId, @UserId);";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@LastName", student.LastName));
            parameters.Add(new SqlParameter("@Address", student.Address));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            parameters.Add(new SqlParameter("@EmailAddress", student.Email));
            parameters.Add(new SqlParameter("@NationalId", student.NationalId));
            parameters.Add(new SqlParameter("@UserId", student.UserId));
            parameters.Add(new SqlParameter("@StatusId", student.Status));


            DataTable results = _connection.Query(query, parameters);
            if (results.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}