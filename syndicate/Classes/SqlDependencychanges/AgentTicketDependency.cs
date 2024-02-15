
using Dapper;
using FormUI;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using syndicate.Classes.CurrentRandom;

namespace syndicate.Classes.SqlDependencychanges
{
    public static  class AgentTicketDependency
    {
        public static DataTable GetAgentTickets()
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AgentTickets"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"select [TicketNumber],[CustomerName],[Sold] FROM [dbo].[SheetBonus]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["AgentTickets"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    dt.Load(command.ExecuteReader(
             CommandBehavior.CloseConnection));
                    return dt;
                }
                
            }    

        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = (SqlDependency)sender;
            dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var datas = connection.Query($"select * from dbo.SheetBonus").ToArray();
                AgentHub.UpdateTable(datas);
            }
            GetAgentTickets();

        }
        //public static void dispose()
        //{
        //    SqlDependency.Stop(ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString);

        //}
    }
}