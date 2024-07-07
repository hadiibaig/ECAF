using ECAF.INFRASTRUCTURE.Enums;
using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Repositories
{
   public class EventsRepository
    {
        private readonly ECAFEntities _db;

        public EventsRepository()
        {
            _db = new ECAFEntities();
        }


        public bool SaveEvent(CreateEvent createEvent)
        {
            try
            {

                DateTime date = DateTime.ParseExact(createEvent.ScheduledDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime time = DateTime.ParseExact(createEvent.ScheduledTime, "HH:mm", CultureInfo.InvariantCulture);
                DateTime combinedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                string combinedDateTimeString = combinedDateTime.ToString("yyyy-MM-dd HH:mm");
                _db.Events.Add(new Event() {  Title = createEvent.Title , ScheduledDate = combinedDateTime , EventLength = createEvent.Duration , Status = createEvent.Status });
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

      
        }

        public List<EventViewModel> LoadEvents(string start, string end)
        {
            var fromDate = DateTime.Parse(start);
            var toDate = DateTime.Parse(end);
            var rslt = _db.Events.Where(s => s.ScheduledDate >=
                fromDate &&  s.ScheduledDate <= toDate);
            List<EventViewModel> result = new List<EventViewModel>();
            foreach (var item in rslt)
            {
                EventViewModel rec = new EventViewModel();
                rec.Id = item.EventId;
                rec.start = item.ScheduledDate?.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                rec.end = item.ScheduledDate?.AddMinutes
                                    (item.EventLength ?? 0).ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                rec.title = item.Title;
                rec.className = Helpers.GetEnumDescription<Tasks>(item.Status ?? 1);
                result.Add(rec);
            }

            return result;
        }

    }
}
