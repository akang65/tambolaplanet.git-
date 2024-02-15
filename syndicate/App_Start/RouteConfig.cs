using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace syndicate
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("AdminPage", "Admin", "~/pages/TempDesign/masteradmin.aspx");
            routes.MapPageRoute("Agentlogin", "AgentLogin", "~/pages/Agent/AgentLogin.aspx");
            routes.MapPageRoute("Agent", "Agent", "~/pages/Agent/AgentPanel.aspx");
            routes.MapPageRoute("HomePage", "home", "~/pages/homebeforegame.aspx");
            routes.MapPageRoute("Tickets", "Tickets", "~/Pages/AllTickets.aspx");
            routes.MapPageRoute("AgentList", "AgentLists", "~/Pages/AgentsLists.aspx");
            routes.MapPageRoute("createTicket", "CreateTicket", "~/pages/TempDesign/Createticket.aspx");
            routes.MapPageRoute("whatsapp", "whatsapplink", "~/pages/TempDesign/whatsapplink.aspx");
        }
    }
}
