using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Tambola.Classes;

namespace syndicate.Classes
{
    public class DisplayTickets  //////WILL IMPLEMENT IT LATER
    {
        public void displayTickets()
        {
            DataAccessForUserInterface ds = new DataAccessForUserInterface();
            int count = ds.selectAll();
            for (int i = 1; i <= count; i++)
            {
                string Ticketname = "TicketNo" + i;
                GridView gridview = new GridView();
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



                dataTable2.Merge(dataTable3);
                dataTable1.Merge(dataTable2);





                gridview.ID = "gridview" + i;
                gridview.CssClass = "table table-bordered table-dark";
                //gridview.AutoGenerateColumns = true;
                //gridview.HeaderStyle.CssClass = "table-primary";
                gridview.ShowHeader = false;
                gridview.DataSource = dataTable1;
                //  gridview.DataBound += new EventHandler(groupHeader);
                gridview.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);

                gridview.DataBind();
                GridViewRow rows = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();
                cell.Text = "Customer Name";
                cell.ColumnSpan = 5;
                rows.Controls.Add(cell);

                cell = new TableHeaderCell();
                cell.ColumnSpan = 4;
                cell.Text = "Ticket Number";
                rows.Controls.Add(cell);

                // row.BackColor = Color.BlanchedAlmond;
                gridview.HeaderRow.Parent.Controls.AddAt(0, rows);
                //grid1.Controls.Add(gridview);


            }
        }

        //private void groupHeader(object sender, EventArgs e)
        //{
        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    TableHeaderCell cell = new TableHeaderCell();
        //    cell.Text = "Customer Name";
        //    cell.ColumnSpan = 5;
        //    row.Controls.Add(cell);

        //    cell = new TableHeaderCell();
        //    cell.ColumnSpan = 4;
        //    cell.Text = "Ticket Number";
        //    row.Controls.Add(cell);

        //    // row.BackColor = Color.BlanchedAlmond;
        //    gridview.HeaderRow.Parent.Controls.AddAt(0, row);
        //}
        private void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int r = 0; r < 90; r++)
                {
                    for (int i = 0; i <= 8; i++)
                    {

                        int num = Convert.ToInt32(e.Row.Cells[i].Text);
                        if (num == 0)
                        {
                            //e.Row.BackColor = Color.Red;
                            e.Row.Cells[i].BackColor = Color.Green;

                        }
                    }
                }
            }


        }
    }
}