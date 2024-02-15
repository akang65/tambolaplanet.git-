using FormUI;
using syndicate.Classes;
using syndicate.Classes.GlobalVariables;
using syndicate.Classes.SqlDependencychanges;
using syndicate.Projects.TicketGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TambolaTickets;

namespace syndicate.Pages.TempDesign
{
    public partial class CreateTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
        }
        protected void ButtonCreateTicket_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxtotalTickets.Text) != true)
            {
                ThemeDefaultDataAccess tk = new();
                tk.DropAllData();
                DateTime date = DateTime.Now;
                String dateonly = date.ToString("yyyy-MM-dd");
                Program d = new Program();
                d.GenerateTickets(Convert.ToInt32(TextBoxtotalTickets.Text), dateonly);
                MakeFullSheet();
                MakeHalfSheet();
                updatetotalTickets();
                GeneratevalTickets();
                SubscribeDependency();
                ButtonCreateTicket.Style.Add("background", "#01A16C");
                ButtonCreateTicket.Text = "Ticket Created";
            }

        }
        public void updatetotalTickets()
        {
            ThemeDefaultDataAccess d = new();
            d.SaveTotalTickets(TextBoxtotalTickets.Text);
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
        public void MakeFullSheet()
        {

            int NoOfTicket = Convert.ToInt32(TextBoxtotalTickets.Text);
            int fullsheetcount = NoOfTicket / 6;
            int count = 1;
            for (int i = 1; i <= fullsheetcount; i++)// loop this the total number of fullsheet count
            {

                for (int j = 0; j < 6; j++)     //Insert fullsheet serial on every 6 consecutive Tickets 
                {
                    string TName = "TicketNo" + count;
                    // int halfsheetName = j + 1;
                    ThemeDefaultDataAccess ds = new ThemeDefaultDataAccess();
                    ds.AddSheetbonus(TName, i, fullsheetcount);
                    count++;
                }

            }

        }
        public void MakeHalfSheet()
        {
            int NoOfTicket = Convert.ToInt32(TextBoxtotalTickets.Text);
            //int NoOfTicket = 16;
            int HalfsheetCount = NoOfTicket / 3;
            //int remainingTickets = NoOfTicket % 3;
            int count = 1;
            for (int i = 1; i <= HalfsheetCount; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    string TName = "TicketNo" + count;
                    ThemeDefaultDataAccess ds = new ThemeDefaultDataAccess();
                    ds.AddHalfSheetbonus(TName, i, HalfsheetCount);
                    count++;
                }
            }
        }

        public void GeneratevalTickets()
        {
            ValidationTickets v = new ValidationTickets();
            v.ValTickets();
        }
        public void SubscribeDependency()
        {
            if (DependencyCounter.Count == 0)
            {
                OnChangesDependencyGlobal.GetData();
                AgentTicketDependency.GetAgentTickets();
                DependencyCounter.Count++;
            }
        }
    }
}