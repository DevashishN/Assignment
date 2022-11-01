using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationUniRegistration.BusinessLayer;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBL _studentBL;
        public StudentController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        // GET: Student
        public ActionResult Index()
        {
            if (this.Session["userId"] != null)
            {
                return View();
            }

            return RedirectToAction("/Login/Index");
        }


        public JsonResult EnrollStudent(Student student)
        {
            student.UserId = (int)Session["userId"];

            bool isStudentEnrolled = _studentBL.Enroll(student);
            return Json(new { result = isStudentEnrolled, url = Url.Action("Index", "User") });
        }
    }
}