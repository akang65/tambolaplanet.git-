using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes.AgentDataAccess;

namespace syndicate.Pages.Agent
{
    public partial class AgentEditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AgentNumber"] == null)
            {
                Response.Redirect("AgentLogin.aspx");
            }
            else if(!IsPostBack)
            {
                LabelStatus.Visible = false;
            }

        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string Extension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".png"
                || Extension.ToLower() == ".bmp" || Extension.ToLower() == ".jpeg")
            {
                string Number=Session["AgentNumber"].ToString();
                Stream stream = postedFile.InputStream;
                BinaryReader reader = new BinaryReader(stream);
                Byte[] bytes= reader.ReadBytes((int)stream.Length);
                AgentDataAccess ds = new AgentDataAccess();
                ds.AgentUploadimage(Number,fileName,fileSize,bytes);
                Response.Redirect("AgentPanel.aspx");
            }
            else
            {
                LabelStatus.Visible = true;
                LabelStatus.Text = "Only .jpg,.jpef,.png and .bmp files are allowed";
                LabelStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}