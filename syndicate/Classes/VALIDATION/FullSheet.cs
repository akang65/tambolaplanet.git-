using Dapper; 
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Classes.VALIDATION
{
    public class fullsheetModel
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
    public class FullSheet
    {
        public List<int> DoValidation()
        {
           
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                List<int> Winners = new List<int>();
                int[] FULLSHEET = ReturnSheetCount();            //return Total no of Full sheet Sold and sheet No
               /* int[] SheetWinners = new int[FULLSHEET.Length];*/  //Put the Full sheet winner After validation if Exist
                int[] TickedRandom = getTickedrandom();          //Return Ticked random Number For Validation
               
                for (int i=0; i < FULLSHEET.Length; i++)
                {
                    int TicketNameMultiplier = 6 * FULLSHEET[i];            //For Ticket Name generation
                    int subtractMax = TicketNameMultiplier - 5;  //For Ticket Name generation
                    int countValidatedSheet = 0;                  //returns total no of tickets that has been validated and is true
                    for (int k=0;k<6;k++)
                    {
                        int[] Tickets = new int[15];                  //Fill tickets to verify with Random Numbers
                        int incrementTicketValue = subtractMax + k;   //Making TicketName for query
                        String ticketName = "TicketNo" + incrementTicketValue; //Making TicketName for query
                        var data = connection.Query<fullsheetModel>("dbo.sp_getValidationTickets @TicketName", new { TicketName=ticketName}).ToList();
                        Tickets[0] = data[0].c1; Tickets[1] = data[0].c2; Tickets[2] = data[0].c3;
                        Tickets[3] = data[0].c4; Tickets[4] = data[0].c5; Tickets[5] = data[0].c6;
                        Tickets[6] = data[0].c7; Tickets[7] = data[0].c8; Tickets[8] = data[0].c9;
                        Tickets[9] = data[0].c10; Tickets[10] = data[0].c11; Tickets[11] = data[0].c12;
                        Tickets[12] = data[0].c13; Tickets[13] = data[0].c14; Tickets[14] = data[0].c15;


                        int countexist = 0;
                        for (int index = 0; index < 15; index++)  // check all the Ticket cells for matching Random Numbers
                        {

                            int searchElement = Tickets[index];
                            bool exist = Array.Exists(TickedRandom, element => element == searchElement);
                            if (exist)
                            {
                                countexist++;
                            }
                        }
                        if (countexist>=2)
                        {
                            countValidatedSheet++;
                        }

                    }
                    if(countValidatedSheet==6)
                    {
                        Winners.Add(FULLSHEET[i]);
                        AddFullSheetWinner(FULLSHEET[i],TickedRandom.Length);
                    }
                }
                return Winners;
            }
        }
 
        public int[] ReturnSheetCount()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getSheetCount");
                int c = data.First();
                var getFullSheet = connection.Query<int>("dbo.sp_selectFullSheetOwner @SheetCount",new {SheetCount=c}).ToList();//query<int> Debug
                int [] sheet= new int[getFullSheet.Count];
                for(int i = 0; i < sheet.Length; i++)
                {
                    sheet[i] = getFullSheet[i];
                }
                return sheet;
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
        public void AddFullSheetWinner( int SheetNo,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_AddFullSheetWinner @SheetNumber,@SerialNo", new
                {
                   SheetNumber=SheetNo,
                   SerialNo=serialNo
                });
            }
        }
    }
 
}