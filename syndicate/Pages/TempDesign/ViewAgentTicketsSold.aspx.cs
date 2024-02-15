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

namespace syndicate.Pages.TempDesign
{
    public partial class ViewAgentTicketsSold : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AgentName"] != null)
            {
                populateGridview();
            }
            else
            {
                Response.Redirect("~/admin");
            }
        }
        public void populateGridview()
        {
            string name = Session["AgentName"].ToString();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
               var data= connection.Query<Details>("dbo.basic_sp_GetagentSoldTicket @Name", new { Name = name });
                GridViewMyTickets.DataSource = data;
                GridViewMyTickets.DataBind();
            }
            
        }
        public class Details
        {
            public string Date { get; set; }
            public string Tk_no { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        protected void GridViewMyTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Sdate = e.Row.Cells[0].Text.ToString();
                DateTime date = Convert.ToDateTime(Sdate);
                e.Row.Cells[0].Text = date.ToShortDateString();
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.Replace("TicketNo", string.Empty);
            }
        }
    }
}