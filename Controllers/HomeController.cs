using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithWebSite.Models;
using ZenithDataLib.Models;
using ZenithDataLib.Models.Zenith;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ZenithDataLib.Models.ApplicationDbContext db = new ZenithDataLib.Models.ApplicationDbContext();

        public ActionResult Index()
        {
            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var sunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday + 1);

            var result = (from e in db.Events
                       join a in db.Activities
                       on e.ActivityId equals a.ActivityId
                       where DbFunctions.TruncateTime(e.EventFromDatetime) >= monday &&
                            DbFunctions.TruncateTime(e.EventFromDatetime) <= sunday &&
                            e.IsActive == true
                       orderby e.EventFromDatetime ascending
                       select new EventsDto
                       {
                           EventStartDateTime = e.EventFromDatetime,
                           EventEndDateTime = e.EventToDatetime,
                           ActivityDesc = a.ActivityDescription
                       });

            ViewBag.Message = "SORRY, NO EVENT FOR CURRENT WEEK!";
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Zenith Society is a family oriented non-for-profit organization founded in 2014 with one simple mission : to hold events during the week that benefit to the local community. Zenith Society has organized more than 200 successful events for different age & gender groups.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Don't hesitate to contact us to participate to our events. We'll do our best to get back to you within 24 hours.";

            return View();
        }


      
           
    }
}