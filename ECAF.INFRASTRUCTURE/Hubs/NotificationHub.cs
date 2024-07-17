using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Hubs
{
   public class NotificationHub : Hub
    {
        private readonly IHubContext _hubContext;
        public NotificationHub()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        public void SendNotification(string message)
        {
          //  Clients.All.broadcastNotification(message);
            _hubContext.Clients.All.broadcastNotification(message);
        }
    }
}
