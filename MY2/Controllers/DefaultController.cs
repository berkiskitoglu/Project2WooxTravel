using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY2.Context;
using MY2.Entities;
using PagedList;
using PagedList.Mvc;


namespace MY2.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult TurDetay(int id)
        {
            var values = context.Destinations.FirstOrDefault(x => x.DestinationID == id);
            return View(values);
        }

       
        public ActionResult TurRezervasyon(Reservation reservation)
        {
            var values = context.Reservations.Add(reservation);
            context.SaveChanges();
            return View();
        }
        
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var values = context.Destinations.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialCountry(int sayfa = 1)
        {
            var values = context.Destinations.OrderBy(x => x.DestinationID).ToPagedList(sayfa, 5);
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

    }
}