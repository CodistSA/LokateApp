using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lokate.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
             return RedirectToAction("Login");
        }
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }
    }
}