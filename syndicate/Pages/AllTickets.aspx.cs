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

namespace syndicate.Pages
{
    public partial class AllTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string passArrayToJs()
        {
            List<tabledata> list = new();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                list= connection.Query<tabledata>("sp_geTticketAndCustomer").ToList();
                
            }
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(list);
        }
    }
    public class tabledata
    {
        public string TicketNo { get; set; }
        public string Name { get; set; }
    }
}