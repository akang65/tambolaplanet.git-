using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes;
using syndicate.Classes.backgroundServices;
using System.Web.Caching;
using System.Configuration;
using syndicate.Classes.CurrentRandom;
using System.Data;
using syndicate.Classes.SqlDependencychanges;
using syndicate.Classes.backgroundValidation;
using syndicate.Classes.GlobalVariables;
using Job = syndicate.Classes.backgroundValidation.Job;
using syndicate.Classes.VALIDATION;

namespace syndicate.Pages
{
    public partial class Tempaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////OnChangesDependencyGlobal.GetData();
            //SqlDependency.Stop(ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString);
            Label1.Text = DependencyCounter.Count.ToString();
            Label2.Text = DependencyCounter.TopLine.ToString();
            Label3.Text = DependencyCounter.MiddleLine.ToString();
            Label4.Text = DependencyCounter.BottomLIne.ToString();
            Label5.Text = DependencyCounter.QuickFive.ToString();
            Label6.Text = DependencyCounter.QuickSeven.ToString();
            Label7.Text = DependencyCounter.GameOver.ToString();
            Label8.Text = DependencyCounter.FullSheet.ToString();
            Label9.Text = DependencyCounter.HalfSheet.ToString();
            Label10.Text = DateTime.Now.ToString();
            Label11.Text = DateTime.Now.ToLocalTime().ToString();
            Label12.Text = DateTime.UtcNow.ToString();
            Labelutc.Text = DependencyCounter.date.ToString();
            Labelist.Text = DependencyCounter.Istdate.ToString();
            LabelArizona.Text = DependencyCounter.Arizona.ToString();
            LabelUtcTime.Text= DependencyCounter.UTC.ToString();
            //Job j = new();
            //j.updatesqlservice();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label14.Text = TextBox1.Text;
            Halfsheet h = new();
            h.DoValidation();
        }
    }

}