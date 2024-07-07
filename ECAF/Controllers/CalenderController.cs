using ECAF.INFRASTRUCTURE.Enums;
using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.Repositories;
using ECAF.INFRASTRUCTURE.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class CalenderController : Controller
    {
        private readonly EventsRepository _eventsRepository;
        public CalenderController()
        {
            _eventsRepository = new EventsRepository();
        }
        // GET: Calender
        public ActionResult Index()
        {
            var taskDescriptions = Helpers.GetEnumSelectList<Tasks>();
            ViewBag.TaskDescriptions = taskDescriptions;
            var events = _eventsRepository.LoadEvents(DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString()).OrderBy(x => DateTime.Parse(x.start)).ToList();
            return View(events);
        }
        [HttpGet]
        public JsonResult GetEvents(string start, string end)
        {
            var ApptListForDate = _eventsRepository.LoadEvents(start, end);
            return Json(ApptListForDate, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool SaveEvents(CreateEvent events)
        {
            return _eventsRepository.SaveEvent(events); 
        }

        [HttpPost]
        public void UpdateEvent(long Id, string NewEventStart, string NewEventEnd)
        {

        }
    }
}