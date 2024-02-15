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

namespace syndicate.Pages.AdminControlPages
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCheck l = new();
            string[] auth = l.Authenticate();
            if (Session["Name"] != null)
            {
                if (Session["Name"].ToString() != auth[0] && Session["Password"].ToString() != auth[1])
                {
                    Response.Redirect("../LoginAdmin.aspx");
                }
            }
            else if (Session["Name"] == null)
            {
                Response.Redirect("../LoginAdmin.aspx");
            }

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TextBoxName.Text) || String.IsNullOrEmpty(TextBoxPhone.Text)|| String.IsNullOrEmpty(TextBoxPassword.Text)|| String.IsNullOrEmpty(TextBoxConfirm.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateDate", "formError();", true);
            }
            else if (TextBoxPassword.Text!= TextBoxConfirm.Text)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateDate", "passwordUnMatch();", true);
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    connection.Execute("dbo.SP_ADMINUPDATE @Name,@Phone,@Password",new
                    {
                        Name=TextBoxName.Text, Phone=TextBoxPhone.Text, Password=TextBoxPassword.Text
                    });
                }
                TextBoxName.Text = "";
                TextBoxPhone.Text = "";
                TextBoxPassword.Text = "";
                TextBoxConfirm.Text = "";
                LabelSuccess.Text = "successful";
            }
        }
    }
}