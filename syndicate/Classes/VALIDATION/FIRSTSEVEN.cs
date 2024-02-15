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
    public class firstSeven
    {
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
        public int c6 { get; set; }
        public int c7 { get; set; }
        public int c8 { get; set; }
        public int c9 { get; set; }
        public int c10 { get; set; }
        public int c11 { get; set; }
        public int c12 { get; set; }
        public int c13 { get; set; }
        public int c14 { get; set; }
        public int c15 { get; set; }

    }
    public class FIRSTSEVEN
    {
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
        public List<string> getValidationTicketsAndValidate()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                DataAccessForUserInterface t = new DataAccessForUserInterface();
                //string[] ticketcount = t.BringTicketsName();
                string[] ticketcount = t.BringSoldTicketsName();
                List<string> winningTickets = new List<string>();
                for (int k = 1; k <= ticketcount.Length; k++)
                {
                    int[] ticketNumbers = new int[15];
                    int x = k - 1;
                    string ticketName = ticketcount[x];
                    var data = connection.Query<firstSeven>("dbo.sp_getValidationTickets @TicketName", new { TicketName = ticketName }).ToList();
                    ticketNumbers[0] = data[0].c1; ticketNumbers[1] = data[0].c2; ticketNumbers[2] = data[0].c3;
                    ticketNumbers[3] = data[0].c4; ticketNumbers[4] = data[0].c5; ticketNumbers[5] = data[0].c6;
                    ticketNumbers[6] = data[0].c7; ticketNumbers[7] = data[0].c8; ticketNumbers[8] = data[0].c9;
                    ticketNumbers[9] = data[0].c10; ticketNumbers[10] = data[0].c11; ticketNumbers[11] = data[0].c12;
                    ticketNumbers[12] = data[0].c13; ticketNumbers[13] = data[0].c14; ticketNumbers[14] = data[0].c15;

                    int[] tickedrandom = getTickedrandom();
                    int countRandom = tickedrandom.Length;
                    if (countRandom > 4)
                    {
                        int countexist = 0;
                        for (int index = 0; index < 15; index++) //check if counts to 4 or not
                        {

                            int searchElement = ticketNumbers[index];
                            bool exist = Array.Exists(tickedrandom, element => element == searchElement);
                            if (exist)
                            {
                                countexist++;
                            }
                        }
                        if (countexist >= 7) //check if numbers match uptp seven Digits
                        {
                            winningTickets.Add(ticketName);
                            //int M = k - 1;
                            //winningTickets[M] = ticketName;
                            //M++;
                            AddFirstSevenWinner(ticketName, countRandom);
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
        public void AddFirstSevenWinner(string ticketNo, int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                connection.Execute("dbo.sp_AddFirstSevenWinner @TicketName,@SerialNo", new { TicketName = ticketNo, SerialNo = serialNo });

            }

        }
    }
}