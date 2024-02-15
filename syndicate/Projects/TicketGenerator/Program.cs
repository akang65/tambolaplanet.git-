
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TambolaTickets
{
    public class Program
    {
        public void GenerateTickets(int total,string date)
        {
            int[] AwesomeLogic=Calculations_Haha(total);
            int extraTicket = AwesomeLogic[0];
            int TOTAL_TICKETS = AwesomeLogic[1];
            List<object> BulkTickets = new List<object>();
            for (int i = 0; i < TOTAL_TICKETS; i++)
            { 
                int inc=i+1;
                int divider = inc * 6;
                int startingNo = divider - 5;

                TambolaGenerator generator = new();
                List<TambolaTicket> tickets = generator.GenerateTickets();
                foreach (TambolaTicket ticket in tickets)
                {
                    int temp = startingNo;
                    string TicketName = "TicketNo" + temp;
                    List<object> list = ticket.CreateInsertOnDatabase(TicketName);
                    BulkTickets.Add(list);
                    startingNo++;
                }
               
            }
            if (extraTicket != 0)
            {
                int remove = 6 - extraTicket;
                for (int i = 0; i < remove; i++)
                    BulkTickets.RemoveAt(BulkTickets.Count-1);
            }
            Bulkinsert(BulkTickets);
            BulkinsertTicketNames(total,date);
        }
        public int[] Calculations_Haha(int total)
        {
            int[] logic=new int[2];
            int totalTICKET = total / 6;
            int remainingTickets = total % 6;
            if (remainingTickets == 0)
            {
                logic[0] = 0;
                logic[1] = totalTICKET;
            }
            else
            {
                logic[0] = remainingTickets;
                logic[1] = totalTICKET+1;
            }
            return logic;
        }
        public void Bulkinsert(List<object> list)
        {
            DataTable table = new();
            table.Columns.Add("TicketNumber", typeof(string));
            table.Columns.Add("R0c1", typeof(int));
            table.Columns.Add("R0c2", typeof(int));
            table.Columns.Add("R0c3", typeof(int));
            table.Columns.Add("R0c4", typeof(int));
            table.Columns.Add("R0c5", typeof(int));
            table.Columns.Add("R0c6", typeof(int));
            table.Columns.Add("R0c7", typeof(int));
            table.Columns.Add("R0c8", typeof(int));
            table.Columns.Add("R0c9", typeof(int));
            table.Columns.Add("R1c1", typeof(int));
            table.Columns.Add("R1c2", typeof(int));
            table.Columns.Add("R1c3", typeof(int));
            table.Columns.Add("R1c4", typeof(int));
            table.Columns.Add("R1c5", typeof(int));
            table.Columns.Add("R1c6", typeof(int));
            table.Columns.Add("R1c7", typeof(int));
            table.Columns.Add("R1c8", typeof(int));
            table.Columns.Add("R1c9", typeof(int));
            table.Columns.Add("R2c1", typeof(int));
            table.Columns.Add("R2c2", typeof(int));
            table.Columns.Add("R2c3", typeof(int));
            table.Columns.Add("R2c4", typeof(int));
            table.Columns.Add("R2c5", typeof(int));
            table.Columns.Add("R2c6", typeof(int));
            table.Columns.Add("R2c7", typeof(int));
            table.Columns.Add("R2c8", typeof(int));
            table.Columns.Add("R2c9", typeof(int));


            for (int i = 0; i < list.Count; i++)
            {
                List<object> newlist = (List<object>)list[i];

                table.Rows.Add(new object[]{
                   newlist[0],newlist[1],newlist[2],newlist[3],newlist[4],newlist[5],newlist[6],newlist[7],newlist[8],newlist[9],
                   newlist[10],newlist[11],newlist[12],newlist[13],newlist[14],newlist[15],newlist[16],newlist[17],newlist[18],newlist[19],
                   newlist[20],newlist[21],newlist[22],newlist[23],newlist[24],newlist[25],newlist[26],newlist[27]

                 });
            }
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn,SqlBulkCopyOptions.Default,tran))
                        {
                            bulkCopy.DestinationTableName = "dbo.Tickets";
                            bulkCopy.ColumnMappings.Add("TicketNumber", "TicketNumber");
                            bulkCopy.ColumnMappings.Add("R0c1", "R0c1");
                            bulkCopy.ColumnMappings.Add("R0c2", "R0c2");
                            bulkCopy.ColumnMappings.Add("R0c3", "R0c3");
                            bulkCopy.ColumnMappings.Add("R0c4", "R0c4");
                            bulkCopy.ColumnMappings.Add("R0c5", "R0c5");
                            bulkCopy.ColumnMappings.Add("R0c6", "R0c6");
                            bulkCopy.ColumnMappings.Add("R0c7", "R0c7");
                            bulkCopy.ColumnMappings.Add("R0c8", "R0c8");
                            bulkCopy.ColumnMappings.Add("R0c9", "R0c9");
                            bulkCopy.ColumnMappings.Add("R1c1", "R1c1");
                            bulkCopy.ColumnMappings.Add("R1c2", "R1c2");
                            bulkCopy.ColumnMappings.Add("R1c3", "R1c3");
                            bulkCopy.ColumnMappings.Add("R1c4", "R1c4");
                            bulkCopy.ColumnMappings.Add("R1c5", "R1c5");
                            bulkCopy.ColumnMappings.Add("R1c6", "R1c6");
                            bulkCopy.ColumnMappings.Add("R1c7", "R1c7");
                            bulkCopy.ColumnMappings.Add("R1c8", "R1c8");
                            bulkCopy.ColumnMappings.Add("R1c9", "R1c9");
                            bulkCopy.ColumnMappings.Add("R2c1", "R2c1");
                            bulkCopy.ColumnMappings.Add("R2c2", "R2c2");
                            bulkCopy.ColumnMappings.Add("R2c3", "R2c3");
                            bulkCopy.ColumnMappings.Add("R2c4", "R2c4");
                            bulkCopy.ColumnMappings.Add("R2c5", "R2c5");
                            bulkCopy.ColumnMappings.Add("R2c6", "R2c6");
                            bulkCopy.ColumnMappings.Add("R2c7", "R2c7");
                            bulkCopy.ColumnMappings.Add("R2c8", "R2c8");
                            bulkCopy.ColumnMappings.Add("R2c9", "R2c9");

                            bulkCopy.WriteToServer(table);
                        }
                        tran.Commit();
                    }
                }
            
        }
        public void BulkinsertTicketNames(int total,string date)
        {
            DataTable table = new();
            table.Columns.Add("ListId", typeof(int));
            table.Columns.Add("GameDate", typeof(string));
            table.Columns.Add("TicketNumber", typeof(string));

            for (int i = 1; i <= total; i++) 
            {
                string TicketName = "TicketNo" + i;
                int listId = i;
                table.Rows.Add(listId,date,TicketName);
            }
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["tambolastars"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                    {
                        bulkCopy.DestinationTableName = "dbo.MainTable";
                        // bulkCopy.DestinationTableName = "dbo.Tickets";
                        bulkCopy.ColumnMappings.Add("ListId", "ListId");
                        bulkCopy.ColumnMappings.Add("GameDate", "GameDate");
                        bulkCopy.ColumnMappings.Add("TicketNumber", "TicketNumber");
                        bulkCopy.WriteToServer(table);
                    }
                    tran.Commit();
                }
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                    {
                        bulkCopy.DestinationTableName = "dbo.SheetBonus";
                        // bulkCopy.DestinationTableName = "dbo.Tickets";
                        bulkCopy.ColumnMappings.Add("TicketNumber", "TicketNumber");
                        bulkCopy.WriteToServer(table);
                    }
                    tran.Commit();
                }
            }

        }
    }
}