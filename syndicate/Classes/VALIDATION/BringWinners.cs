using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Classes.VALIDATION
{
    public class BringWinners
    {
        public List<WinnerDetails> FullSheet()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getFullSheetWinningCount").ToList();
                return data;
            }
        }

        public List<WinnerDetails> HalfSheet()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getHalfSheetWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> star()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getStarWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> ff()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getFFWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> fS()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getFSWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> Top()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getTopWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> Mid()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getMiddleWinningCount").ToList();
                return data;
            }
        }
        public List<WinnerDetails> Bottom()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<WinnerDetails>("dbo.sp_getBottomWinningCount").ToList();
                return data;
            }
        }
        public List<BringFullHouse> FullHouse(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<BringFullHouse>("dbo.sp_getFullHouseCount @Place",new {Place=id}).ToList();
                return data;
                
            }
        }
   
    }
    public class BringFullHouse
    {
        public string TicketNo { get; set; }
        public string Name { get; set; }
        public int place { get; set; }
    }
    public class WinnerDetails
    {
        public string TicketNo { get; set; }
        public string Name { get; set; }
    }
}