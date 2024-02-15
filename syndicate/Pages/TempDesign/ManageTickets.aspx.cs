using Dapper;
using FormUI;
using syndicate.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syndicate.Pages.TempDesign
{
    public partial class ManageTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();

            if (!IsPostBack)
            {
                edit();
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
        protected void ButtonTicketDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TempDesign/TicketinfoDashboard.aspx");
        }

        protected void ButtonresetTicket_Click(object sender, EventArgs e)
        {
            ThemeDefaultDataAccess d = new();
            d.ResetAlltickets();
            Response.Redirect("ManageTickets.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                string name = TextBoxEditName.Text;
                string ticket = Session["TicketNo"].ToString();
                string phone = TextBoxEditPhone.Text;
                connection.Execute("dbo.basic_sp_editTicket @Name,@Ticket ,@Phone", new
                {
                    Name = name,
                    Ticket = ticket,
                    Phone = phone
                }); 
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "closeM", "closeModal();", true);
            edit();
        }
        public void edit()
        {
            List<BookingDetails> Details = new();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                Details = connection.Query<BookingDetails>("dbo.basic_spgetBookingDetails").ToList();

            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"), new DataColumn("TicketNo"),new DataColumn("CustomerNames"), new DataColumn("CustomerPhoneNumber") });
            GridViewBooking.DataSource = Details;
            GridViewBooking.DataBind();
        }
        protected void GridViewAgents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewBooking.Rows[rowIndex];
            string name = row.Cells[1].Text;
            string phone = row.Cells[2].Text;
            string TicketNo = row.Cells[0].Text;
            //Session["EditName"] = name;
            Session["TicketNo"] ="TicketNo"+TicketNo;
            //Session["EditPassword"] = password;

            if (e.CommandName == "EditTicket")
            {
                LabelTicketNo.Text = "Ticket No: " +TicketNo;
                TextBoxEditName.Text = name;
                TextBoxEditPhone.Text = phone;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Modalsuccess", "loadModal();", true);
            }
            if (e.CommandName == "CancelTicket")
            {
                string ticket = Session["TicketNo"].ToString();
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    connection.Execute("dbo.basic_sp_unbook @Ticket", new { Ticket = ticket });
                }
            }
            edit();
        }

        protected void GridViewBooking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("TicketNo", string.Empty);
            }
        }
    }
    public class BookingDetails
    {
        public string TicketNo { get; set; }
        public string CustomerNames { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}