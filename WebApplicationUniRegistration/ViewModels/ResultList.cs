using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.ViewModels
{
    public class ResultList
    {
        public List<Results> resultList { get; set; }
        public ResultList()
        {
            resultList = new List<Results>();
        }
    }
}