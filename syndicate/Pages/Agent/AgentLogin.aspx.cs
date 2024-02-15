using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes.AgentDataAccess;

namespace syndicate.Pages.Agent
{
    public partial class AgentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            AgentDataAccess ag = new AgentDataAccess();
           int Agent= ag.AgentLogin(TextBoxNumber.Text,TextBoxPassword.Text);
            if(Agent==1)
            {
                Session["AgentNumber"] = TextBoxNumber.Text;
                Response.Redirect("~/Agent");
                
            }
            else
            {
                Session.RemoveAll();
                LabelWarning.Visible = true;
            }
        }
    }
}