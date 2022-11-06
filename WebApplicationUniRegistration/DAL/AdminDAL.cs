using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.DAL
{
    public class AdminDAL : IAdminDAL
    {
        private readonly IConnectionDAL _connection;
        public AdminDAL(IConnectionDAL connection)
        {
            _connection = connection;
        }

        public List<Student> GetStudentResults()
        {
            string query = @"SELECT Students.StudentId, Students.FirstName, Students.LastName, Students.statusId, Results.SubjectId,
                            Subjects.SubjectName, Results.SubjectGrade
                            FROM Students
                            INNER JOIN Results
                            ON Students.StudentId = Results.StudentId
                            INNER JOIN Subjects
                            ON Results.SubjectId = Subjects.SubjectId";

            DataTable Results = _connection.Query(query, null);
            List<Student> studentsWithResult = null;

            if(Results.Rows.Count > 0)
            {
                studentsWithResult = new List<Student>();
                Student student = null;
                List<Results> stuResults = null;
                List<int> studentIdList = new List<int>();
                for(int i= 0; i < Results.Rows.Count; i++)
                {                   
                    DataRow row = Results.Rows[i];
                    int currentStudentId = Convert.ToInt32(row["StudentId"]);
                    if (!studentIdList.Contains(currentStudentId)){
                        studentIdList.Add(currentStudentId);
                        if(student != null)
                        {
                            student.ResultList = stuResults;
                            studentsWithResult.Add(student);
                        }
                        student = new Student();
                        stuResults = new List<Results>();
                        student.FirstName = row["FirstName"].ToString();
                        student.LastName = row["LastName"].ToString();
                        student.Status = (Status)Convert.ToInt32(row["StatusId"]);

                    Results studentResult = new Results();
                    Subject subject = new Subject();
                    subject.SubjectName = row["SubjectName"].ToString();
                    subject.SubjectId = Convert.ToInt32(row["SubjectId"]);
                    studentResult.Subject = subject;
                    studentResult.SubjectGrade = row["SubjectGrade"].ToString();
                    stuResults.Add(studentResult);


                }
            }

            return studentsWithResult;

        }
    }
}