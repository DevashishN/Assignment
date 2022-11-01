using WebApplicationUniRegistration.Models;
using WebApplicationUniRegistration.BusinessLayer;
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
        public LoginController(ILoginBL userBL)
        {
            _userBL = userBL;
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

                return Json(new { result = true, url = Url.Action("Index", "Student") });
            }
            catch
            {
                return Json(new { result = false, url = Url.Action("Index", "Login") });
            }
        }
    }
}