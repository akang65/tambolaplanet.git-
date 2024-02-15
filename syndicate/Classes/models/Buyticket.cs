using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Classes.models
{
    public class buyTicketsModel
    {

        public string Name { get; set; }
        public string TicketNumber { get; set; }
    }
    public class fullSheet
    {
        public string Name { get; set; }
        public int Fullsheet { get; set; }
        

    }
    public class halfSheet
    {
        public string Name { get; set; }
        public string TicketNumber { get; set; }
        public int Fullsheet { get; set; }
        public int HalfSheet { get; set; }
    }
    public class Mytickets
    {
        public string Date { get; set; }
        public string Tk_no { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
      
    }
    public class Buyticket
    {
        public IEnumerable<buyTicketsModel> BuyTickets()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
               var data= connection.Query<buyTicketsModel>("dbo.sp_buyTickets").ToList();
                return data;

            }
        }
      

        public IEnumerable<fullSheet> BuyFullSheet()
        {
            int totalSheetcount = ReturnFullSheetCount();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<fullSheet>("dbo.sp_buyFullSheet @SheetCount", new {SheetCount=totalSheetcount}).ToList();
                return data;
            }
        }
        public IEnumerable<halfSheet> BuyHalfSheet()
        {
            int totalSheetcount = ReturnHalfSheetCount();
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<halfSheet>("dbo.sp_buyHalfSheet @SheetCount" ,new { SheetCount = totalSheetcount }).ToList();
                return data;
            }
        }
        public int ReturnFullSheetCount()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getSheetCount");
                int c = data.First();
                return c;
            }
        }
        public int ReturnHalfSheetCount()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getHalfSheetCount");
                int c = data.First();
                return c;
            }
        }
        public IEnumerable<Mytickets> GetMytickets(string agentName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<Mytickets>("dbo.sp_getMyTickets @AgentName", new {AgentName=agentName}).ToList();
                
                return data;
            }
        }
    }
}