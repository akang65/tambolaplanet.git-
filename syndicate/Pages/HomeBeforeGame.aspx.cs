using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tambola.Classes;
using syndicate.Classes;

namespace syndicate.Pages
{
    public partial class HomeBeforeGame : System.Web.UI.Page

    {
        GridView gridview = new GridView(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateData();
            populateFields();


        }
        public void PopulateData()
        {
            DataAccessForUserInterface ds = new DataAccessForUserInterface();
            int count = ds.selectAll(); //count total tickets
            for (int i = 1; i <= count; i++)
            {
                string Ticketname = "TicketNo" + i;
                string TicketOwner = ds.BringTicketOwner(Ticketname);
                GridView gridview = new GridView();
                RetriveTickets RetTik = new RetriveTickets();
                List<RetriveTickets> Ticketdata = ds.GetMasterDetails(Ticketname).ToList();
                DataAccess Td = new DataAccess();

                RetTik.row1 = Ticketdata[0].row1;
                RetTik.row2 = Ticketdata[0].row2;
                RetTik.row3 = Ticketdata[0].row3;

                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add("1");
                dataTable1.Columns.Add("2");
                dataTable1.Columns.Add("3");
                dataTable1.Columns.Add("4");
                dataTable1.Columns.Add("5");
                dataTable1.Columns.Add("6");
                dataTable1.Columns.Add("7");
                dataTable1.Columns.Add("8");
                dataTable1.Columns.Add("9");
                //rows

                // List<int> first = new List<int>();
                foreach (var item in Ticketdata[0].row1)
                {
                    var row = dataTable1.NewRow();
                    row["1"] = item.C0;
                    row["2"] = item.C1;
                    row["3"] = item.C2;
                    row["4"] = item.C3;
                    row["5"] = item.C4;
                    row["6"] = item.C5;
                    row["7"] = item.C6;
                    row["8"] = item.C7;
                    row["9"] = item.C8;
                    dataTable1.Rows.Add(row);

                }
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("1");
                dataTable2.Columns.Add("2");
                dataTable2.Columns.Add("3");
                dataTable2.Columns.Add("4");
                dataTable2.Columns.Add("5");
                dataTable2.Columns.Add("6");
                dataTable2.Columns.Add("7");
                dataTable2.Columns.Add("8");
                dataTable2.Columns.Add("9");
                //rows
                foreach (var item in Ticketdata[0].row2)
                {
                    var row = dataTable2.NewRow();
                    row["1"] = item.C0;
                    row["2"] = item.C1;
                    row["3"] = item.C2;
                    row["4"] = item.C3;
                    row["5"] = item.C4;
                    row["6"] = item.C5;
                    row["7"] = item.C6;
                    row["8"] = item.C7;
                    row["9"] = item.C8;
                    dataTable2.Rows.Add(row);
                }
                DataTable dataTable3 = new DataTable();
                dataTable3.Columns.Add("1");
                dataTable3.Columns.Add("2");
                dataTable3.Columns.Add("3");
                dataTable3.Columns.Add("4");
                dataTable3.Columns.Add("5");
                dataTable3.Columns.Add("6");
                dataTable3.Columns.Add("7");
                dataTable3.Columns.Add("8");
                dataTable3.Columns.Add("9");
                //rows
                foreach (var item in Ticketdata[0].row3)
                {
                    var row = dataTable3.NewRow();
                    row["1"] = item.C0;
                    row["2"] = item.C1;
                    row["3"] = item.C2;
                    row["4"] = item.C3;
                    row["5"] = item.C4;
                    row["6"] = item.C5;
                    row["7"] = item.C6;
                    row["8"] = item.C7;
                    row["9"] = item.C8;
                    dataTable3.Rows.Add(row);
                }

                dataTable2.Merge(dataTable3);
                dataTable1.Merge(dataTable2);

                gridview.ID = "gridview" + i;
                gridview.CssClass = "table table-bordered table-sm h6 text-light text-center table-dark";
                gridview.ShowHeader = false;
                gridview.DataSource = dataTable1;
                //gridview.DataBound += new EventHandler(groupHeader);
                gridview.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);

                gridview.DataBind();
                GridViewRow rows = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                if (TicketOwner == null)
                {
                    rows.CssClass = "border border-success";
                    
                }
                else
                {
                    rows.BorderColor = Color.FromName("#dc3545");
                    rows.ForeColor = Color.FromName("#dc3545");
                }
                TableHeaderCell cell = new TableHeaderCell();
                cell.Style.Add("font-size", "12px");
                if (TicketOwner == null)
                {
                    cell.Text = "Not Booked";
                    cell.CssClass = "bg-success text-light";

                }
                else
                {
                    cell.Text = TicketOwner;
                    cell.ForeColor = Color.FromName("#fff");
                    cell.BackColor = Color.FromName("#dc3545");
                    
                }
                
                cell.ColumnSpan = 4;
                rows.Controls.Add(cell);


                cell = new TableHeaderCell();
                cell.ColumnSpan = 3;
                // cell.BackColor = Color.FromName("#403675");
                cell.Style.Add("font-size", "12px");
                cell.Text = "Ticket No: " + i;
                if (TicketOwner == null)
                {
                    cell.CssClass = "bg-success text-light";
                }
                else
                {
                    cell.ForeColor = Color.FromName("#fff");
                    cell.BackColor = Color.FromName("#dc3545");
                }
                rows.Controls.Add(cell);


                cell = new TableHeaderCell();
                cell.ColumnSpan = 2;
                if (TicketOwner == null)
                {
                    cell.CssClass = "bg-success text-light";
                    Button btn = new Button();
                    btn.Text = "Buy";
                    btn.ID = "ButtonBuy" + i;
                    cell.Style.Add("font-size", "12px");
                    btn.Click += new EventHandler(ButtonBuyClick);
                    //btn.CssClass = "btn btn-primary btn-sm";
                    cell.Controls.Add(btn);

                }
                else
                {
                    cell.CssClass = "text-light";
                    cell.BackColor = Color.FromName("#dc3545");
                    cell.Style.Add("font-size", "12px");
                    cell.Style.Add("color", "#fff");
                    cell.Text = "Booked";
                }
               
                rows.Controls.Add(cell);
                gridview.HeaderRow.Parent.Controls.AddAt(0, rows);
                
                grid1.Controls.Add(gridview);
            }
        }
        private void ButtonBuyClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AgentsLists.aspx");
        }

        [WebMethod]
        public static string passTime()
        {
            DataAccessRegistration ds = new DataAccessRegistration();
            booking[] fDate = ds.GetBookingClosedDateTime();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(fDate);
        }
        [WebMethod]
        public static string passGameTime()
        {
            DataAccessRegistration d = new DataAccessRegistration();
            string fDate = d.GetDateTime().ToString();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(fDate);
        }
        private void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              for (int i = 0; i <= 8; i++)
              {
                 int num = Convert.ToInt32(e.Row.Cells[i].Text);
                    e.Row.Cells[i].BorderWidth=3;
                    e.Row.Cells[i].BorderColor = Color.FromName("#795548");
                    //e.Row.Cells[i].BackColor = Color.FromName("#e6d7f5");

                    if (num == 0)
                 {
                    //e.Row.BackColor = Color.Red;
                    e.Row.Cells[i].Text = "";
                   //e.Row.Cells[i].BackColor = Color.FromName("#FFCA2C");
                 }
               }
            }
        }  

        protected void ButtonWhatsapp_Click(object sender, EventArgs e)
        {
            DataAccessRegistration ds = new DataAccessRegistration();
            string WGrouplink = ds.GetWGroupLink();
            Response.Redirect(WGrouplink);
        }

        protected void ButtonAgentLists_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgentLists");
        }

        protected void ButtonCheckAllTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/tickets");
        }
        public void populateFields()
        {
            
            DataAccessRegistration d = new DataAccessRegistration();
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            List<GameDetails> gameDetails = d.GetGameDetails();
            List<PriceDistribution> priceDist = d.GetPriceDistribution();
            List<FullHousePriceDistribution> fullHousePrices = d.GetFullHousePriceDistribution();
            DateTime date = gameDetails[0].Time;
            String dateonly = date.ToString("yyyy-MM-dd");
            Labeldate.Text = dateonly;
            Labeltime.Text=date.ToString("hh:mm tt"); 
            Labelgameno.Text = gameDetails[0].GameNo.ToString();
            //TextBoxTicketprice.Text = gameDetails[0].TicketPrice.ToString();
            //TextBoxNoOfTickets.Text = gameDetails[0].TotalTickets.ToString();

        }
        public void hideBomus() {
            
        }
    }
}

