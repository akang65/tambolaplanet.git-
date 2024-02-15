using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace syndicate
{
    public class AgentHub : Hub
    {
        public static void UpdateTable(dynamic message)
        {

            var context = GlobalHost.ConnectionManager.GetHubContext<AgentHub>();
            context.Clients.All.Getdata(message);
        }
    }
}