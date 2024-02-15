using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using syndicate.Classes.CurrentRandom;
using syndicate.Classes.GlobalVariables;

namespace syndicate.Classes.SqlDependencychanges
{
    public static class OnChangesDependencyGlobal
    {
        public static IEnumerable<GetTCurrentrandom> GetData()
        {
           
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"select [CurrentRandom] ,[TicketNumber],[CustomerName],[WinningName] ,[Place] FROM [dbo].[CurrentRandom] order by id", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new GetTCurrentrandom()
                            {
                                CurrentRandom = x.GetInt32(0),
                                TicketNumber = x.GetString(1),
                                CustomerName = x.GetString(2),
                                WinningName = x.GetString(3),
                                Place = x.GetInt32(4)
                            }).ToArray();
                }
            }

        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = (SqlDependency)sender;
            dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var datas = connection.Query("dbo.sp_getCurrentRandom").ToArray();
                MyHub2.Announce(datas);
            }
            GetData();

        }
        //public static void dispose()
        //{
        //    SqlDependency.Stop(ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString);

        //}
    }
}