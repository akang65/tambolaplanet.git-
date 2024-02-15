using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using FormUI;

namespace syndicate.Classes
{
    public class DataAccessValidationTable
    {
        public void InsertData(string tkName, int R0C0, int R0C1, int R0C2, int R0C3, int R0C4, 
                                int R1C0, int R1C1, int R1C2, int  R1C3,int  R1C4, int R2C0, int R2C1, int  R2C2,
                                int R2C3, int R2C4)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
               
                connection.Execute("dbo.sp_InsertOnTicketValidation @TableName,@R0C0, @R0C1, @R0C2, @R0C3, @R0C4," +
                    "@R1C0, @R1C1, @R1C2 ,@R1C3, @R1C4, " +
                    " @R2C0, @R2C1, @R2C2, @R2C3, @R2C4",
                    new { 
                        TableName = tkName,
                        R0C0 = R0C0,    
                        R0C1 = R0C1,
                        R0C2 = R0C2,
                        R0C3 = R0C3,
                        R0C4 = R0C4,
                        R1C0 = R1C0,
                        R1C1 = R1C1,
                        R1C2 = R1C2,
                        R1C3 = R1C3,
                        R1C4 = R1C4,
                        R2C0 = R2C0,
                        R2C1 = R2C1,
                        R2C2 = R2C2,
                        R2C3 = R2C3,
                        R2C4 = R2C4,

                });

            }
        }
        public string validateWinner()
        {
            //List<string> dataTables = new List<string>();

            using (IDbConnection con = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = con.Query("dbo.testCounting").ToString();
                //    int count = data.Count();
                //    string[] Tables = new string[count]; 
                //    foreach (DataRow row in data)
                //    {
                //        int i = 0;
                //        Tables[i] = (string)row[0];  

                //    }
                //    return Tables ;

                //}
                return data;
            }

        }
        public string[] STARvalidation(int O1, int O2, int O3, int O4, int O5, int O6, int O7, int O8, int O9, int O10,
            int O11, int O12, int O13, int O14, int O15, int O16, int O17, int O18, int O19, int O20,
            int O21, int O22, int O23, int O24, int O25, int O26, int O27, int O28, int O29, int O30,
            int O31, int O32, int O33, int O34, int O35, int O36, int O37, int O38, int O39, int O40,
            int O41, int O42, int O43, int O44, int O45, int O46, int O47, int O48, int O49, int O50, 
            int O51, int O52, int O53, int O54, int O55, int O56, int O57, int O58, int O59, int O60, 
            int O61, int O62, int O63, int O64, int O65, int O66, int O67, int O68, int O69, int O70,
            int O71, int O72, int O73, int O74, int O75, int O76, int O77, int O78, int O79, int O80,
            int O81, int O82, int O83, int O84, int O85, int O86, int O87, int O88, int O89, int O90)
        {
            //List<string> dataTables = new List<string>();
           
            using (IDbConnection con = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = con.Query<string>("dbo.sp_STAR @O1, @O2, @O3, @O4, @O5, @O6, @O7, @O8, @O9, @O10," +
                    " @O11, @O12, @O13, @O14, @O15, @O16, @O17, @O18, @O19, @O20," +
                    " @O21, @O22, @O23, @O24, @O25, @O26, @O27, @O28, @O29, @O30," +
                    " @O31, @O32, @O33, @O34, @O35, @O36, @O37, @O38, @O39, @O40," +
                    " @O41, @O42, @O43, @O44, @O45, @O46, @O47, @O48, @O49, @O50," +
                    " @O51, @O52, @O53, @O54, @O55, @O56, @O57, @O58, @O59, @O60," +
                    " @O61, @O62, @O63, @O64, @O65, @O66, @O67, @O68, @O69, @O70," +
                    " @O71, @O72, @O73, @O74, @O75, @O76, @O77, @O78, @O79, @O80, " +
                    "@O81, @O82, @O83, @O84, @O85, @O86, @O87, @O88, @O89, @O90",new
                    {
                        O1 =O1 ,  O2 = O2,  O3 = O3,   O4 = O4,  O5 = O5,  O6 = O6,  O7 = O7,  O8 = O8,  O9 = O9, O10 = O10,
                        O11 = O11,O12 = O12,O13 = O13,O14 = O14,O15 = O15,O16 = O16,O17 = O17,O18 = O18,O19 =O19 ,O20 = O20,
                        O21 = O21,O22 = O22,O23 = O23,O24 = O24,O25 = O25,O26 = O26,O27 = O27,O28 = O28,O29 = O29,O30 = O30,
                        O31 = O31,O32 = O32,O33 = O33,O34 = O34,O35 = O35,O36 = O36,O37 = O37,O38 = O38,O39 = O39,O40 = O40,
                        O41 = O41,O42 = O42,O43 = O43,O44 = O44,O45 = O45,O46 = O46,O47 = O47,O48 = O48,O49 = O49,O50 = O50,
                        O51 = O51,O52 = O52,O53 = O53,O54 = O54,O55 = O55,O56 = O56,O57 = O57,O58 = O58,O59 = O59,O60 = O60,
                        O61 = O61,O62 = O62,O63 = O63,O64 = O64,O65 = O65,O66 = O66,O67 = O67,O68 = O68,O69 = O69,O70 = O70,
                        O71 = O71,O72 = O72,O73 = O73,O74 = O74,O75 = O75,O76 = O76,O77 = O77,O78 = O78,O79 = O79,O80 = O80,
                        O81 = O81,O82 = O82,O83 = O83,O84 = O84,O85 = O85,O86 = O86,O87 = O87,O88 = O88,O89 = O89,O90=O90
                    }).ToArray();
              
                    int count = data.Count();
                    string[] listOfStarWinners = new string[count];
                    int i = 0;  
                    foreach(var item in data)
                    {
                      listOfStarWinners[i] = (string)item;
                        i++;
                    }
                return listOfStarWinners;
            }
            
        }
       
    }
}