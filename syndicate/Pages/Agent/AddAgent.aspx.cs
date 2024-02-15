using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes;
using syndicate.Classes.AgentDataAccess;

namespace syndicate.Pages.Agent
{
    public partial class Agent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            if (!IsPostBack)
            {
                edit();
                ViewAgentsTicket();
            }
        }
        public void edit()
        {
            List<agent> agents = new();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                agents =connection.Query<agent>("SELECT [AgentName], [AgentPhoneNumber], [AgentPassword] FROM [Agents]").ToList();

            }
                DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("AgentName"), new DataColumn("PhoneNumber"), new DataColumn("AgentPassword") });
            GridViewAgents.DataSource = agents;
            GridViewAgents.DataBind();
        }
        public void ViewAgentsTicket()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("AgentName"), new DataColumn("TotalTicketsSold") });
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                
                var Agents = connection.Query<AgentTickets>("Select AgentPhoneNumber,AgentName from dbo.Agents").ToList();
                List<AgentTickets> lists = Agents;
                for (int i = 0; i < Agents.Count; i++)
                {
                    string _Agent = lists[i].AgentPhoneNumber;
                    var Ticketsold = connection.Query<int>("dbo.basic_sp_getAgentTicketsSold @Phone", new {Phone=_Agent}).ToList();
                    int sold = Ticketsold.First();
                    var row = dt.NewRow();
                    row["AgentName"] = lists[i].AgentName;
                    row["TotalTicketsSold"] = sold;
                    dt.Rows.Add(row);
                }
            }
          
            GridViewAgentsTicketLists.DataSource = dt;
            GridViewAgentsTicketLists.DataBind();
        }
        protected void ButtonAddAgent_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextBoxName.Text) || string.IsNullOrEmpty(TextBoxPhone.Text) || string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alertError()", true);
            }
            else {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    connection.Execute("dbo.ag_AgentEdit @Name,@Number,@Password,@InsertOrUpdate", new
                    {
                        Name = TextBoxName.Text,
                        Number = TextBoxPhone.Text,
                        Password = TextBoxPassword.Text,
                        InsertOrUpdate = 0
                    });
                }
                EmptyTextBoxes();
                edit();
                ViewAgentsTicket();
            }
            
        }

        public void EmptyTextBoxes()
        {
            TextBoxName.Text = "";
            TextBoxPhone.Text ="";
            TextBoxPassword.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string number = Session["EditPhone"].ToString();
          
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.ag_AgentEdit @Name,@Number,@Password,@InsertOrUpdate", new
                {
                    Name = TextBoxEditAgentName.Text,
                    Number = number,
                    Password = TextBoxEditAgentPassword.Text,
                    InsertOrUpdate = 1
                });
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "closeM", "closeModal();", true);
            edit();
        }
        protected void GridViewAgents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewAgents.Rows[rowIndex];
            string name = row.Cells[0].Text;
            string phone = row.Cells[1].Text;
            string password = row.Cells[2].Text;
            //Session["EditName"] = name;
            Session["EditPhone"] = phone;
            //Session["EditPassword"] = password;

            if (e.CommandName == "editAgent")
            {
                TextBoxEditAgentName.Text = name;
                TextBoxEditAgentPassword.Text = password;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Modalsuccess", "loadModal();", true);
            }
            if (e.CommandName == "deleteAgent")
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    connection.Execute("ag_AgentDelete @Number", new { Number = phone });
                }
            }
            EmptyTextBoxes();
            edit();
            ViewAgentsTicket();
        }
        protected void GridViewAgentsTicketLists_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewAgentsTicketLists.Rows[rowIndex];
            string name = row.Cells[0].Text;
            if (e.CommandName == "ViewTicket")
            {
                Session["AgentName"] = name;
                Response.Redirect("~/pages/TempDesign/ViewAgentTicketsSold.aspx");
            }

        }
    }
    public class agent
    {
        public string AgentName { get; set; }
        public string AgentPhoneNumber { get; set; }
        public string AgentPassword { get; set; }
    }
    public class AgentTickets
    {
        public string AgentName { get; set; }
        public string AgentPhoneNumber { get; set; }
        public int TotalTickets { get; set; }

    }

}