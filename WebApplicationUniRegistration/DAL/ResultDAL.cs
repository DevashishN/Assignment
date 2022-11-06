using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.BusinessLayer;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public class ResultDAL : IResultDAL
    {
        private readonly IConnectionDAL _connection;

        public ResultDAL(IConnectionDAL connection)
        {
            _connection = connection;
        }

        public bool enterStudentResults(List<Results> studentResults, int userId)
        {
            var success = false; 
            string query = @"select StudentId from Students where UserId = @UserId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            DataTable results = _connection.Query(query, parameters);
            if(results.Rows.Count > 0)
            {
                int studentIdRetrieved = Convert.ToInt32(results.Rows[0]["StudentId"]);
                for(int i =0; i < studentResults.Count; i++)
                {
                    query = @"insert into results (SubjectId, SubjectGrade, StudentId) values (@SubjectId, @SubjectGrade, @StudentId)";
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@SubjectId", studentResults[i].Subject.SubjectId));
                    parameters.Add(new SqlParameter("@SubjectGrade", studentResults[i].SubjectGrade));
                    parameters.Add(new SqlParameter("@StudentId", studentIdRetrieved));

                    int insert = _connection.Insert(query, parameters);
                    success = insert > 0;
                }
                
            }
            
            
                return success;
        }
    }
}