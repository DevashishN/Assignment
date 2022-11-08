using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL.DataAccessLayer;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.BL.BusinessLayer
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminDAL _adminDAL;

        public AdminBL(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public List<Student> GetAllStudentResults()
        {
            List<Student> studentsWithTotalScore = CalculateScore(_adminDAL.GetStudentResults());

            var studentsInDescOrder = studentsWithTotalScore.OrderByDescending(student => student.TotalScore);

            var studentsWithStatus = AssignStatusToAllStudents(studentsWithTotalScore);
            
            return studentsWithStatus;
        }

        private List<Student> CalculateScore(List<Student> myStudents)
        {
            
            for(int studentCount = 0; studentCount < myStudents.Count; studentCount++)
            {
                int score = 0;
                for (int resultIndex=0; resultIndex < myStudents[studentCount].ResultList.Count; resultIndex++)
                {
                    var studGrade = myStudents[studentCount].ResultList[resultIndex].SubjectGrade;
                    var grade=(Grade)Enum.Parse(typeof(Grade), studGrade);
                    score += (int)grade;
                }
                myStudents[studentCount].TotalScore = score;
            }
            return myStudents;
        }

        private List<Student> AssignStatusToAllStudents(List<Student> myStudents)
        {
            if (myStudents.Count > 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    myStudents[i]= AssignStatusToStudent(myStudents[i], false);

                }
                for (int i = 15; i < myStudents.Count; i++)
                {
                    myStudents[i] = AssignStatusToStudent(myStudents[i], true);
                }
            }
            else
            {
                for (int i = 0; i < myStudents.Count; i++)
                {
                    myStudents[i] = AssignStatusToStudent(myStudents[i], false);
                }
            }
            return myStudents;
        }

        private Student AssignStatusToStudent(Student student, bool waiting)
        {
            if (student != null)
            {
                if (waiting)
                {
                    if(student.TotalScore <10) 
                    {
                        student.Status = Status.Rejected;
                    }
                    else
                    {
                        student.Status = Status.Waiting;
                    }
                }
                else
                {
                    if (student.TotalScore >= 10)
                    {
                        student.Status = Status.Approved;
                    }
                    else
                    {
                        student.Status = Status.Rejected;
                    }

                }
            }
            return student;
        }
    }
}