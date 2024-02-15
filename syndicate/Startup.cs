using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Dashboard;
using syndicate.Filter;

[assembly: OwinStartup(typeof(syndicate.Startup))]

namespace syndicate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Hangfire");

            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMilliseconds(2000)
            };

            app.UseHangfireServer(options);
            app.UseHangfireDashboard("/hangfireaeiou65",new DashboardOptions
            {
                Authorization = new[] {new HangfireAuthorizationFilter()}
            });
            app.UseHangfireServer();
        }
    }
}
