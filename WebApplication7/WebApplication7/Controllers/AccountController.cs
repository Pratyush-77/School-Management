using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using WebApplication7.ViewModel;

namespace WebApplication7.Controllers
{
    public class AccountController : Controller
    {
        SchoolManagementDBDataContext DataContext = new SchoolManagementDBDataContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }



        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult ChangePassword(ChangePassModel pass)
        //{
        //    bool ischangepassword = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, pass.OldPassword, pass.NewPassword);

        //    if (ischangepassword)
        //    {
        //        var passreset = (from u in DataContext.UsersRegs where u.Username == WebSecurity.CurrentUserName select u);
        //        if (passreset.Any())
        //        {
        //            passreset.First().Password = pass.NewPassword;
        //            DataContext.SubmitChanges();
        //        }
        //        return Json(new { result = true, message = "Password Changed Successfully..." }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("OldPassword", "Old Password is not correct.");
        //        return Json(new { result = false, message = "Old Password is not correct...." }, JsonRequestBehavior.AllowGet);
        //    }
        //}



    }
}