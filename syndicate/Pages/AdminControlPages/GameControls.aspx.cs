using Dapper;
using FormUI;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tambola.Classes;
using syndicate.Classes;
using syndicate.Classes.backgroundServices;
using syndicate.Classes.backgroundValidation;
using syndicate.Classes.GlobalVariables;

namespace syndicate.Pages.AdminControlPages
{
    public partial class GameControls : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticate();
            LoadData();
        }
        public void authenticate()
        {
            LoginCheck l = new();
            string[] auth = l.Authenticate();
            if (Session["Name"] != null)
            {
                if (Session["Name"].ToString() != auth[0] && Session["Password"].ToString() != auth[1])
                {
                    Response.Redirect("../../Pages/LoginAdmin.aspx");
                }
            }
            else if (Session["Name"] == null)
            {
                Response.Redirect("../../Pages/LoginAdmin.aspx");
            }
        }
        protected void ButtonReSchedule_Click(object sender, EventArgs e)
        {
            //DateTime ScheduledDateTime = DateTime.Parse(TextBoxRescheduleCalander.Text);
            //String dateTime = ScheduledDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            RescheduleJobs r = new();
            r.reschedulejob(TextBoxRescheduleCalander.Text);

            DateTime date = Convert.ToDateTime(TextBoxRescheduleCalander.Text);
            String dateonly = date.ToString("yyyy-MM-dd");
            DataAccessRegistration ds = new();
            ds.Reschedule(date, dateonly);

            List<gameDetails> GameData = ds.getGameDetails();
            LabelCurrentGameDate.Text = GameData[0].Time.ToString();
        }
        public void LoadData()
        {
            DataAccessRegistration d = new DataAccessRegistration();
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            List<gameDetails> GameData = d.getGameDetails();
            LabelCurrentGameDate.Text = GameData[0].Time.ToString();
            LabelTT.Text = GameData[0].TotalTickets.ToString();
            string[] ticketcount = taa.BringSoldTicketsName();
            LabelTS.Text = ticketcount.Length.ToString();
        }

        protected void ButtonCloseBooking_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var jobIds = connection.Query("select WinnersJobId, StartTimeJobId from dbo.GameDetails").ToList();
                BackgroundJob.Delete(jobIds[0].WinnersJobId);
                MakeWinners m = new();
                m.StartBackGroundServices(DateTime.Now.ToString(), "Rescheduling");
                connection.Execute("dbo.sp_closebooking @datetime", new { datetime = DateTime.Now });
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "loadAlert();", true);
            }
        }

        protected void ButtonCancelTicket_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                string no = TextBoxTicketNo.Text.Replace(" ", string.Empty);
                string ticketNo = "TicketNo" + no;
                connection.Execute("dbo.SP_CANCELTICKETS @TicketNumber", new { TicketNumber = ticketNo });
            }
            TextBoxTicketNo.Text = "";
        }


        protected void ButtonRestart_Click(object sender, EventArgs e)
        {
            if (DependencyCounter._runningProcess == true)
            {
                DependencyCounter._cancellationtoken = true;
            }
            else
            {
                DependencyCounter._cancellationtoken = false;
            }
            DataAccess tk = new();
            tk.deletejobs();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
               connection.Execute("sp_restartGame"); 
            }
            DateTime datetime = DateTime.UtcNow;
            var Ist = TimeZoneInfo.ConvertTimeFromUtc(datetime,
            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime date = Convert.ToDateTime(Ist);
            String dateonly = date.ToString("yyyy-MM-dd");
            DataAccessRegistration ds = new();
            ds.Reschedule(date, dateonly);
            MakeWinners s = new();
            s.restartGame();
            services gs = new();
            gs.StartGameService(date.ToString());

        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            if (DependencyCounter._runningProcess == true)
            {
                DependencyCounter._cancellationtoken = true;
            }
            else
            {
                DependencyCounter._cancellationtoken = false;
            }
            
            DataAccess tk = new();
            tk.deletejobs();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("sp_resetGame");
            }
            DateTime datetime = DateTime.UtcNow;
            var Ist = TimeZoneInfo.ConvertTimeFromUtc(datetime,
            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime date = Convert.ToDateTime(Ist);
            String dateonly = date.ToString("yyyy-MM-dd");
            DataAccessRegistration ds = new();
            ds.Reschedule(date, dateonly);
            MakeWinners s = new();
            s.resetGame(datetime.ToString());
            services gs = new();
            gs.StartGameService(date.ToString());
        }
    }

}