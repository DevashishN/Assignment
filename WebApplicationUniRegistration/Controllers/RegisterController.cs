using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationUniRegistration.BusinessLayer;
using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterBL _registerBL;
        public RegisterController(IRegisterBL registerBL)
        {
            _registerBL = registerBL;
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RegisterUser(User user)
        {
            bool isUserCreated = _registerBL.CreateUser(user);
            return Json(new { result = isUserCreated, url = Url.Action("Index", "User") });
        }
    }
}