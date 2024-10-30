using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY2.Context;
using MY2.Entities;

namespace MY2.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var username = Session["x"];
            var values = context.Admins.Where(x => x.UserName == username).FirstOrDefault();
            return View(values);
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Profile", "Admin");
        }
    }
}