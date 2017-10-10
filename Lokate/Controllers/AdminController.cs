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
            if (Session["AdminID"] != null)
            {
                return View("Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Login objUser)
        {
            if (ModelState.IsValid)
            {
                using (Models.lokateapp_DBEntities db = new Models.lokateapp_DBEntities())
                {
                    var obj = db.AdminUsers.Where(a => a.Admin_Email.Equals(objUser.AdminEmail) && a.Admin_Password.Equals(objUser.AdminPassword));
                    if (obj != null)
                    {
                        Session["AdminID"] = objUser.AdminID.ToString();
                        Session["AdminEmail"] = objUser.AdminEmail.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(objUser);
        }
    }
}