using Dapper;
using FormUI;
using Hangfire;
using syndicate.Classes;
using syndicate.Classes.backgroundServices;
using syndicate.Classes.backgroundValidation;
using syndicate.Classes.GlobalVariables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tambola.Classes;

namespace syndicate.Pages.TempDesign
{
    public partial class MasterAdmin : System.Web.UI.Page
    {
        List<string> bonus = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
            
            if (!IsPostBack)
            {
                populateFileds();
                Admin();
            }
        }

        protected void ButtonSaveGameSettings_Click(object sender, EventArgs e)
        {
            //string dateTime = MakeDateTime();
            string date = TextBoxDate.Text;
            string time = TextBoxTime.Text;
            TimeSpan _time = TimeSpan.Parse(time);
            DateTime _date = DateTime.Parse(date);
            DateTime combined_DateTime = _date.Add(_time);

            DateTime inputDateTime = combined_DateTime;
            string dateTime = combined_DateTime.ToString();
            DateTime currentTime = DateTime.UtcNow;
            var IstCurrent = TimeZoneInfo.ConvertTimeFromUtc(currentTime,
            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            if (inputDateTime > IstCurrent)
            {
                try
                {
                    DataAccess tk = new();
                    tk.deletejobs();
                    DateTime originalDatetime = Convert.ToDateTime(dateTime);
                    String dateonly = originalDatetime.ToString("yyyy-MM-dd");
                    ThemeDefaultDataAccess ds = new ThemeDefaultDataAccess();
                    int fulLhouse = Convert.ToInt32(DropDownListFullHouse.SelectedValue);
                    ds.AddGameDetails(originalDatetime, dateonly, 1, 1, fulLhouse);
                    saveBonuses();
                    AddFullhousePrice();
                    //DeleteJobs();
                    MakeBbServices(dateTime);
                    updateDateOnTickets(dateonly);
                    Response.Redirect("~/admin");


                }
                catch (Exception ex)
                {
                    // throw ex;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Invalid Date and Time');", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerterr", "alert('Input DateTime cannot be less then current Date Time');", true);
            }

        }

        protected void DropDownListGameBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListGameBonus.SelectedValue != "0")
            {
                bonus.Add(DropDownListGameBonus.SelectedValue);
                Updatebonuses();
            }
        }
        public void CheckLogin()
        {
            LoginCheck l = new();
            string[] auth = l.Authenticate();
            if (Session["Name"] != null)
            {
                if (Session["Name"].ToString() != auth[0] && Session["Password"].ToString() != auth[1])
                {
                    Response.Redirect("~/pages/loginAdmin.aspx");
                }
            }
            else if (Session["Name"] == null)
            {
                Response.Redirect("~/pages/loginAdmin.aspx");
            }
        }
        public void updateDateOnTickets(string date)
        {
            ThemeDefaultDataAccess d = new();
            d.updateDate(date);
        }
        public void MakeBbServices(string _datetime)
        {
            if (DependencyCounter._runningProcess == true)
            {
                DependencyCounter._cancellationtoken = true;
            }
            else
            {
                DependencyCounter._cancellationtoken = false;
            }


            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("sp_resetGame");
            }

            string _date = _datetime;
            DateTime date = Convert.ToDateTime(_date);
            String dateonly = date.ToString("yyyy-MM-dd");
            MakeWinners s = new();
            s.StartBackGroundServices(_date, "newGame");
            DataAccessRegistration ds = new();
            services sv = new();
            sv.StartGameService(_date);
            ds.Reschedule(date, dateonly);

        }

        public void saveBonuses()
        {
            int fullS, halfS, five, seven, star, top, middle, bottom;

            if (Panelfs.Visible == true)
            {
                fullS = 1;
            }
            else
            {
                fullS = 0;
            }
            if (Panelhs.Visible == true)
            {
                halfS = 1;
            }
            else
            {
                halfS = 0;
            }
            if (PanelT.Visible == true)
            {
                top = 1;
            }
            else
            {
                top = 0;
            }
            if (PanelM.Visible == true)
            {
                middle = 1;
            }
            else
            {
                middle = 0;
            }
            if (PanelB.Visible == true)
            {
                bottom = 1;
            }
            else
            {
                bottom = 0;
            }
            if (PanelS.Visible == true)
            {
                star = 1;
            }
            else
            {
                star = 0;
            }
            if (PanelQf.Visible == true)
            {
                five = 1;
            }
            else
            {
                five = 0;
            }
            if (PanelQs.Visible == true)
            {
                seven = 1;
            }
            else
            {
                seven = 0;
            }
            ThemeDefaultDataAccess d = new ThemeDefaultDataAccess();
            d.AddBonus(fullS, halfS, five, seven, star, top, middle, bottom);
        }
        public void AddFullhousePrice()
        {
            int f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12;
            DataAccessRegistration ds = new DataAccessRegistration();
            if (1 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f1 = 1;
            }
            else
            {
                f1 = 0;
            }
            if (2 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f2 = 1;
            }
            else
            {
                f2 = 0;
            }
            if (3 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f3 = 1;
            }
            else
            {
                f3 = 0;
            }

            if (4 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f4 = 1;
            }
            else
            {
                f4 = 0;

            }
            if (5 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f5 = 1;
            }
            else
            {
                f5 = 0;
            }
            if (6 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f6 = 1;
            }
            else
            {
                f6 = 0;

            }
            if (7 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f7 = 1;
            }
            else
            {
                f7 = 0;

            }
            if (8 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f8 = 1;
            }
            else
            {
                f8 = 0;

            }
            if (9 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f9 = 1;
            }
            else
            {
                f9 = 0;

            }
            if (10 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f10 = 1;
            }
            else
            {
                f10 = 0;

            }
            if (11 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f11 = 1;
            }
            else
            {
                f11 = 0;

            }
            if (12 <= Convert.ToInt32(DropDownListFullHouse.SelectedValue))
            {
                f12 = 1;
            }
            else
            {
                f12 = 0;
            }

            int total = Convert.ToInt32(DropDownListFullHouse.SelectedValue);
            ds.AddFullHouse(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, total);
        }
        public void Updatebonuses()
        {
            string name = "Panel";
            for (int i = 0; i < bonus.Count; i++)
            {
                Panel p = (Panel)FindControl(name + bonus[i]);
                p.Visible = true;
            }
        }
        public void populateFileds()
        {
            ThemeDefaultDataAccess td = new();
            string bookingstatus = td.Bookingstatus();
            DataAccessRegistration d = new DataAccessRegistration();
            List<GameDetails> gameDetails = d.GetGameDetails();
            DateTime dateTime1 = gameDetails[0].Time;
            string date = dateTime1.ToString("yyyy-MM-dd");
            string ticketcost = gameDetails[0].TicketPrice.ToString();
            string Time = dateTime1.ToString("HH:mm");
            TextBoxTicketPrice.Text = ticketcost;
            TextBoxDate.Text = date;
            TextBoxTime.Text = Time;


            List<PriceDistribution> priceDist = d.GetPriceDistribution();
            int selected = priceDist[0].totalfhouse;
            DropDownListFullHouse.SelectedIndex = selected;
            if (priceDist[0].fullsheet.Replace(" ", string.Empty) != "0")
            {
                Panelfs.Visible = true;
            }
            if (priceDist[0].halfsheet.Replace(" ", string.Empty) != "0")
            {
                Panelhs.Visible = true;
            }
            if (priceDist[0].topLine.Replace(" ", string.Empty) != "0")
            {
                PanelT.Visible = true;
            }
            if (priceDist[0].middleLine.Replace(" ", string.Empty) != "0")
            {
                PanelM.Visible = true;
            }
            if (priceDist[0].bottomLine.Replace(" ", string.Empty) != "0")
            {
                PanelB.Visible = true;
            }
            if (priceDist[0].star.Replace(" ", string.Empty) != "0")
            {
                PanelS.Visible = true;
            }
            if (priceDist[0].quickfive.Replace(" ", string.Empty) != "0")
            {
                PanelQf.Visible = true;
            }
            if (priceDist[0].quickseven.Replace(" ", string.Empty) != "0")
            {
                PanelQs.Visible = true;
            }
            if (bookingstatus == "False" || bookingstatus == null)
            {
                LabelBookingMode.Text = "Booking Mode is on";
            }
            else
            {
                LabelBookingMode.Text = "Booking Mode is off";
            }
        }
        public void Admin()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getAdminLogin").ToArray();
                String Name = data[0].Name.ToString();
                String password = data[0].password.ToString();
                TextBoxAdminName.Text = Name;
                TextBoxAdminPassword.Text = password;
            }
        }
        protected void ButtonfsbR_Click(object sender, EventArgs e)
        {
            Panelfs.Visible = false;
        }

        protected void ButtonhsbR_Click(object sender, EventArgs e)
        {
            Panelhs.Visible = false;
        }

        protected void ButtonTR_Click(object sender, EventArgs e)
        {
            PanelT.Visible = false;
        }

        protected void ButtonMR_Click(object sender, EventArgs e)
        {
            PanelM.Visible = false;
        }

        protected void ButtonBR_Click(object sender, EventArgs e)
        {
            PanelB.Visible = false;
        }

        protected void ButtonSR_Click(object sender, EventArgs e)
        {
            PanelS.Visible = false;
        }

        protected void ButtonQfR_Click(object sender, EventArgs e)
        {
            PanelQf.Visible = false;
        }

        protected void ButtonQsR_Click(object sender, EventArgs e)
        {
            PanelQs.Visible = false;
        }

        protected void ButtonSaveAdmin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxAdminName.Text) || String.IsNullOrEmpty(TextBoxAdminPassword.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateDate", "alert('Admin Fields Cannot be Empty');", true);
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    connection.Execute("dbo.basic_SP_ADMINUPDATE @Name,@Password", new
                    {
                        Name = TextBoxAdminName.Text,
                        Password = TextBoxAdminPassword.Text
                    });
                }
                TextBoxAdminName.Text = "";
                TextBoxAdminPassword.Text = "";
                ButtonSaveAdmin.Text = "Saved";

            }
        }

        protected void ButtonCreateNewTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateTicket");
        }

        protected void ButtonChangeBookingMode_Click(object sender, EventArgs e)
        {
            ThemeDefaultDataAccess td = new();
            string bookingstatus = td.Bookingstatus();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.basic_sp_closebooking");
                if (bookingstatus == "False" || bookingstatus == null)
                {
                    connection.Execute("dbo.basic_updatebookingclosedtime @Datetime", new { Datetime = DateTime.Now });
                    LabelBookingMode.Text = "Booking Mode is Off";
                }
                else
                {
                    LabelBookingMode.Text = "Booking Mode is On";

                }
            }
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
            DateTime datetime = DateTime.Now;
            //var Ist = TimeZoneInfo.ConvertTimeFromUtc(datetime,
            //TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime date = Convert.ToDateTime(datetime);
            String dateonly = date.ToString("yyyy-MM-dd");
            DataAccessRegistration ds = new();
            ds.Reschedule(date, dateonly);
            MakeWinners s = new();
            s.restartGame();
            services gs = new();
            gs.StartGameService(date.ToString());
            ButtonRestart.Text = "Restarted!";
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
            DateTime datetime = DateTime.Now;
            //var Ist = TimeZoneInfo.ConvertTimeFromUtc(datetime,
            //TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime date = Convert.ToDateTime(datetime);
            String dateonly = date.ToString("yyyy-MM-dd");
            DataAccessRegistration ds = new();
            ds.Reschedule(date, dateonly);
            MakeWinners s = new();
            s.resetGame(datetime.ToString());
            services gs = new();
            gs.StartGameService(date.ToString());
            ButtonReset.Text = "Game Reset!";

        }

        protected void ButtonWhatsapp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/whatsapplink");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/admin");
        }

        protected void Buttonhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin");
        }

        protected void ButtonManageTickets_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/TempDesign/ManageTickets.aspx");
        }

        protected void Buttonmanageagent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/agent/AddAgent.aspx");
        }

        protected void ButtonSaveTicketPrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxTicketPrice.Text) != true)
            {
                ThemeDefaultDataAccess d = new();
                d.saveTicketprice(TextBoxTicketPrice.Text);
                ButtonSaveTicketPrice.Text = "saved";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            string[] ticketcount = taa.BringSoldTicketsName();
            if (ticketcount.Length >= 6)
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
                DateTime datetime = DateTime.Now;
                //var Ist = TimeZoneInfo.ConvertTimeFromUtc(datetime,
                //TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                DateTime date = Convert.ToDateTime(datetime);
                String dateonly = date.ToString("yyyy-MM-dd");
                DataAccessRegistration ds = new();
                ds.Reschedule(date, dateonly);
                MakeWinners s = new();
                s.StartBackGroundServices(date.ToString(), "startnow");
                services sv = new();
                sv.StartGameService(date.ToString());
                Button1.Text = "Game Process started";
                updateDateOnTickets(dateonly);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertgameStarted", "gamestartedalert();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertgameStarted", "minimumTicket();", true);
            }

        }

        protected void Buttonflyer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/flyer/flyer.html");
        }
    }
}