using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace syndicate.Classes
{
    public class DataAccessRegistration
    {
        public void AddWhatsAppLinkGroup(string link)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_addWhatsappGroupLink @link", new
                {
                    link = link
                });

            }
        }
        public void AddGameDetails(DateTime dateTime, string date, int ticketTotal, int ticketCost, int fullhouseTotal)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_addGameDetails @DateTime, @Date,@TicketTotal,@ticketCost,@FullHouseTotal", new
                {
                    DateTime = dateTime,
                    Date = date,
                    TicketTotal = ticketTotal,
                    ticketCost = ticketCost,
                    FullHouseTotal = fullhouseTotal
                });

            }
        }
        public void Reschedule(DateTime dateTime, string date)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_RescheduleDateTime @DateTime, @Date", new
                {
                    DateTime = dateTime,
                    Date = date,
                });

            }
        }
        public void AddBonus(int fullsheet, int halfsheet, int five,int seven, int star, int top, int middle, int bottom)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                int id = 1;
                connection.Execute("dbo.sp_addBonus @ID,@FullSheet,@HalfSheet,@Five,@Seven, @Star,@Top,@Middle,@Bottom",
                    new
                    {
                        ID = id,
                        FullSheet = fullsheet,
                        HalfSheet = halfsheet,
                        five = five,
                        Seven=seven,
                        Star = star,
                        Top = top,
                        Middle = middle,
                        Bottom = bottom
                    });

            }
        }
        public string GetTime()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var data = connection.Query<string>("dbo.getTime");
                string time = data.First();
                return time;
            }

        }
        public string GetDate()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var data = connection.Query<string>("dbo.getDate");
                string date = data.First();
                return date;
            }

        }
        public string GetWGroupLink()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var data = connection.Query<string>("dbo.getWhatsappGLink");
                string date = data.First();
                return date;
            }

        }
        public DateTime GetDateTime()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<string>("dbo.getDateTime");
                string date = data.First();
                DateTime datetime = DateTime.Parse(date);
                return datetime;
            }

        }
        //public DateTime GetBookingClosedDateTime()
        //{

        //    using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
        //    {
        //        var data = connection.Query<string>($"select bookingClosed from dbo.GameDetails");
        //        string date = data.First();
        //        DateTime datetime = DateTime.Parse(date);
        //        return datetime;
        //    }

        //}
        public booking[] GetBookingClosedDateTime()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<booking>($"select BookingClosed as Date, Bookingstatus as Status from dbo.GameDetails").ToArray();
                return data;
            }

        }
        public List<GameDetails> GetGameDetails ()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<GameDetails>("dbo.getgameDetails").ToList();
                return data;
            }

        }
        public List<gameDetails> getGameDetails()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<gameDetails>("dbo.getgameDetails").ToList();
                return data;
            }

        }
        public List<PriceDistribution> GetPriceDistribution()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<PriceDistribution>("dbo.getPriceDistribution").ToList();
                return data;
            }

        }
        public List<FullHousePriceDistribution> GetFullHousePriceDistribution()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<FullHousePriceDistribution>("dbo.getFullHousePriceDistribution").ToList();
                return data;
            }

        }
        public void AddFullHouse(int o1, int o2, int o3, int o4, int o5, int o6, int o7, int o8, int o9, int o10, int o11, int o12, int total)
        {
            using (

                IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_addFullHouse @o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8,@o9,@o10,@o11,@o12,@FullSheetCount", new
                {
                    o1 = o1,
                    o2 = o2,
                    o3 = o3,
                    o4 = o4,
                    o5 = o5,
                    o6 = o6,
                    o7 = o7,
                    o8 = o8,
                    o9 = o9,
                    o10 = o10,
                    o11 = o11,
                    o12 = o12,
                    fullsheetCount = total
                }); ;

            }
        }
        public int GetFullHouseCount()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var data = connection.Query<int>("dbo.countFullsheet");
                int count = data.First();
                return count;
            }
        }
    
        public void AddSheetbonus(string name, int fullsheetCount,int sheetc)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_AddFullSheetSerialNo @TicketName,@SheetNumber,@SheetCount", new
                {
                    TicketName = name,
                    Sheetnumber = fullsheetCount,  
                    SheetCount=sheetc,
                });
               
            }
        }
        public void AddHalfSheetbonus(string name, int halfSerialNo, int sheetc)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_addHalfsheetserialNo @TicketName,@SheetNumber,@SheetCount", new
                {
                    TicketName = name,
                    Sheetnumber = halfSerialNo,
                    SheetCount = sheetc,
                });

            }
        }
    }
    public class GameDetails
    {
        public int GameNo { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public int TicketPrice { get; set; }
        public int TotalTickets { get; set; }

    }
    public class gameDetails
    {
        public int GameNo { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public int TicketPrice { get; set; }
        public int TotalTickets { get; set; }

    }
    public class PriceDistribution
    {
        public string fullsheet { get; set; }
        public string halfsheet { get; set; }
        public string  quickfive { get; set; }
        public string quickseven { get; set; }
        public string star { get; set; }
        public string topLine { get; set; }
        public string middleLine { get; set; }
        public string bottomLine { get; set; }
        public int totalfhouse { get; set; }
    }
    public class FullHousePriceDistribution
    {
        public string first { get; set; }
        public string second { get; set; }
        public string third { get; set; }
        public string fourth { get; set; }
        public string fifth { get; set; }
        public string sixth { get; set; }
        public string seventh { get; set; }
        public string eighth { get; set; }
        public string ninth { get; set; }
        public string tenth { get; set; }
        public string eleventh { get; set; }
        public string twelfth { get; set; }
    }
    public class booking
    {
        public string Date { get; set; }
        public int Status { get; set; }

    }
}