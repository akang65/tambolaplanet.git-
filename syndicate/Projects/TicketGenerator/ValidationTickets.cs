using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Projects.TicketGenerator
{
    public class ValidationTickets
    {
          public void ValTickets()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                List<List<int>> list = new ();
               var data= connection.Query<Tickets>("select * from dbo.Tickets").ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    List<int> listInt = new(); 
                    if (data[i].R0c1 != 0)
                    {
                        listInt.Add(data[i].R0c1);
                    }
                    if (data[i].R0c2 != 0)
                    {
                        listInt.Add(data[i].R0c2);
                    }
                    if (data[i].R0c3 != 0)
                    {
                        listInt.Add(data[i].R0c3);
                    }
                    if (data[i].R0c4 != 0)
                    {
                        listInt.Add(data[i].R0c4);
                    }
                    if (data[i].R0c5 != 0)
                    {
                        listInt.Add(data[i].R0c5);
                    }
                    if (data[i].R0c6 != 0)
                    {
                        listInt.Add(data[i].R0c6);
                    }
                    if (data[i].R0c7!= 0)
                    {
                        listInt.Add(data[i].R0c7);
                    }
                    if (data[i].R0c8 != 0)
                    {
                        listInt.Add(data[i].R0c8);
                    }
                    if (data[i].R0c9 != 0)
                    {
                        listInt.Add(data[i].R0c9);
                    }
                    if (data[i].R1c1 != 0)
                    {
                        listInt.Add(data[i].R1c1);
                    }
                    if (data[i].R1c2 != 0)
                    {
                        listInt.Add(data[i].R1c2);
                    }
                    if (data[i].R1c3 != 0)
                    {
                        listInt.Add(data[i].R1c3);
                    }
                    if (data[i].R1c4 != 0)
                    {
                        listInt.Add(data[i].R1c4);
                    }
                    if (data[i].R1c5 != 0)
                    {
                        listInt.Add(data[i].R1c5);
                    }
                    if (data[i].R1c6 != 0)
                    {
                        listInt.Add(data[i].R1c6);
                    }
                    if (data[i].R1c7 != 0)
                    {
                        listInt.Add(data[i].R1c7);
                    }
                    if (data[i].R1c8 != 0)
                    {
                        listInt.Add(data[i].R1c8);
                    }
                    if (data[i].R1c9 != 0)
                    {
                        listInt.Add(data[i].R1c9);
                    }
                    if (data[i].R2c1 != 0)
                    {
                        listInt.Add(data[i].R2c1);
                    }
                    if (data[i].R2c2 != 0)
                    {
                        listInt.Add(data[i].R2c2);
                    }
                    if (data[i].R2c3 != 0)
                    {
                        listInt.Add(data[i].R2c3);
                    }
                    if (data[i].R2c4 != 0)
                    {
                        listInt.Add(data[i].R2c4);
                    }
                    if (data[i].R2c5 != 0)
                    {
                        listInt.Add(data[i].R2c5);
                    }
                    if (data[i].R2c6 != 0)
                    {
                        listInt.Add(data[i].R2c6);
                    }
                    if (data[i].R2c7 != 0)
                    {
                        listInt.Add(data[i].R2c7);
                    }
                    if (data[i].R2c8 != 0)
                    {
                        listInt.Add(data[i].R2c8);
                    }
                    if (data[i].R2c9 != 0)
                    {
                        listInt.Add(data[i].R2c9);
                    }
                    list.Add(listInt);
                }

                DataTable dataTable = new();
                dataTable.Columns.Add("TicketNumber", typeof(string));
                dataTable.Columns.Add("C0R0");
                dataTable.Columns.Add("C1R0");
                dataTable.Columns.Add("C2R0");
                dataTable.Columns.Add("C3R0");
                dataTable.Columns.Add("C4R0");

                dataTable.Columns.Add("C0R1");
                dataTable.Columns.Add("C1R1");
                dataTable.Columns.Add("C2R1");
                dataTable.Columns.Add("C3R1");
                dataTable.Columns.Add("C4R1");

                dataTable.Columns.Add("C0R2");
                dataTable.Columns.Add("C1R2");
                dataTable.Columns.Add("C2R2");
                dataTable.Columns.Add("C3R2");
                dataTable.Columns.Add("C4R2");


                for (int i = 0; i < list.Count; i++)
                {
                    string ticketname = data[i].TicketNumber;
                    //int t = i + 1;
                    //string Ticketname = "TicketNo" + t;
                    List<int> newlist= list[i];
                    dataTable.Rows.Add(new object[]
                    {
                   ticketname,
                   newlist[0],newlist[1],newlist[2],newlist[3],newlist[4],newlist[5],newlist[6],newlist[7],newlist[8],newlist[9],
                   newlist[10],newlist[11],newlist[12],newlist[13],newlist[14]
                    });
                }
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                        {
                            bulkCopy.DestinationTableName = "dbo.TicketValidation";
                            bulkCopy.ColumnMappings.Add("TicketNumber", "TicketNumber");
                            bulkCopy.ColumnMappings.Add("C0R0", "C0R0");
                            bulkCopy.ColumnMappings.Add("C1R0", "C1R0");
                            bulkCopy.ColumnMappings.Add("C2R0", "C2R0");
                            bulkCopy.ColumnMappings.Add("C3R0", "C3R0");
                            bulkCopy.ColumnMappings.Add("C4R0", "C4R0");

                            bulkCopy.ColumnMappings.Add("C0R1", "C0R1");
                            bulkCopy.ColumnMappings.Add("C1R1", "C1R1");
                            bulkCopy.ColumnMappings.Add("C2R1", "C2R1");
                            bulkCopy.ColumnMappings.Add("C3R1", "C3R1");
                            bulkCopy.ColumnMappings.Add("C4R1", "C4R1");

                            bulkCopy.ColumnMappings.Add("C0R2", "C0R2");
                            bulkCopy.ColumnMappings.Add("C1R2", "C1R2");
                            bulkCopy.ColumnMappings.Add("C2R2", "C2R2");
                            bulkCopy.ColumnMappings.Add("C3R2", "C3R2");
                            bulkCopy.ColumnMappings.Add("C4R2", "C4R2");


                            bulkCopy.WriteToServer(dataTable);
                        }
                        tran.Commit();
                    }
                }

             }
        }
    }
    public class ValTickets
    {
        public string TicketNumber { get; set; }
        public int C0R0 { get; set; }
        public int C1R0 { get; set; }
        public int C2R0 { get; set; }
        public int C3R0 { get; set; }
        public int C4R0 { get; set; }
        public int C0R1 { get; set; }
        public int C1R1 { get; set; }
        public int C2R1 { get; set; }
        public int C3R1 { get; set; }
        public int C4R1 { get; set; }
        public int C0R2 { get; set; }
        public int C1R2 { get; set; }
        public int C2R2 { get; set; }
        public int C3R2 { get; set; }
        public int C4R2 { get; set; }
    }
    public class Tickets
    {
        public string TicketNumber { get; set; }
        public int R0c1 { get; set; }
        public int R0c2 { get; set; }
        public int R0c3 { get; set; }
        public int R0c4 { get; set; }
        public int R0c5 { get; set; }
        public int R0c6 { get; set; }
        public int R0c7 { get; set; }
        public int R0c8 { get; set; }
        public int R0c9 { get; set; }
        //second row
        public int R1c1 { get; set; }
        public int R1c2 { get; set; }
        public int R1c3 { get; set; }
        public int R1c4 { get; set; }
        public int R1c5 { get; set; }
        public int R1c6 { get; set; }
        public int R1c7 { get; set; }
        public int R1c8 { get; set; }
        public int R1c9 { get; set; }
        //third row
        public int R2c1 { get; set; }
        public int R2c2 { get; set; }
        public int R2c3 { get; set; }
        public int R2c4 { get; set; }
        public int R2c5 { get; set; }
        public int R2c6 { get; set; }
        public int R2c7 { get; set; }
        public int R2c8 { get; set; }
        public int R2c9 { get; set; }
    }
}