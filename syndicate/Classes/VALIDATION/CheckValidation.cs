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
    public class CheckValidation
    {
        public int[] CheckWhatToValidate()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_CheckWhatToValidate").ToArray();
                int count = data.Count();
                int[] array = new int[8];
                array[0] =Convert.ToInt32(data[0].fullS);
                array[1] = Convert.ToInt32(data[0].halfS);
                array[2] = Convert.ToInt32( data[0].quickF);
                array[3] = Convert.ToInt32(data[0].star);
                array[4] = Convert.ToInt32(data[0].topL);
                array[5] = Convert.ToInt32(data[0].midL);
                array[6] = Convert.ToInt32(data[0].bottomL);
                array[7] = Convert.ToInt32(data[0].quickS);
                return array;
            }
        }
        public int fullSheet() //check if there are Winners Already or not
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getFullSheetWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int halfSheet()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getHalfSheetWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int star()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getStarWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int Firstfive()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getFFWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int FirstSeven()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getFSWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int Top()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getTopWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int Middle()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getMiddleWinningCount");
                int verify = data.Count();
                return verify;
            }
        }
        public int Bottom()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getBottomWinningCount");
                int verify = data.Count();
                return verify;
            }
        }

        //ALREADY EMBEDDED IN FULL HOUSE VALIDATION CLASS
        //public int FullHouse()
        //{
        //    using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
        //    {
        //        var data = connection.Query("dbo.sp_getFullHouseCount");
        //        int verify = data.Count();
        //        return verify;
        //    }
        //}
    }
}