using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationUniRegistration.BL.BusinessLayer;
using WebApplicationUniRegistration.DAL.Models;
using WebApplicationUniRegistration.ViewModels;

namespace WebApplicationUniRegistration.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultBL _resultBL;

        public ResultController(IResultBL resultBL)
        {
            _resultBL = resultBL;
        }
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult EnterResult(List<Results> resultList)
        {
            int userId = Convert.ToInt32(this.Session["userId"]);
            bool isResultRegistered = _resultBL.enterResults(resultList, userId);
            return Json(new { result = isResultRegistered, url = Url.Action("Index", "Home") });
            //return Json(null);
        }
    }
}