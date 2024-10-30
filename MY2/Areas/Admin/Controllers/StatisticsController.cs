using Microsoft.Ajax.Utilities;
using MY2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY2.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Admin/Statistics
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var username = Session["x"];
            var email = context.Admins
                .Where(x => x.UserName == username)
                .Select(y => y.Email)
                .FirstOrDefault();


            var AdminCount = context.Admins.ToList().Count();
            ViewBag.AdminCount = AdminCount;

            var CategoryCount = context.Categories.ToList().Count();
            ViewBag.CategoryCount = CategoryCount;

            var DestinationCount = context.Destinations.ToList().Count();
            ViewBag.DestinationCount = DestinationCount;


            var ReservationCount = context.Reservations.ToList().Count();
            ViewBag.ReservationCount = ReservationCount;

            var ExpensiveDestination = context.Destinations.Max(x => x.Price).ToString("0");
            ViewBag.ExpensiveDestination = ExpensiveDestination;

            var ShortestTour = context.Destinations.Min(x => x.DayNight);
            ViewBag.ShortestTour = ShortestTour;
            var LongestTour = context.Destinations.Max(x => x.DayNight);
            ViewBag.LongestTour = LongestTour;

            var shortestTourCapacity = context.Destinations
             .OrderBy(x => x.DayNight)
             .Select(x => x.Capacity)
             .FirstOrDefault();
            ViewBag.shortestTourCapacity = shortestTourCapacity;

            var maximumTourCapacity = context.Destinations
           .OrderByDescending(x => x.DayNight)
           .Select(x => x.Capacity)
           .FirstOrDefault();
            ViewBag.maximumTourCapacity = maximumTourCapacity;



            var InboxMessageCount = context.Messages
                .Where(x => x.ReceiverMail == email)
                .ToList().Count();
            ViewBag.InboxMessageCount = InboxMessageCount;

            var SendBoxMessageCount = context.Messages
               .Where(x => x.SenderMail == email)
               .ToList().Count();
            ViewBag.SendBoxMessageCount = SendBoxMessageCount;

            var AveragePrice = context.Destinations.Average(x => x.Price).ToString("0");
            ViewBag.AveragePrice = AveragePrice;

            return View();
        }
    }
}