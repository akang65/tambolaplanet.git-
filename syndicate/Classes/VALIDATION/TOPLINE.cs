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
    public class topLine
    {
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
     

    }
    public class TOPLINE
    {
        public List<string> getValidationTicketsAndValidateTOP()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                DataAccessForUserInterface t = new DataAccessForUserInterface();
                string[] ticketcount = t.BringSoldTicketsName();
                List<string> winningTickets = new List<string>();
                for (int k = 1; k <= ticketcount.Length; k++)
                {
                    int[] ToplineNumbers = new int[5];
                    int x = k - 1;
                    string ticketName = ticketcount[x];
                    var data = connection.Query<firstFive>("dbo.sp_getTopLine @TicketName", new { TicketName = ticketName }).ToList();
                    ToplineNumbers[0] = data[0].c1; ToplineNumbers[1] = data[0].c2; ToplineNumbers[2] = data[0].c3;
                    ToplineNumbers[3] = data[0].c4; ToplineNumbers[4] = data[0].c5;

                    int[] tickedrandom = getTickedrandom();
                    int countRandom = tickedrandom.Length;
                    if (countRandom > 4)
                    {
                        int countexist = 0;
                        for (int index = 0; index < 5; index++) //check if counts to 4 or not
                        {

                            int searchElement = ToplineNumbers[index];
                            bool exist = Array.Exists(tickedrandom, element => element == searchElement);
                            if (exist)
                            {
                                countexist++;
                            }
                         }
                        if (countexist >= 5)
                        {
                            //int M = k - 1;
                            //winningTickets[M] = ticketName;
                            //M++;
                            winningTickets.Add(ticketName);
                            AddTopLineWinner(ticketName,countRandom);
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
        public void AddTopLineWinner(string ticketNo,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                connection.Execute("dbo.sp_AddTopLineWinner @TicketName,@SerialNo", new { TicketName = ticketNo,SerialNo=serialNo });

            }

        }
    }
   
}