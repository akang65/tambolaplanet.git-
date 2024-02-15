 using Dapper;
using FormUI;
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
using syndicate.Classes;
using syndicate.Classes.AgentDataAccess;
using syndicate.Classes.models;

namespace syndicate.Pages.Agent
{
    public partial class AgentPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataAccessRegistration d = new DataAccessRegistration();
            DateTime fDate = d.GetDateTime();
            fDate.AddSeconds(-20);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "updateDate", "updateDate('" + fDate + "');", true);
            if (Session["AgentNumber"] ==null)
            {
                Response.Redirect("~/agentlogin");
            }
            else if (!IsPostBack)
            {
                refresh();
                DetailsTab();
                LabelPhoneNumber.Text = Session["AgentNumber"].ToString();
            }
         
            AgentDataAccess ds = new AgentDataAccess();
            Byte [] bytes=ds.AgentFetchProfileImage(Session["agentNumber"].ToString());
            LabelAgentProfileName.Text = ds.BringAgentName(Session["agentNumber"].ToString());
            if (bytes==null)
            {
                ImageProfile.ImageUrl = "~/Content/images/default-profile.jpg";
            }
            else
            {
                string base64 = Convert.ToBase64String(bytes);
                ImageProfile.ImageUrl = "data:Image/png;base64," + base64;
            }
           
        }
        //[WebMethod]
        //public static string passTime()
        //{
        //    DataAccessRegistration ds = new DataAccessRegistration();
        //    string fDate = ds.GetBookingClosedDateTime().ToString();
        //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    return serializer.Serialize(fDate);
        //}
        [WebMethod]
        public static string passTime()
        {
            DataAccessRegistration ds = new DataAccessRegistration();
            booking[] fDate = ds.GetBookingClosedDateTime();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(fDate);
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
        public static void  getTicketData(string[] arrayt ,string nameT,string phoneT)
        {
            string[] Tickets = arrayt;
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                for(int i = 0; i < Tickets.Length; i++)
                {
                    string AgentNumber = HttpContext.Current.Session["AgentNumber"].ToString();
                    string ticketName = "TicketNo" + Tickets[i];
                    string name =nameT;
                    string phone = phoneT;
                    AgentDataAccess d = new();
                    d.AgentBuyTicket(name, ticketName, AgentNumber, phone);
                }
               
            }
           
        }
        public void DetailsTab()
        {
            //Game Details
            DataAccessRegistration d = new DataAccessRegistration();
            List<GameDetails> gameDetails = d.GetGameDetails();
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            LabelGameNumber.Text = gameDetails[0].GameNo.ToString();
            string dataDate = gameDetails[0].Date;
            DateTime date = Convert.ToDateTime(dataDate);
            LabelDate.Text = date.ToShortDateString();
            LabelTime.Text = d.GetTime();
            string[] ticketcount = taa.BringSoldTicketsName();
            Labelsold.Text = ticketcount.Length.ToString();
            int Tleft = gameDetails[0].TotalTickets -ticketcount.Length;
            Labelleft.Text = Tleft.ToString();
            //price Distribution
           
        }
        public void fullSheet()
        {
            Buyticket by = new Buyticket();
            //buyTicketsModel buy = new buyTicketsModel();
            List<fullSheet> buyTickets = by.BuyFullSheet().ToList();
            int count = buyTickets.Count();
            if (count == 0)
            {
                PanelFull.Visible = true;
                PanelFull.Style.Add("display", "");
                GridViewFullsheet.Visible = false;
            }
            else
            {
                GridViewFullsheet.Visible = true;
                //PanelFull.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"),
                    new DataColumn("Name"), new DataColumn("Fullsheet") });
                GridViewFullsheet.DataSource = buyTickets;
                GridViewFullsheet.DataBind();
            }


        }
        public void halfSheet()
        {
            Buyticket by = new Buyticket();
            //buyTicketsModel buy = new buyTicketsModel();
            List<halfSheet> buyTickets = by.BuyHalfSheet().ToList();
            int count = buyTickets.Count();
            if (count == 0)
            {
                PanelHalf.Visible = true;
                PanelHalf.Style.Add("display", "");
                GridViewHalfSheet.Visible = false;
            }
            else
            {
                GridViewHalfSheet.Visible = true;
                //PanelHalf.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("HalfSheet") });
                GridViewHalfSheet.DataSource = buyTickets;
                GridViewHalfSheet.DataBind();
            }
        }

        protected void GridViewFullsheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
               
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewFullsheet.Rows[rowIndex];
                string name = (row.FindControl("txtName") as TextBox).Text;
                string sheetName = row.Cells[1].Text;
                string AgentNumber = Session["AgentNumber"].ToString();
                string lbl1 = (row.FindControl("Label1") as Label).Text;
                string lbl2 = (row.FindControl("Label2") as Label).Text;
                string lbl3 = (row.FindControl("Label3") as Label).Text;
                string lbl4 = (row.FindControl("Label4") as Label).Text;
                string lbl5 = (row.FindControl("Label5") as Label).Text;
                string lbl6 = (row.FindControl("Label6") as Label).Text;
                // Button button = (row.FindControl("btn") as Button);
                if (string.IsNullOrEmpty(name))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "loadModalAlert();", true);
                }
                else
                {
                    LabelMStatus.Text = "Invoice";
                    LabelMStatus.CssClass = "text-success";
                    ButtonMConfirm.Enabled = true;
                    LabelMSheetNumber.Text = sheetName;
                    LabelMSheetRange1.Text = lbl1;
                    LabelMSheetRange2.Text = lbl2;
                    LabelMSheetRange3.Text = lbl3;
                    LabelMSheetRange4.Text = lbl4;
                    LabelMSheetRange5.Text = lbl5;
                    LabelMSheetRange6.Text = lbl6;
                    LabelMCustomerName.Text = name;
                    TextBoxMCustomerPhoneNumber.Text = "";
                    Session["SheetButton"] = "FullSheetbtn";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Modalsuccess", "loadModal();", true);
                }
                refresh();
            }
        }

        protected void GridViewHalfSheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewHalfSheet.Rows[rowIndex];
                string name = (row.FindControl("txtName") as TextBox).Text;
                string sheetName = row.Cells[1].Text;
                string AgentNumber = Session["AgentNumber"].ToString();
                string lbl1 = (row.FindControl("Label1") as Label).Text;
                string lbl2 = (row.FindControl("Label2") as Label).Text;
                string lbl3 = (row.FindControl("Label3") as Label).Text;
                if (string.IsNullOrEmpty(name))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "loadModalAlert();", true);
                }
                else
                {
                    LabelMStatus.Text = "Invoice";
                    LabelMStatus.CssClass = "text-success";
                    ButtonMConfirm.Enabled = true;
                    LabelMSheetNumber.Text = sheetName;
                    LabelMSheetRange1.Text = lbl1;
                    LabelMSheetRange2.Text = lbl2;
                    LabelMSheetRange3.Text = lbl3;
                    LabelMCustomerName.Text = name;
                    TextBoxMCustomerPhoneNumber.Text = "";
                    Session["SheetButton"] = "HalfSheetbtn";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Modalsuccess", "loadModal();", true);
                }


            }
            refresh();
        }

        public void MyMemoTable()
        {
            string AgentName = Session["AgentNumber"].ToString();
            Buyticket b = new Buyticket();
            List<Mytickets> mytickets = b.GetMytickets(AgentName).ToList();
            GridViewMyTickets.DataSource = mytickets;
            GridViewMyTickets.DataBind();
            LabelTotalTicketSold.Text = mytickets.Count().ToString();
            LabelTotalTicketSold.DataBind();
        }

        public void refresh()
        {
            DetailsTab();
            fullSheet();
            halfSheet();
            MyMemoTable();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "refresh", "refresh();", true);
        }

        protected void GridViewFullsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string SheetId = DataBinder.Eval(e.Row.DataItem, "Fullsheet").ToString();
                int convertID = Convert.ToInt32(SheetId);

                int max = convertID * 6;
                int six = max;
                int five = max - 1;
                int four = max - 2;
                int three = max - 3;
                int two= max-4;
                int one=max - 5;
                GridViewRow row = e.Row;
                row.Attributes["id"] ="fullsheetserial_"+SheetId;
                Label lbl1 = (e.Row.FindControl("Label1") as Label);
                Label lbl2 = (e.Row.FindControl("Label2") as Label);
                Label lbl3 = (e.Row.FindControl("Label3") as Label);
                Label lbl4 = (e.Row.FindControl("Label4") as Label);
                Label lbl5 = (e.Row.FindControl("Label5") as Label);
                Label lbl6 = (e.Row.FindControl("Label6") as Label);
                lbl1.Text = one.ToString();
                lbl2.Text = two.ToString();
                lbl3.Text = three.ToString();
                lbl4.Text = four.ToString();
                lbl5.Text = five.ToString();
                lbl6.Text = six.ToString();
               // Button button = (e.Row.FindControl("btn") as Button);
                //button.Attributes.Add("data-bs-toggle", "modal");
                //button.Attributes.Add("data-bs-target", "#PhoneNumberModal");
            }
        }

        protected void GridViewHalfSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string SheetId = DataBinder.Eval(e.Row.DataItem, "HalfSheet").ToString();
                int convertID = Convert.ToInt32(SheetId);
                int max = convertID * 3;
                int three = max;
                int two = max - 1;
                int one = max - 2;
                GridViewRow row = e.Row;
                row.Attributes["id"] = "Halfsheetserial_" + SheetId;
                Label lbl1 = (e.Row.FindControl("Label1") as Label);
                Label lbl2 = (e.Row.FindControl("Label2") as Label);
                Label lbl3 = (e.Row.FindControl("Label3") as Label);
                lbl1.Text = one.ToString();
                lbl2.Text = two.ToString();
                lbl3.Text = three.ToString();
            

            }
        }

        protected void ButtonMConfirm_Click(object sender, EventArgs e)
        {
            string AgentNumber = Session["AgentNumber"].ToString();
            AgentDataAccess d = new AgentDataAccess();
            if(Session["SheetButton"].ToString()== "FullSheetbtn")
            {
                int notSold = d.checkFullSheetBought(Convert.ToInt32(LabelMSheetNumber.Text));//lock transaction on sql..to do
                if (notSold == 6)
                {
                    d.AgentBuyFullSheet(LabelMCustomerName.Text, TextBoxMCustomerPhoneNumber.Text, LabelMSheetNumber.Text, AgentNumber);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalscloseFsheet", "closeModal();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalscloseFsheet", "closeModal();", true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alertBoughtAlready();", true);
                    
                }
                refresh();
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalscloseFsheet", "closeModal();", true);
            }
            else if (Session["SheetButton"].ToString() == "HalfSheetbtn")
            {
                int notSold = d.checkHalfSheetBought(Convert.ToInt32(LabelMSheetNumber.Text)); //lock transaction on sql..to do
                if (notSold == 3)
                {
                    d.AgentBuyHalfSheet(LabelMCustomerName.Text, TextBoxMCustomerPhoneNumber.Text, LabelMSheetNumber.Text, AgentNumber);
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalCloseHSheet", "closeModal();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalCloseHSheet", "closeModal();", true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alertBoughtAlready();", true);
                    
                }
               
                refresh();
               // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ModalCloseHSheet", "closeModal();", true);
            }


        }

        protected void modalsell_Click(object sender, EventArgs e)
        {
            //passTicketData()
            ScriptManager.RegisterStartupScript(this, typeof(Page), "tickettab", "passTicketData();", true);
            
        }

        protected void GridViewMyTickets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Sdate = e.Row.Cells[0].Text.ToString();
                DateTime date = Convert.ToDateTime(Sdate);
                e.Row.Cells[0].Text = date.ToShortDateString();
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.Replace("TicketNo",string.Empty);
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
    }
}