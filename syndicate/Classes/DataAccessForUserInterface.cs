using Dapper;
using FormUI;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using syndicate.Classes.backgroundServices;
using syndicate.Classes.backgroundValidation;

namespace Tambola.Classes
{
    public class DataAccessForUserInterface
    {
       
        public void insertRandom(int random, int tick)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_insertRandom @Random, @Tick", new { Random = random, Tick = tick });

            }
        }
        public int[] getRandom()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var ran = connection.Query<int>("dbo.sp_getRandomNumber").ToList();
                int count = ran.Count();
                int i = 0;
                int[] Rnum = new int[count];
                foreach (var r in ran)
                {
                    Rnum[i] = (int)r;
                    i++;

                }
                return Rnum;
            }

        }
        public int[] getTockedRandom()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                var ran = connection.Query<int>("dbo.sp_getRandomTockedNumber").ToList();
                int count = ran.Count();
                int i = 0;
                int[] Rnum = new int[count];
                foreach (var r in ran)
                {
                    Rnum[i] = (int)r;
                    i++;

                }

                return Rnum;
            }

        }
        public int incrementTickValue(int tickcount)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                int countingNum = 0;
                var data = connection.Query<int>("dbo.sp_getCountingNumber @TickCount", new { TickCount = tickcount });
                int count = data.Count();
                if (count<=0)
                {
                    MakeWinners s = new MakeWinners();
                    s.RemoveJobs();   
                }
                else
                {
                    countingNum = data.First();
                }
                return countingNum;
            }
        }
        public void RemovelastCount(int lastid)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                int countingNum = 0;
                var data = connection.Execute("dbo.sp_RemoveLastCount @Lastid", new { Lastid = lastid });
               
            }
        }
        public int selectAll()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var list = connection.Query<int>("dbo.selectAll");
                int count = list.First();
                return count;
            }


        }
        public string[] BringTicketsName()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var list = connection.Query<string>("dbo.Sp_BringTicket").ToArray();
                int count = list.Count();
                string[] Tickets = new string[count];
                int i = 0;
                foreach(var r in list)
                {
                    Tickets[i] = r;
                    i++;
                }
                return Tickets;
            }
        }
        public string[] BringSoldTicketsName()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var list = connection.Query<string>("dbo.Sp_BringTicketSold").ToArray();
                int count = list.Count();
                string[] Tickets = new string[count];
                int i = 0;
                foreach (var r in list)
                {
                    Tickets[i] = r;
                    i++;
                }
                return Tickets;
            }
        }


        public IEnumerable<RetriveTickets> GetMasterDetails(string name) //HomeBeforeGame.aspx
        {
            using (IDbConnection con = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                con.Open();
                //var objDetails =con.QueryMultiple("dbo.sp_GetTickets @TableName", new { TableName = tableName });
                var objDetails = SqlMapper.QueryMultiple(con, "sp_GetTickets",
                    new { TableName = name }, commandType: CommandType.StoredProcedure);

                RetriveTickets ObjTicket = new RetriveTickets();

                //Assigning each Multiple tables data to specific single model class  
                ObjTicket.row1 = objDetails.Read<Row1>().ToList();
                ObjTicket.row2 = objDetails.Read<Row2>().ToList();
                ObjTicket.row3 = objDetails.Read<Row3>().ToList();

                List<RetriveTickets> retriveTicketsobj = new List<RetriveTickets>();
                //Add list of records into MasterDetails list  
                retriveTicketsobj.Add(ObjTicket);


                return retriveTicketsobj;
            }
        }
        public int selectTicket()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var list = connection.Query<int>("dbo.selectAll");
                int count = list.First();
                return count;
            }
        }
        public string BringTicketOwner(string ticketNo)//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var list = connection.Query("dbo.getTicketOwnerName @TicketNo", new { TicketNo = ticketNo }).ToList();
                string Name=list[0].CustomerNames;
                return Name;
            }
        }

        public int getfullsheetCount()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getSheetCount");
                int c = data.First();
                return c;
            }
        }
        public int getHalfSheetCount()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getHalfSheetCount");
                int c = data.First();
                return c;
            }
        }
        public cRandom[] geturrentRandom()//HomeBeforeGame.aspx
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<cRandom>("dbo.sp_getCurrentRandom").ToArray();
                return data;
            }
        }
    }
    public class cRandom
    {
        public int CurrentRandom { get; set; }
        public string TicketNumber { get; set; }
        public string CustomerName{ get; set; } 
        public string WinningName{ get; set; }
        public int Place{ get; set; }
    }
}