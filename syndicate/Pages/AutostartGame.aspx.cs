using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tambola.Classes;
using syndicate.Classes;
using syndicate.Classes.backgroundServices;
using syndicate.Classes.CurrentRandom;
using syndicate.Classes.GlobalVariables;
using syndicate.Classes.SqlDependencychanges;
using syndicate.Classes.VALIDATION;

namespace syndicate.Pages
{
    public partial class AutostartGame : System.Web.UI.Page
    {
        
        int countTik;
        DataAccessForUserInterface ds = new DataAccessForUserInterface();
        protected void Page_Load(object sender, EventArgs e)
        {
            SubscribeDependency();
            //checkNotificationService();
            //PopulateTickets();
            PopulateData();
            DataAccessRegistration d = new DataAccessRegistration();
            DateTime fDate = d.GetDateTime();
            DateTime two = fDate.AddMinutes(1); 
            booking[] data = d.GetBookingClosedDateTime();
            int status = data[0].Status;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "updateDate", "updateDate('" + two + "','" + status + "');", true);
            DataAccessForUserInterface ds = new DataAccessForUserInterface();
            countTik = ds.selectAll();  
            if (!IsPostBack)
            {
                
                LabelTicketShowStatus.Visible = false;
            }
                
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

                gridview.ID = "GridView" + i;
                gridview.CssClass = "table table-bordered table-sm h6 text-dark text-center";
                gridview.Style.Add("background-color", "#adb5bd");
                gridview.Style.Add("display", "none");
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
                    rows.BorderColor = Color.FromName("#fd7e14");
                    rows.ForeColor = Color.FromName("#212529");
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
                    cell.BackColor = Color.FromName("#002366");

                }
                cell.ColumnSpan = 4;
                rows.Controls.Add(cell);


                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
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
                    cell.BackColor = Color.FromName("#002366");
                }
                rows.Controls.Add(cell);


                cell = new TableHeaderCell();
                cell.ColumnSpan = 1;
                cell.Style.Add("background", "#002366");
                ImageButton bt = new ImageButton();
                bt.ID = "Button" + i;
                bt.OnClientClick = "javascript:return false;";
                bt.ImageUrl = "../Content/images/cancelBT.png";
                bt.CssClass = "img-fluid";
                cell.Controls.Add(bt);
                rows.Controls.Add(cell);
                gridview.HeaderRow.Parent.Controls.AddAt(0, rows);
                grid1.Controls.Add(gridview);   
            }
        }
        public void PopulateTickets()
        {
            DataAccessForUserInterface ds = new DataAccessForUserInterface();
            int count = ds.selectAll();
            for (int i = 0; i < count; i++)
            {
                int inc = i + 1;
                string Ticketname = "TicketNo" + inc;
                string TicketOwner = ds.BringTicketOwner(Ticketname);
                GridView gridview = (GridView)FindControl("GridView" + inc);
                RetriveTickets RetTik = new RetriveTickets();
                List<RetriveTickets> Ticketdata = ds.GetMasterDetails(Ticketname).ToList();
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
                //Merge
                dataTable2.Merge(dataTable3);
                dataTable1.Merge(dataTable2);

                gridview.CssClass = "table table-bordered border-4 border-success table-sm h6 table-light text-dark";
                gridview.ShowHeader = false;
                gridview.DataSource = dataTable1;
                gridview.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);
                gridview.DataBind();
                GridViewRow rows = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
               
                TableHeaderCell cell = new TableHeaderCell();
                cell.Style.Add("font-size", "12px");
                cell.Style.Add("color", "#fff");
                cell.Style.Add("background", "#2e9699");
                if (TicketOwner == null)
                {
                    cell.Text = "Not Booked";
                }
                else
                {
                    cell.Text = TicketOwner;
                }
                cell.ColumnSpan = 4;
                rows.Controls.Add(cell);
                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Style.Add("font-size", "12px");
                cell.Style.Add("background", "#2e9699");
                cell.Style.Add("color", "#fff");
                cell.Text = "Ticket Number: " + inc;
                rows.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 1;
                cell.Style.Add("background", "#fd7e14");
                ImageButton bt = new ImageButton();
                bt.ID = "Button" + inc;
                bt.OnClientClick = "javascript:return false;";
                bt.ImageUrl = "../Content/images/cancelBT.png";
                bt.CssClass = "img-fluid";
                cell.Controls.Add(bt);
                rows.Controls.Add(cell); 
                gridview.HeaderRow.Parent.Controls.AddAt(0, rows);
            }
        }

        [WebMethod]
        public static string passArrayToJs()
        {
            DataAccessForUserInterface da = new DataAccessForUserInterface();
            int[] randomList = da.getTockedRandom();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(randomList);

        }
        [WebMethod]
        public static string CRandom()
        {
            DataAccessForUserInterface da = new DataAccessForUserInterface();
            cRandom[] current = da.geturrentRandom();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(current);

        }
        [WebMethod]
        public static string HideWinnerTable()
        {
            DataAccessRegistration d = new DataAccessRegistration();
            List<PriceDistribution> priceDist = d.GetPriceDistribution();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(priceDist);

        }
     
        private void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataAccessForUserInterface da = new DataAccessForUserInterface();
            int[] randomList = da.getTockedRandom();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int r = 0; r < randomList.Length; r++)
                {
                    for (int i = 0; i <= 8; i++)
                    {
                        string num =e.Row.Cells[i].Text;
                        e.Row.Cells[i].BorderWidth = 3;
                        e.Row.Cells[i].BorderColor = Color.FromName("#795548"); 
                        if (num != "0" && num == randomList[r].ToString())
                        {
                            e.Row.Cells[i].BackColor = Color.FromName("#fd7e14");
                          

                        }
                        if (num == "0")
                        {
                            e.Row.Cells[i].Text = "";
                        } 
                    }
                }
            }

        } 
    }
}
