using syndicate.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syndicate.Pages.TempDesign
{
    public partial class whatsapplink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonsave_Click(object sender, EventArgs e)
        {
            DataAccessRegistration ds = new DataAccessRegistration();
            {
                if (string.IsNullOrWhiteSpace(TextBoxlink.Text))
                {
                    //Do something
                }
                else
                {
                    ds.AddWhatsAppLinkGroup(TextBoxlink.Text);
                    Buttonsave.Text = "saved";

                }
            }
        }
    }
}