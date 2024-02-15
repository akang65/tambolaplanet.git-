using Dapper;
using FormUI;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes;
using syndicate.Classes.backgroundValidation;

namespace syndicate.Pages.AdminControlPages
{
    public partial class GameDetails : System.Web.UI.Page
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
            DetailsTab();
        }
         public void DetailsTab()
        {
            //Game Details
            DataAccessRegistration d = new DataAccessRegistration();
            var gameDetails = d.GetGameDetails();
            LabelGameNumber.Text = gameDetails[0].GameNo.ToString();
            LabelTicketPrice.Text = "₹"+ gameDetails[0].TicketPrice.ToString();
            string dataDate = gameDetails[0].Date;
            DateTime date = Convert.ToDateTime(dataDate);
            LabelDate.Text = date.ToShortDateString();
            LabelTime.Text = d.GetTime();
            LabelTotalTickets.Text = gameDetails[0].TotalTickets.ToString();

            //price Distribution
            List<PriceDistribution> priceDistributions = d.GetPriceDistribution();
            LabelFulls.Text = "₹" + priceDistributions[0].fullsheet;
            LabelHalfs.Text = "₹" + priceDistributions[0].halfsheet;
            Labelfive.Text = "₹" + priceDistributions[0].quickfive;
            Labelseven.Text = "₹" + priceDistributions[0].quickseven;
            LabelTop.Text = "₹" + priceDistributions[0].topLine;
            LabelMiddle.Text = "₹" + priceDistributions[0].middleLine;
            LabelBottom.Text = "₹" + priceDistributions[0].bottomLine;
            int totalfullhouse = priceDistributions[0].totalfhouse;

            //fullhouse price display
            List<FullHousePriceDistribution> fullHousePrices = d.GetFullHousePriceDistribution();
            string[] fh=new string[12];
            fh[0] = fullHousePrices[0].first;
            fh[1] = fullHousePrices[0].second;
            fh[2] = fullHousePrices[0].third;
            fh[3] = fullHousePrices[0].fourth;
            fh[4] = fullHousePrices[0].fifth;
            fh[5] = fullHousePrices[0].sixth;
            fh[6] = fullHousePrices[0].seventh;
            fh[7] = fullHousePrices[0].eighth;
            fh[8] = fullHousePrices[0].ninth;
            fh[9] = fullHousePrices[0].tenth;
            fh[10] = fullHousePrices[0].eleventh;
            fh[11] = fullHousePrices[0].twelfth;
            for (int fl = 1; fl <= totalfullhouse; fl++)
            {
                string f = "F";
                Panel P = (Panel)FindControl(f + fl);
                P.Visible = true;
                string l = "Labelf";
                Label lbl = (Label)FindControl(l + fl);
                lbl.Text = "₹" + fh[fl-1];
            }
        }
 
    }
 
}