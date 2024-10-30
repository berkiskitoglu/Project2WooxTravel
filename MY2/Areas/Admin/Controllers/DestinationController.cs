using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY2.Entities;
using MY2.Context;

namespace MY2.Areas.Admin.Controllers
{
    [Authorize]
    public class DestinationController : Controller
    {
        // GET: Admin/Destination
        TravelContext context = new TravelContext();

        [HttpGet]
        public ActionResult DestinationList()
        {
            var values = context.Destinations.ToList();
            return View(values);
        }
        public ActionResult CreateDestination()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDestination(Destination destination)
        {
            context.Destinations.Add(destination);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
        
        public ActionResult DeleteDestination(int id)
        {
            var values = context.Destinations.Find(id);
            
            context.Destinations.Remove(values);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateDestination(int id)
        {
            var values = context.Destinations.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateDestination(Destination destination)
        {
            var values = context.Destinations.Find(destination.DestinationID);
            values.Description = destination.Description;
            values.City = destination.City;
            values.DayNight = destination.DayNight;
            values.Country = destination.Country;
            values.ImageUrl = destination.ImageUrl;
            values.Price = destination.Price;
            values.Title = destination.Title;
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}