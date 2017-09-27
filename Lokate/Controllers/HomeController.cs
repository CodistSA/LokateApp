using Lokate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lokate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View("About");
        }
        public ActionResult Contact()
        {
            return View("Contact");
        }
        public ActionResult RegistrationForm()
        {
            return View("RegistrationForm");
        }
        //[HttpPost]
        //public ViewResult RegistrationForm(AreaRegistration registration)
        //{
        //    return View("Congratualation", registration);
        //}
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsUserExist(model.AdminEmail, model.AdminPassword))
                {
                    ViewBag.UserName = model.AdminEmail;
                    FormsAuthentication.RedirectFromLoginPage(model.AdminEmail, false);
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password Incorrect.");
                }
            }
            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RegistrationForm(Registration model)
        {

            if (ModelState.IsValid)
            {
                //string realCaptcha = Session["captcha"].ToString();

                if (model.Insert())
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email Already Exist");
                }
            }
    

            return View(model);
        }

    }
}