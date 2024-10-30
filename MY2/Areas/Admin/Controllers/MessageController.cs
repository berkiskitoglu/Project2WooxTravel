using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY2.Context;
using MY2.Entities;

namespace MY2.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Inbox()   
        {
            var username = Session["x"];
            var email = context.Admins.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.ReceiverMail == email).ToList();
            return View(values);
        }
        public ActionResult Sendbox()
        {
            var username = Session["x"];
            var email = context.Admins.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var username = Session["x"];
            var email = context.Admins.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Sendbox","Message",new {area = "Admin"});
        }
    }
}