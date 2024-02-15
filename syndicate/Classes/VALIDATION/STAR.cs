using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tambola.Classes;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using FormUI;

namespace syndicate.Classes.VALIDATION
{
    public class Startable
    {
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public int Four { get; set; }
        public int Middle { get; set; }


    }
    public class STAR
    {
        
        public List<string> BringStarWinners()
        {
            DataAccessForUserInterface t = new DataAccessForUserInterface();
           //string[] ticketcount = t.BringTicketsName(); //get all tickets count
            string[] ticketcount = t.BringSoldTicketsName(); //Bring Sold out Tickets
            //int ticketcount = 1;

            List<string> winningTickets = new List<string>();
            for (int checkEachTicket = 1; checkEachTicket <= ticketcount.Length; checkEachTicket++)
            {
                int x = checkEachTicket - 1;
                string ticketName = ticketcount[x];
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    var data = connection.Query<Startable>("dbo.sp_starsValidation @TicketName", new { TicketName = ticketName }).ToList();
                    
                    
                    int[] starnumber = new int[5];
                    starnumber[0] = data[0].One;
                    starnumber[1] = data[0].Two;
                    starnumber[2] = data[0].Three;
                    starnumber[3] = data[0].Four;
                    starnumber[4] = data[0].Middle;

                    //DataAccessForUserInterface ds = new DataAccessForUserInterface();
                    int[] tickedrandom = getTickedrandom();
                    int countRandom = tickedrandom.Length;
                    if (countRandom > 4)
                    {
                        int countvalid = 0;
                        for (int index = 0; index < 5; index++) //check if counts to 4 or not
                        {
                            int searchElement = starnumber[index];
                            bool exist = Array.Exists(tickedrandom, element => element == searchElement);
                            if (exist)
                            {
                                countvalid++;
                            }
                        }
                        if (countvalid >= 5)
                        {
                            //int k = checkEachTicket-1;
                            //winningTickets[k] = ticketName; //if count=4 return the current loop ticket name
                            //k++;
                            winningTickets.Add(ticketName);
                            AddStarWinner(ticketName,countRandom);
                        }
                        //else
                        //    {
                        //    int k = checkEachTicket - 1;
                        //    winningTickets[k] = null;
                        //    k++;
                        //    }

                    }
                    
                }
               
            }
            return winningTickets;
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
        public void AddStarWinner(string ticketNo,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {

                connection.Execute("dbo.sp_AddStarWinner @TicketName,@SerialNo", new { TicketName = ticketNo,SerialNo=serialNo });

            }

        }
    }
  
}