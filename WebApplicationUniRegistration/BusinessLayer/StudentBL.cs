using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDAL _studentDAL;
        
        public StudentBL(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        public bool Enroll(Student student)
        {
            bool studentDetailsExist = _studentDAL.CheckDuplicate(student.NationalId, student.Email, student.PhoneNumber, student.UserId);
            if (!studentDetailsExist)
            {
                student.Status = Status.Waiting;
                _studentDAL.InsertStudent(student);
                return true;
            }
            return false;
        }
    }
}