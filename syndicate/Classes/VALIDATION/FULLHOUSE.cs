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
    public class fullHouse
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
    public class FULLHOUSE
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
        public int fullhouseCount(string switcher)
        {
            int fullhouseCounter=0;
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                if (switcher == "count")
                {
                    var data = connection.Query("dbo.sp_fullHouseCount").ToList();
                    fullhouseCounter = data[0].FullHouseNo;
                    return fullhouseCounter;
                }
                else if (switcher == "countreachedCheck")
                {
                    var data = connection.Query("dbo.sp_fullHouseCount").ToList();
                    fullhouseCounter = data[0].FullHouseCount;
                    return fullhouseCounter;
                }
                else if (switcher == "add")
                {   
                        var data = connection.Query("dbo.sp_fullHouseCount").ToList();
                        int fullhouseCount = data[0].FullHouseCount;
                        fullhouseCount++;
                        connection.Execute("dbo.sp_fullHouseCountIncrement @Increment", new { Increment = fullhouseCount });
                }

            }
            return fullhouseCounter;
        }

        public void AddFullHouseWinner(string ticketNo,int place,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_AddFullHouseWinner @TicketName, @WinningPlace, @serialNo", new { TicketName = ticketNo,
                    WinningPlace=place,
                serialNo=serialNo
                });
            }
        }

        public int checkticketwonornot(string ticketNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data=connection.Query<int>("dbo.sp_CheckwinningTicket @TicketName", new { TicketName = ticketNo });
                int datatrueOrNot = data.Count();
                return datatrueOrNot;
            }
        }
    
        public List<string> getValidationTicketsAndValidateFULLHOUSE()
        {
            int CHECK = 0;
           // string Countfullhouse = "count"; //F0R SWITCH STATEMENT COUNT NO OF FULL HOUSE INATIALISED
            // string Countfullhousereached = "countreachedCheck"; 
            string Addfullhouse = "add";
            int countFullHouseInitalised = fullhouseCount("count"); //count initalised no of fullhouse
            int checkFullHouseCountReached = fullhouseCount("countreachedCheck"); //check if its reached or not
            int WinningPlace = checkFullHouseCountReached + 1; //For add first second places on maintable
            int[] tickedrandom = getTickedrandom();
            if (checkFullHouseCountReached < countFullHouseInitalised && tickedrandom.Count()>14 )
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    DataAccessForUserInterface t = new DataAccessForUserInterface();
                   // string[] ticketcount = t.BringTicketsName();
                    string[] ticketcount = t.BringSoldTicketsName();
                    //string[] winningTickets = new string[] { };
                    List<string> winningTickets = new List<string>();
                    for (int k = 1; k <= ticketcount.Length; k++)
                    {
                        int[] FullHouseNumbers = new int[15];
                        int x = k - 1;
                        string ticketName = ticketcount[x];
                        int ShouldValidateOrNot = checkticketwonornot(ticketName);
                        if (ShouldValidateOrNot ==0)
                        {
                        var data = connection.Query<fullHouse>("dbo.sp_getValidationTickets @TicketName", new { TicketName = ticketName }).ToList();
                        FullHouseNumbers[0] = data[0].c1; FullHouseNumbers[1] = data[0].c2; FullHouseNumbers[2] = data[0].c3;
                        FullHouseNumbers[3] = data[0].c4; FullHouseNumbers[4] = data[0].c5; FullHouseNumbers[5] = data[0].c6;
                        FullHouseNumbers[6] = data[0].c7; FullHouseNumbers[7] = data[0].c8; FullHouseNumbers[8] = data[0].c9;
                        FullHouseNumbers[9] = data[0].c10; FullHouseNumbers[10] = data[0].c11; FullHouseNumbers[11] = data[0].c12;
                        FullHouseNumbers[12] = data[0].c13; FullHouseNumbers[13] = data[0].c14; FullHouseNumbers[14] = data[0].c15;

                        
                        int countRandom = tickedrandom.Length;
                        if (countRandom > 14)
                        {
                            int countexist = 0;
                            for (int index = 0; index < 15; index++) //check if counts to 4 or not
                            {

                                int searchElement = FullHouseNumbers[index];
                                bool exist = Array.Exists(tickedrandom, element => element == searchElement);
                                if (exist)
                                {
                                    countexist++;
                                }
                            }
                            if (countexist >= 15)
                            {
                                CHECK = 1;
                                    //int M = k - 1;
                                    //winningTickets[M] = ticketName;
                                    winningTickets.Add(ticketName);
                                AddFullHouseWinner(ticketName, WinningPlace,countRandom); //Add winners on Maintable with the winning place

                            }
                            //else
                            //{
                            //    int M = k - 1;
                            //    winningTickets[M] = null;
                            //}
                        }
                    }

                    }
                    if(CHECK==1)
                    {
                        fullhouseCount(Addfullhouse);//add full house count =+1// Add winning ticket No and place
                    }
                    return winningTickets;
                }
            }
            else
            {
                return null;
            }
        }
    }
}