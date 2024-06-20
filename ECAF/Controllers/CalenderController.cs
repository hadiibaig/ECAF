using ECAF.INFRASTRUCTURE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetEvents(string start, string end)
        {
            var ApptListForDate = LoadEvents(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.Id,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                               // color = e.StatusColor,
                                allDay = false,
                                className = e.className
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<Event> LoadEvents(string start, string end)
        {
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);
            //using (DiaryContainer ent = new DiaryContainer())
            //{
            //    var rslt = ent.AppointmentDiary.Where(s => s.DateTimeScheduled >=
            //        fromDate && System.Data.Objects.EntityFunctions.AddMinutes(
            //        s.DateTimeScheduled, s.AppointmentLength) <= toDate);
            //    List<DiaryEvent> result = new List<DiaryEvent>();
            //    foreach (var item in rslt)
            //    {
            //        DiaryEvent rec = new DiaryEvent();
            //        rec.ID = item.ID;
            //        rec.SomeImportantKeyID = item.SomeImportantKey;
            //        rec.StartDateString = item.DateTimeScheduled.ToString("s");
            //        // "s" is a preset format that outputs as: "2009-02-27T12:12:22"

            //        rec.EndDateString = item.DateTimeScheduled.AddMinutes
            //                            (item.AppointmentLength).ToString("s");
            //        // field AppointmentLength is in minutes

            //        rec.Title = item.Title + " - " + item.AppointmentLength.ToString() + " mins";
            //        rec.StatusString = Enums.GetName<AppointmentStatus>
            //                           ((AppointmentStatus)item.StatusENUM);
            //        rec.StatusColor = Enums.GetEnumDescription<AppointmentStatus>(rec.StatusString);
            //        string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
            //        rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1,
            //                        rec.StatusColor.Length - ColorCode.Length - 1);
            //        rec.StatusColor = ColorCode;
            //        result.Add(rec);
            //    }
            //    return result;
            List<Event> data = new List<Event>();

            //Statically create list and add data  
            Event infoObj1 = new Event();
            infoObj1.Id = 1;
            infoObj1.Title = "I am available";
            infoObj1.Description = "Description 1";
            infoObj1.StartDateString = "2024-06-17 02:37:22.467";
            infoObj1.EndDateString = "2024-06-17 10:30:22.467";
          //  infoObj1.StatusColor = "green";
            infoObj1.className = "GREEN";

            data.Add(infoObj1);

            Event infoObj2 = new Event();
            infoObj2.Id = 2;
            infoObj2.Title = "Available";
            infoObj2.Description = "Description 1";
            infoObj2.StartDateString = "2024-06-18 02:37:22.467";
            infoObj2.EndDateString = "2024-06-18 02:37:22.467";
            //  infoObj1.StatusColor = "orange";
            infoObj2.className = "RED";
            data.Add(infoObj2);


            Event infoObj3 = new Event();
            infoObj3.Id = 3;
            infoObj3.Title = "Meeting";
            infoObj3.Description = "Description 1";
            infoObj3.StartDateString = "2024-06-19 02:37:22.467";
            infoObj3.EndDateString = "2024-06-19 02:37:22.467";
            // infoObj1.StatusColor = "blue";
            infoObj3.className = "BLUE";
            data.Add(infoObj3);
            return data;
            //}
        }
        public JsonResult SaveEvents(Event events)
        {
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}