using WebApplicationUniRegistration.Models;
using WebApplicationUniRegistration.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationUniRegistration.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserBL _userBL;
        public LoginController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public JsonResult Authenticate(User user)
        {

            bool IsUserValid = false;

            IsUserValid=_userBL.Authenticate(user);
            
            return Json(new { result = IsUserValid, url = Url.Action("Index", "User") });

        }
    }
}