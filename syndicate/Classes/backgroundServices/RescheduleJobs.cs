using Dapper;
using FormUI;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using syndicate.Classes.backgroundValidation;
using syndicate.Classes.SqlDependencychanges;

namespace syndicate.Classes.backgroundServices
{
    public class RescheduleJobs
    {
        public void saveJobId(string id, string m)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                if (m == "MakewinnersJobId")
                {
                    connection.Execute("dbo.sp_saveWinnersJob @JiD", new { JiD=id});
            
                }
                else if (m == "mS")
                {
                    connection.Execute("dbo.sp_saveStartTimeJob  @JiD", new { JiD = id });
                }
            }
        }
        public void reschedulejob(string ReScheduled_date)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
              var jobIds= connection.Query("select WinnersJobId, StartTimeJobId from dbo.GameDetails").ToList();
                BackgroundJob.Delete(jobIds[0].WinnersJobId);
                BackgroundJob.Delete(jobIds[0].StartTimeJobId);

                MakeWinners m = new();
                m.StartBackGroundServices(ReScheduled_date,"Rescheduling");
                services s = new();
                s.StartGameService(ReScheduled_date);
            }
        }
    }
}