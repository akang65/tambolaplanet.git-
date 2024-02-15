using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace syndicate
{
 
    public class MyHub2 : Hub
    {
        
        public static void Announce(dynamic message)
        {
            
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub2>();
            context.Clients.All.Getdata(message);
        }
    }
}