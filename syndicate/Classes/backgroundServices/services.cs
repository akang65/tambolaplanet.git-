using Dapper;
using FormUI;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tambola.Classes;
using syndicate.Classes.SqlDependencychanges;
using syndicate.Classes.VALIDATION;

namespace syndicate.Classes.backgroundServices
{
    public class services
    {
        //START GAME ON THIS DATE
        public void StartGameService(string datetime)
        {
            RemoveJobs();

            DateTime Date = DateTime.Parse(datetime).ToUniversalTime();
            DateTime IstDate = Date.AddHours(-7).ToUniversalTime();
            DateTime UtcTime = IstDate.AddHours(-5.5).ToUniversalTime();
            DateTime SubTime = UtcTime.AddMinutes(1).ToUniversalTime();
            //DateTime IndianTime = SubTime.AddHours(-6);
            //TimeZoneInfo ArizonaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
            //DateTime ArizonaDate = TimeZoneInfo.ConvertTimeFromUtc(IndianTime, ArizonaTimeZone);
            //var specified = DateTime.SpecifyKind(updatedDate, DateTimeKind.Utc);
            //double difference = TimeDifference(updatedDate);

            string jobid = BackgroundJob.Schedule<Tasks>(x => x.StartGameService(), Date.AddMinutes(1)).ToString();

            RescheduleJobs rs = new();
            rs.saveJobId(jobid, "mS");
        }

        public void RemoveJobs()
        {
            RecurringJob.RemoveIfExists("UpdateRandomTock");
        }
    }


    public class Tasks
    {
        //REPEATEDLY CALL updatesqlServices method
        public void StartGameService()
        {
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            string[] ticketcount = taa.BringSoldTicketsName();
            if (ticketcount.Length >= 6)
            {
                var options = new BackgroundJobServerOptions
                {
                    SchedulePollingInterval = TimeSpan.FromSeconds(3)
                };
                var server = new BackgroundJobServer(options);
                RecurringJob.AddOrUpdate<Job>("UpdateRandomTock", x => x.updatesqlservice(), "*/9 * * * * *"); //Repeatedly Update Tock delay 10 sec
            }
        }
    }

    public class Job
    {
        //Update random Tick
        public void updatesqlservice()
        {
             DataAccessForUserInterface ds = new DataAccessForUserInterface();
             int[] Tickedcount = ds.getTockedRandom();
             int count = Tickedcount.Length;
            if (count == 89)
            {
                DataAccess tk = new();
                tk.deletejobs();
            }
             count++;
             using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
             {
                connection.Execute("dbo.sp_TockCount @TockCount", new { TockCount = count });//Increment Tock
                //int currentRandom = ds.incrementTickValue(count);
                var datas= connection.Query<CurrentRandomDetails>("sp_SelectRandomTockWinnerList @Id",new {Id=count}).ToList();
                int id = datas[0].id; int RandomNumber = datas[0].RandomNumber; string TopLine = datas[0].TopLine; string MiddleLine = datas[0].MiddleLine;
                string BottomLine= datas[0].BottomLine; string FirstFive = datas[0].FirstFive; string FirstSeven = datas[0].FirstSeven;
                string FullHouse = datas[0].FullHouse; string FullSheet = datas[0].FullSheet; string Halfsheet = datas[0].HalfSheet; string Star = datas[0].Star;
                int GameOver = datas[0].Tick;

                if (GameOver == 0)
                {
                    connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                    { Number = 0, TicketNo = "GameOver", CustomerName = "GameOver", WinningName = "GameOver", Place = 0 });
                    RecurringJob.RemoveIfExists("UpdateRandomTock");
                }
                else
                {
                    if (TopLine == "TOPLINE")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> top = new List<WinnerDetails>();
                        top = b.Top();
                        for (int i = 0; i < top.Count; i++)
                        {
                            string name = top[i].Name;
                            string ticketNo = top[i].TicketNo;
                            string wName = "TOPLINE";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }


                    }
                    if (MiddleLine == "MIDDLELINE")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> mid = new List<WinnerDetails>();
                        mid = b.Mid();
                        for (int i = 0; i < mid.Count; i++)
                        {
                            string name = mid[i].Name;
                            string ticketNo = mid[i].TicketNo;
                            string wName = "MIDDLELINE";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }
                    }
                    if (BottomLine == "BOTTOMLINE")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> bottom = new List<WinnerDetails>();
                        bottom = b.Bottom();
                        for (int i = 0; i < bottom.Count; i++)
                        {
                            string name = bottom[i].Name;
                            string ticketNo = bottom[i].TicketNo;
                            string wName = "BOTTOMLINE";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }

                    }
                    if (FirstFive == "FIRSTFIVE")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> ff = new List<WinnerDetails>();
                        ff = b.ff();
                        for (int i = 0; i < ff.Count; i++)
                        {
                            string name = ff[i].Name;
                            string ticketNo = ff[i].TicketNo;
                            string wName = "FIRSTFIVE";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }

                    }
                    if (FirstSeven == "FIRSTSEVEN")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> fS = new List<WinnerDetails>();
                        fS = b.fS();
                        for (int i = 0; i < fS.Count; i++)
                        {
                            string name = fS[i].Name;
                            string ticketNo = fS[i].TicketNo;
                            string wName = "FIRSTSEVEN";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }
                    }
                    if (FullSheet == "FULLSHEET")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> fullsheet = new List<WinnerDetails>();
                        fullsheet = b.FullSheet();
                        for (int i = 0; i < fullsheet.Count; i++)
                        {
                            string name = fullsheet[i].Name;
                            string ticketNo = fullsheet[i].TicketNo;
                            string wName = "FULLSHEET";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }

                    }
                    if (Halfsheet == "HALFSHEET")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> halfsheet = new List<WinnerDetails>();
                        halfsheet = b.HalfSheet();
                        for (int i = 0; i < halfsheet.Count; i++)
                        {
                            string name = halfsheet[i].Name;
                            string ticketNo = halfsheet[i].TicketNo;
                            string wName = "HALFSHEET";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }

                    }
                    if (Star == "STAR")
                    {
                        BringWinners b = new BringWinners();
                        List<WinnerDetails> star = new List<WinnerDetails>();
                        star = b.star();
                        for (int i = 0; i < star.Count; i++)
                        {
                            string name = star[i].Name;
                            string ticketNo = star[i].TicketNo;
                            string wName = "STAR";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = 0 });
                        }
                    }
                    if (FullHouse == "FULLHOUSE")
                    {
                        BringWinners b = new BringWinners();
                        List<BringFullHouse> fullhouse = new List<BringFullHouse>();
                        fullhouse = b.FullHouse(count);
                        for (int i = 0; i < fullhouse.Count; i++)
                        {
                            string name = fullhouse[i].Name;
                            string ticketNo = fullhouse[i].TicketNo;
                            int place = fullhouse[i].place;
                            string wName = "FULLHOUSE";
                            connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                            { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = place });
                        }
                    }
                    if (TopLine == null && MiddleLine == null && BottomLine == null && Star == null && FirstFive == null && FirstSeven == null && FullSheet == null
                         && Halfsheet == null && FullHouse == null)
                    {
                        string name = "Default";
                        string ticketNo = "Default";
                        int place = 0;
                        string wName = "Default";
                        connection.Execute("dbo.sp_UpdateCurrentRandom @Number,@TicketNo,@CusTomerName,@WinningName,@Place", new
                        { Number = RandomNumber, TicketNo = ticketNo, CustomerName = name, WinningName = wName, Place = place });
                    }
                }
                

             }
        }
    }
    public class CurrentRandomDetails
    {
        public int id { get; set; }
        public int RandomNumber { get; set; }
        public int Tick { get; set; }
        public string Tock { get; set; }
        public string TopLine { get; set; }
        public string MiddleLine { get; set; }
        public string BottomLine { get; set; }
        public string FirstFive { get; set; }
        public string FirstSeven { get; set; }
        public string Star { get; set; }
        public string FullHouse { get; set; }
        public string FullSheet { get; set; }
        public string HalfSheet { get; set; }

    }
}