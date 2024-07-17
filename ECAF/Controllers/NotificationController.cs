using ECAF.INFRASTRUCTURE.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHubContext _hubContext;

        public NotificationController()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        }

        public ActionResult SendNotification(string message)
        {
            _hubContext.Clients.All.broadcastNotification(message);
            return Content("Notification sent");
        }
    }
}