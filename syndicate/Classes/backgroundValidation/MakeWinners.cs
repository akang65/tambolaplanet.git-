using Dapper;
using FormUI;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using Tambola.Classes;
using syndicate.Classes.backgroundServices;
using syndicate.Classes.GlobalVariables;
using syndicate.Classes.VALIDATION;
using syndicate.Projects.TicketGenerator;

namespace syndicate.Classes.backgroundValidation
{
    public class MakeWinners
    {
        public void StartBackGroundServices(string datetime, string status)
        {
            DateTime Date = DateTime.Parse(datetime).ToUniversalTime();
            DateTime IstDate = Date.AddHours(-7).ToUniversalTime();
            DateTime UtcTime = IstDate.AddHours(-5.5).ToUniversalTime();

            DependencyCounter.date = Date;
            DependencyCounter.Istdate = IstDate;
            DependencyCounter.UTC = UtcTime;
            //DateTime UtcTime = Date.AddHours( 6);

            TimeZoneInfo ArizonaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
            DateTime ArizonaDate = TimeZoneInfo.ConvertTimeFromUtc(IstDate, ArizonaTimeZone);
            DependencyCounter.Arizona = ArizonaDate;
            //DateTime SubTime = Date.AddMinutes(-4);
            if (status == "Rescheduling")
            {
                string jobid = BackgroundJob.Schedule<Tasks>(x => x.rsMakeWinner(), Date).ToString();
                RescheduleJobs rs = new();
                rs.saveJobId(jobid, "MakewinnersJobId");
            }else if (status=="startnow")
            {
                //BackgroundJob.Schedule<Tasks>(x => x.GeneratevalTickets(), TimeSpan.FromSeconds(15));
                DateTime d=DateTime.Now;
                BackgroundJob.Schedule<Tasks>(x => x.GenerateRandomAndNumber(),d);
                string jobid = BackgroundJob.Schedule<Tasks>(x => x.rsMakeWinner(), TimeSpan.FromSeconds(20)).ToString();
                RescheduleJobs rs = new();
                rs.saveJobId(jobid, "MakewinnersJobId");
            }
            else
            {
                //BackgroundJob.Schedule<Tasks>(x => x.GeneratevalTickets(), TimeSpan.FromSeconds(45));
                BackgroundJob.Schedule<Tasks>(x => x.GenerateRandomAndNumber(), DateTime.Now);
                string jobid = BackgroundJob.Schedule<Tasks>(x => x.rsMakeWinner(), Date).ToString();
                RescheduleJobs rs = new();
                rs.saveJobId(jobid, "MakewinnersJobId");
            }

        }
        public void restartGame()
        {
            DateTime Date = DateTime.Now;
            string jobid = BackgroundJob.Schedule<Tasks>(x => x.rsMakeWinner(), Date.AddMinutes(1)).ToString();
        }
        public void resetGame(string date)
        {
            DateTime Date = DateTime.Now;
            BackgroundJob.Schedule<Tasks>(x => x.GenerateRandomAndNumber(), DateTime.Now);
            string jobid = BackgroundJob.Schedule<Tasks>(x => x.rsMakeWinner(), TimeSpan.FromSeconds(20)).ToString();
        }


        public void RemoveJobs()
        {
            RecurringJob.RemoveIfExists("RecurringUpadateRandomTick");
        }

    }
    public class Tasks
    {
        public void GeneratevalTickets()
        {
            ValidationTickets v = new ValidationTickets();
            v.ValTickets();
        }
        //Insert rAndomNumbers on database
        public void GenerateRandomAndNumber()
        {
            int[] random = new int[90];
            random = CreateRandom();
            int tick = 0;
            DataAccessForUserInterface ds = new DataAccessForUserInterface();
            for (int i = 0; i < random.Length; i++)
            {
                int num = random[i];
                ds.insertRandom(num, tick);
            }
         
        }
        public int[] CreateRandom()
        {
            int[] random = new int[90];
            {
                int[] randomNumber = new int[90];
                int count = 0;
                for (int i = 0; i < randomNumber.Length; i++)
                {
                    Random rnd = new Random();
                    int num = rnd.Next(1, 91);
                    if (randomNumber.Contains(num))
                    {
                        i--;
                    }
                    else
                    {
                        randomNumber[i] = num;
                        int countingNumber = randomNumber[i];
                        count++;
                    }
                }
                return randomNumber;

            }
        }
        //REPEATEDLY CALL updatesqlServices method
      
       public void rsMakeWinner()
        {
            CheckValidation c = new CheckValidation();
            int[] bonuses = c.CheckWhatToValidate(); //Returns Price Money if 0 dont do validation
            int fullSheet = bonuses[0];
            int halfSheet = bonuses[1];
            int quickF = bonuses[2];
            int star = bonuses[3];
            int top = bonuses[4];
            int middle = bonuses[5];
            int bottom = bonuses[6];
            int quickS = bonuses[7];
            if (fullSheet != 0)
            {
                DependencyCounter.FullSheet = 1;
            }
            else
            {
                DependencyCounter.FullSheet = 0;
            }
            if (halfSheet != 0)
            {
                DependencyCounter.HalfSheet = 1;
            }
            else
            {
                DependencyCounter.HalfSheet = 0;
            }
            if (quickF != 0)
            {
                DependencyCounter.QuickFive = 1;
            }
            else
            {
                DependencyCounter.QuickFive = 0;
            }
            if (quickS != 0)
            {
                DependencyCounter.QuickSeven = 1;
            }
            else
            {
                DependencyCounter.QuickSeven = 0;
            }
            if (star != 0)
            {
                DependencyCounter.Star = 1;
            }
            else
            {
                DependencyCounter.Star = 0;
            }
            if (top != 0)
            {
                DependencyCounter.TopLine = 1;
            }
            else
            {
                DependencyCounter.TopLine = 0;
            }
            if (middle != 0)
            {
                DependencyCounter.MiddleLine = 1;
            }
            else
            {
                DependencyCounter.MiddleLine = 0;
            }
            if (bottom != 0)
            {
                DependencyCounter.BottomLIne = 1;
            }
            else
            {
                DependencyCounter.BottomLIne = 0;
            }
            DependencyCounter.FullHouse = 1;
            DependencyCounter.GameOver = 0;
            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromSeconds(1)
            };
            var server = new BackgroundJobServer(options);
           // RecurringJob.AddOrUpdate<Job>("RecurringCheckWinners", x => x.GenerateWinners(), "*/1 * * * * *");
            //RecurringJob.AddOrUpdate<Job>("RecurringUpadateRandomTick", x => x.updatesqlservice(), "*/6 * * * * *");
            for(int i = 0; i < 90; i++)
            {

                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    
                    if (DependencyCounter._cancellationtoken==true)
                    {
                        DependencyCounter._cancellationtoken = false;
                        return;
                    }
                    if (i == 89)
                    {
                        DependencyCounter._runningProcess = false;
                    }
                    else
                    {
                        DependencyCounter._runningProcess = true;
                    }
                    var data = connection.Query("dbo.sp_fullHouseCount").ToList();
                    int initialised = data[0].FullHouseNo;
                    int Count = data[0].FullHouseCount;
                    if (Count < initialised)
                    {
                        MakeWinners();
                    }
                    else
                    {
                        i = 90;
                        DataAccessForUserInterface ds = new DataAccessForUserInterface();
                        int[] Tickedcount = ds.getRandom();
                        int count = Tickedcount.Length;
                        ds.RemovelastCount(count);
                        RecurringJob.RemoveIfExists("RecurringUpadateRandomTick");

                    }

                }
            }
            DependencyCounter._runningProcess = false;
        }
        public void MakeWinners()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                DataAccessForUserInterface ds = new DataAccessForUserInterface();
                int[] Tickedcount = ds.getRandom();
                int count = Tickedcount.Length;
                count++;

                ChooseWhatToValidate c = new ChooseWhatToValidate();
                c.chooseWhatBonusTovalidate();
                // connection.Execute("dbo.Sp_DeleteUnsoldtickets");
                connection.Execute("dbo.sp_TickCount @TickCount", new { TickCount = count });
                int currentRandom = ds.incrementTickValue(count);
            }
        }
    }
    public class Job
    {
        public void updatesqlservice()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_fullHouseCount").ToList();
                int initialised = data[0].FullHouseNo;
                int Count = data[0].FullHouseCount;
                if (Count < initialised)
                {
                    DataAccessForUserInterface ds = new DataAccessForUserInterface();
                    int[] Tickedcount = ds.getRandom();
                    int count = Tickedcount.Length;
                    count++;

                    ChooseWhatToValidate c = new ChooseWhatToValidate();
                    c.chooseWhatBonusTovalidate();
                    // connection.Execute("dbo.Sp_DeleteUnsoldtickets");
                    connection.Execute("dbo.sp_TickCount @TickCount", new { TickCount = count });
                    int currentRandom = ds.incrementTickValue(count);
                }
                else
                {
                    DataAccessForUserInterface ds = new DataAccessForUserInterface();
                    int[] Tickedcount = ds.getRandom();
                    int count = Tickedcount.Length;
                    ds.RemovelastCount(count);
                    RecurringJob.RemoveIfExists("RecurringUpadateRandomTick");

                }

            }
        }
    }
}