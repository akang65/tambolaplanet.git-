using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Tambola.Classes;

namespace FormUI
{
    public class DataAccess
    {
        public string tableNameForInsertQuery;

        public void DropAllData()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                //string tablevalidateName = tableName + "Validate";
                // tableNameForInsertQuery = tableName;
                connection.Execute("dbo.sp_deleteIfExist");

            }
        }
        public void CreateTable(string tableName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                //string tablevalidateName = tableName + "Validate";
                // tableNameForInsertQuery = tableName;
                connection.Execute("dbo.makeTable @TableName", new { TableName = tableName});

            }
        }

        public void InsertData(string tkName, int one, int two, int three, int four, int five, int six, int seven, int eight,
                                int nine, int ten, int eleven, int twelve, int thirteen, int fourteen,
                                int fifteen, int sixteen, int seventeen, int eighteen, int nineteen, int twenty,
                                int twentyone, int twentytwo, int twentythree, int twentyfour,
                                int twentyfive, int twentysix, int twentyseven)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                connection.Execute("dbo.InsertData @TableName , @R0c1 , @R0c2 , @R0c3 , @R0c4 , @R0c5 , @R0c6 , @R0c7 , @R0c8 , @R0c9," +
                    "@R1c1 ,@R1c2, @R1c3, @R1c4, @R1c5, @R1c6, @R1c7, @R1c8, @R1c9," +
                    "@R2c1, @R2c2, @R2c3, @R2c4, @R2c5, @R2c6, @R2c7, @R2c8, @R2c9", new
                    {
                        @TableName = tkName,
                        @R0c1 = one,
                        @R0c2 = two,
                        @R0c3 = three,
                        @R0c4 = four,
                        @R0c5 = five,
                        @R0c6 = six,
                        @R0c7 = seven,
                        @R0c8 = eight,
                        @R0c9 = nine,
                        @R1c1 = ten,
                        @R1c2 = eleven,
                        @R1c3 = twelve,
                        @R1c4 = thirteen,
                        @R1c5 = fourteen,
                        @R1c6 = fifteen,
                        @R1c7 = sixteen,
                        @R1c8 = seventeen,
                        @R1c9 = eighteen,
                        @R2c1 = nineteen,
                        @R2c2 = twenty,
                        @R2c3 = twentyone,
                        @R2c4 = twentytwo,
                        @R2c5 = twentythree,
                        @R2c6 = twentyfour,
                        @R2c7 = twentyfive,
                        @R2c8 = twentysix,
                        @R2c9 = twentyseven
                    });

            }
        }
        public void deletejobs()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_DeleteJobs");
            }
        }
        
        public  List<RetriveTicket> GetAllTicket(string ticketname) 
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Tambola")))
            {
                if (connection.State==ConnectionState.Closed)
                    connection.Open();
                List<RetriveTicket> list=connection.Query<RetriveTicket>("dbo.sp_SelectTable @TableName", new
                {
                    @tableName=ticketname
                }).ToList();
              
                return list;

            } 

        }
           
    }
}
