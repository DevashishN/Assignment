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
    public class AdminController : Controller
    {
        private readonly IAdminBL _adminBL;

        public AdminController(IAdminBL adminBL)
        {
            _adminBL = adminBL;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult FetchStudentResults()
        {
            List<Student> isStudentResult = _adminBL.GetAllStudentResults();
            return Json(isStudentResult,JsonRequestBehavior.AllowGet);
        }
    }
}