using Dapper;
using FormUI;
using syndicate.Classes;
using syndicate.Classes.AgentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tambola.Classes;

namespace syndicate.Pages.TempDesign
{
    public partial class TicketInfoDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                populate();
        }
        [WebMethod]
        public static string gettickets()
        {
            List<tabledata> list = new();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                list = connection.Query<tabledata>("sp_geTticketAndCustomer").ToList();

            }
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(list);
        }
        [WebMethod]
        public static void getTicketData(string[] arrayt, string nameT, string phoneT)
        {
            string[] Tickets = arrayt;
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                for (int i = 0; i < Tickets.Length; i++)
                {
                    string AgentNumber = HttpContext.Current.Session["Name"].ToString();
                    string ticketName = "TicketNo" + Tickets[i];
                    string name = nameT;
                    string phone = phoneT;
                    AgentDataAccess d = new();
                    d.AgentBuyTicket(name, ticketName, AgentNumber, phone);
                }

            }
            
        }

        public void populate()
        {
            DataAccessRegistration d = new DataAccessRegistration();
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            List<GameDetails> gameDetails = d.GetGameDetails();
            LabelPrice.Text = "₹ "+ gameDetails[0].TicketPrice.ToString();
            LabeltotalTicket.Text = gameDetails[0].TotalTickets.ToString();
            string[] ticketcount = taa.BringSoldTicketsName();
            Labeltotalsold.Text = ticketcount.Length.ToString();
            int left = gameDetails[0].TotalTickets - ticketcount.Length;
            Labelleftt.Text = left.ToString();
        }
        protected void modalsell_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "tickettab", "passTicketData();", true);
        
        }

        protected void ButtoMyTickets_Click(object sender, EventArgs e)
        {
            string name= Session["Name"].ToString();
            Session["AgentName"] = name;
            Response.Redirect("~/pages/TempDesign/Mytickets.aspx");
        }
    }

    public class tabledata
    {
        public string TicketNo { get; set; }
        public string Name { get; set; }
    }
}