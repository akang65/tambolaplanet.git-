using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using syndicate.Classes;

namespace syndicate.Pages
{
    public partial class AudioUpdate : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                bindDropDown();
            }
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadAdd.HasFile)
            {
                string path = Path.GetFileName(FileUploadAdd.PostedFile.FileName);
                path = path.Replace(" ", "");
                FileUploadAdd.SaveAs(Server.MapPath("~/Audio/") + path);            
                bindDropDown();
                LabelInfo.Text = "Uploaded";           
            } 
        }

        protected void ButtonPlay_Click(object sender, EventArgs e)
        {
            string Name = DropDownList1.SelectedItem.Text.ToString();
            string link = "Audio/" + Name;
            link = "<audio Controls  autoplay hidden><Source src=" + link + " " + "type= audio/mpeg></Video>";
            LiteralPlayAudio.Text = link;
            LabelInfo.Text = "Playing audio: " + Name;
            bindDropDown();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string Name = DropDownList1.SelectedItem.Text;
            string FileToDelete;
            FileToDelete = Server.MapPath("~/Audio/" + Name);
            // Delete a file

            File.Delete(FileToDelete);
            bindDropDown();
            LabelInfo.Text = FileToDelete + "Deleted ";
            
        }

        public void bindDropDown()
        {
            DirectoryInfo info = new DirectoryInfo(Server.MapPath("~/Audio/"));
            FileInfo[] Audionames = info.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo item in Audionames)
            {
                list.Add(item);
            }
            DropDownList1.DataSource = list;
            DropDownList1.DataBind();
        }
    }
}