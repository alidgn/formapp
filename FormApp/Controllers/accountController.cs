using FormApp.Models;
using FormApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormApp.Controllers
{
    public class accountController : Controller
    {
        private DataContext db;
        // GET: Account
        public ActionResult login()
        {
            if (Session["userId"] != null)
            {
                return RedirectToAction("pano", "i");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult login(LoginModel m)
        {
            if (m != null)
            {
                db = new DataContext();
                var isExist = db.Users.SingleOrDefault(x => x.Username == m.Username && x.Password == m.Password);
                if (isExist != null)
                {
                    Session["userId"] = isExist.Id;
                    Session["username"] = isExist.Username;
                    return RedirectToAction("pano", "i");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("login","account");
        }
       
    }
}