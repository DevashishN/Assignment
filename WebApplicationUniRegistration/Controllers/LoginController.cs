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
        private readonly ILoginBL _userBL;
        public LoginController(ILoginBL userBL)
        {
            _userBL = userBL;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Authenticate(User user)
        {
            bool IsUserValid = false;
            //User loggedUser = _userBL.Authenticate(user);
            IsUserValid=_userBL.Authenticate(user);
            return Json(new { result = IsUserValid, url = Url.Action("Index", "Login") });
        }
    }
}