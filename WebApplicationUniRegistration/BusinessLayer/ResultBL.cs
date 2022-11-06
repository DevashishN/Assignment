using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.DAL;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class ResultBL : IResultBL
    {
        private readonly IResultDAL _resultDAL;

        public ResultBL(IResultDAL resultDAL)
        {
            _resultDAL = resultDAL;
        }

        public bool enterResults(List<Results> resultList, int userId)
        {
            return _resultDAL.enterStudentResults(resultList, userId);
            
        }
    }
}