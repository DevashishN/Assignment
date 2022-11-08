using WebApplicationUniRegistration.DAL.Models;
using WebApplicationUniRegistration.BL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using WebApplicationUniRegistration.ViewModels;

namespace WebApplicationUniRegistration.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginBL _userBL;
        private readonly IRoleBL _roleBL;
        private readonly IStudentBL _studentBL;
        public LoginController(ILoginBL userBL, IRoleBL roleBL, IStudentBL studentBL)
        {
            _userBL = userBL;
            _roleBL = roleBL;
            _studentBL = studentBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Authenticate(LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { result = false });
                }

                User user = _userBL.Authenticate(login.Email, login.Password);

                if (user == null)
                {
                    return Json(new { result = false });
                }

                this.Session["userId"] = user.UserId;
                user.userRole = (Role)_roleBL.getUserRole(user.UserId);
                if(user.userRole == Role.admin)
                {
                    return Json(new { result = true, url = Url.Action("Index", "Admin") });
                }

                var studentExist = _studentBL.CheckIfStudentExist(user.UserId);
                if (studentExist)
                {
                    return Json(new { result = true, url = Url.Action("Index", "Home") });
                }
                else
                {
                    return Json(new { result = true, url = Url.Action("Index", "Student") });
                }

                return Json(new { result = true, url = Url.Action("Index", "Student") });
            }
            catch
            {
                return Json(new { result = false, url = Url.Action("Index", "Login") });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("LoginIndex");
        }
    }
}