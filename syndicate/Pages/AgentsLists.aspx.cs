using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syndicate.Pages
{
    public partial class AgentsLists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Call")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                //string name = row.Cells[0].Text;
                string PhoneNo = row.Cells[1].Text;
                string callLinlk = "tel:" + PhoneNo;
                Response.Redirect(callLinlk);
                
            }else if(e.CommandName== "Whatsapp")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string name = row.Cells[0].Text;
                string PhoneNo = row.Cells[1].Text;
                if (PhoneNo.Contains("+91"))
                {
                    string messageLink = "https://wa.me/" + PhoneNo + "?text=Hi, Agent " + name + " I Want to Book a Ticket";
                    Response.Redirect(messageLink);
                }
                else
                {
                    string messageLink = "https://wa.me/+91" + PhoneNo + "?text=Hi, Agent " + name + " I Want to Book a Ticket";
                    Response.Redirect(messageLink);
                }  
            }

        }
    }
}