using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY2.Entities;
using MY2.Context;

namespace MY2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}