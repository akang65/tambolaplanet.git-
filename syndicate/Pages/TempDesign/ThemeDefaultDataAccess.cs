using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Pages.TempDesign
{
    public class ThemeDefaultDataAccess
    {
        public void AddGameDetails(DateTime dateTime, string date, int ticketTotal, int ticketCost, int fullhouseTotal)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.basci_sp_addGameDetails @DateTime, @Date,@TicketTotal,@ticketCost,@FullHouseTotal", new
                {
                    DateTime = dateTime,
                    Date = date,
                    TicketTotal = ticketTotal,
                    ticketCost = ticketCost,
                    FullHouseTotal = fullhouseTotal
                });

            }
        }
        public void AddBonus(int fullsheet, int halfsheet, int five, int seven, int star, int top, int middle, int bottom)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                int id = 1;
                connection.Execute("dbo.basic_sp_addBonus @ID,@FullSheet,@HalfSheet,@Five,@Seven, @Star,@Top,@Middle,@Bottom",
                    new
                    {
                        ID = id,
                        FullSheet = fullsheet,
                        HalfSheet = halfsheet,
                        five = five,
                        Seven = seven,
                        Star = star,
                        Top = top,
                        Middle = middle,
                        Bottom = bottom
                    });

            }
        }
        public void AddFullHouse(int o1, int o2, int o3, int o4, int o5, int o6, int o7, int o8, int o9, int o10, int o11, int o12, int total)
        {
            using (

                IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.basic_sp_addFullHouse @o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8,@o9,@o10,@o11,@o12,@FullSheetCount", new
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
        public void DropAllData()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                //string tablevalidateName = tableName + "Validate";
                // tableNameForInsertQuery = tableName;
                connection.Execute("dbo.basic_sp_deleteIfExist");

            }
        }
        public void AddSheetbonus(string name, int fullsheetCount, int sheetc)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_AddFullSheetSerialNo @TicketName,@SheetNumber,@SheetCount", new
                {
                    TicketName = name,
                    Sheetnumber = fullsheetCount,
                    SheetCount = sheetc,
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
        public string Bookingstatus()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query($"select Bookingstatus from dbo.GameDetails").ToList();
                string a = data[0].Bookingstatus.ToString();
                return a;
            }
        }
        public void saveTicketprice(string Tprice)
        {
            int price = Convert.ToInt32(Tprice);

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.basic_saveTicketPrice @Price", new {Price=price}); 
            }
        }
        public void SaveTotalTickets(string TTotal)
        {
            int total = Convert.ToInt32(TTotal);

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.basic_saveTotalTicket @Total", new { Total = total });
            }
        }
        public void ResetAlltickets()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.basic_resetTickets");
            }
        }
        public void updateDate(string date)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
             connection.Execute("dbo.basic_UpdateDateonTickets @Date",new {Date=date});
            }
        }
       

    }
}