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
    public class middleLine
    {
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
    }
    public class MIDDLELINE
    {
        public List<string> getValidationTicketsAndValidateMIDDLE()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                DataAccessForUserInterface t = new DataAccessForUserInterface();
                //string[] ticketcount = t.BringTicketsName();
                string[] ticketcount = t.BringSoldTicketsName();
                List<string> winningTickets = new List<string>();
                for (int k = 1; k <= ticketcount.Length; k++)
                {
                    int[] MiddleNumbers = new int[5];
                    int x = k - 1;
                    string ticketName = ticketcount[x];
                    var data = connection.Query<firstFive>("dbo.sp_middleLine @TicketName", new { TicketName = ticketName }).ToList();
                    MiddleNumbers[0] = data[0].c1; MiddleNumbers[1] = data[0].c2; MiddleNumbers[2] = data[0].c3;
                    MiddleNumbers[3] = data[0].c4; MiddleNumbers[4] = data[0].c5;

                    int[] tickedrandom = getTickedrandom();
                    int countRandom = tickedrandom.Length;
                    if (countRandom > 4)
                    {
                        int countexist = 0;
                        for (int index = 0; index < 5; index++) //check if counts to 4 or not
                        {

                            int searchElement = MiddleNumbers[index];
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
                            AddMiddleLineWinner(ticketName, countRandom);
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
        public void AddMiddleLineWinner(string ticketNo, int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                connection.Execute("dbo.sp_AddMiddleLineWinner @TicketName, @SerialNo", new { TicketName = ticketNo, SerialNo = serialNo });

            }

        }
    }
}