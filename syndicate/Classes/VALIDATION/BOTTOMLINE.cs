using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tambola.Classes;

namespace syndicate.Classes.VALIDATION
{
    public class bottomLine
    {
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
    }
    public class BOTTOMLINE
    {

        public List<string> getValidationTicketsAndValidateBOTTOM()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                DataAccessForUserInterface t = new DataAccessForUserInterface();
                //string[] ticketcount = t.BringTicketsName();
                string[] ticketcount = t.BringSoldTicketsName();
                List<string> winningTickets = new List<string>();
                for (int k = 1; k <= ticketcount.Length; k++)
                {
                    int[] BottomNumber = new int[5];
                    int x = k - 1;
                    string ticketName = ticketcount[x];
                    var data = connection.Query<firstFive>("dbo.sp_bottomline @TicketName", new { TicketName = ticketName }).ToList();
                    BottomNumber[0] = data[0].c1; BottomNumber[1] = data[0].c2; BottomNumber[2] = data[0].c3;
                    BottomNumber[3] = data[0].c4; BottomNumber[4] = data[0].c5;

                    int[] tickedrandom = getTickedrandom();
                    int countRandom = tickedrandom.Length;
                    if (countRandom > 4)
                    {
                        int countexist = 0;
                        for (int index = 0; index < 5; index++) //check if counts to 4 or not
                        {

                            int searchElement = BottomNumber[index];
                            bool exist = Array.Exists(tickedrandom, element => element == searchElement);
                            if (exist)
                            {
                                countexist++;
                            }
                        }
                        if (countexist >= 5)
                        {
                            winningTickets.Add(ticketName);
                            //int M = k - 1;
                            //winningTickets[M] = ticketName;
                            //M++;
                            //add winner on Main Table
                            AddbottomLineWinner(ticketName,countRandom);

                        }
                        //else
                        //{
                        //    int M = k - 1;
                        //    winningTickets[M] = null;
                        //    M++;
                        //}
                    }

                }
                return winningTickets;
            }
        }
        private int[] getTickedrandom()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getTickedCount").ToList();
                int count = data.Count();
                int i = 0;
                int[] Rnum = new int[count];
                foreach (var r in data)
                {
                    Rnum[i] = (int)r;
                    i++;

                }
                return Rnum;
            }
        }
        public void AddbottomLineWinner(string ticketNo,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                   
                    connection.Execute("dbo.sp_AddBottomLineWinner @TicketName,@SerialNo", new {TicketName=ticketNo,SerialNo=serialNo});

                }
            
        }
    }
}