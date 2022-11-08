using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL.DataAccessLayer;
using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.BL.BusinessLayer
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
            bool studentDetailsExist = _studentDAL.CheckDuplicate(student.NationalId, student.Email, student.PhoneNumber);
            if (!studentDetailsExist)
            {
                _studentDAL.InsertStudent(student);
                return true;
            }
            return false;
        }

        public bool CheckIfStudentExist(int userId)
        {
            return _studentDAL.CheckStudentExist(userId);
        }
    }
}