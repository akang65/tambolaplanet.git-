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

namespace syndicate.Pages
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
          
              using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
              {
                    var data = connection.Query("dbo.sp_getAdminLogin").ToArray();
                    String Name= data[0].Name.ToString();
                    String password= data[0].password.ToString();
                    if (TextBoxname.Text==Name && TextBoxPassword.Text==password)
                    {
                    Session["Name"] = TextBoxname.Text;
                    Session["Password"] = TextBoxPassword.Text;
                    Response.Redirect("~/admin");
                    Session.RemoveAll();

                    }
                else
                {
                    LabelError.Visible = true;
                }
              }
            
        }
    }
    //public class adminDetails
    //{
    //    public String Name { get; set; }
    //    public string Password { get; set; }
    //}
}