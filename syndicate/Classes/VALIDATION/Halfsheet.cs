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

    public class halfSheetmodel
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
    public class CustomerDetails
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    public class Halfsheet
    {
        public List<int> DoValidation()
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                List<int> Winners = new List<int>();
                int[] HALFSHEET = ReturnHalfSheetCount();            //return Total no of Full sheet Sold and sheet No
                /* int[] SheetWinners = new int[FULLSHEET.Length];*/  //Put the Full sheet winner After validation if Exist
                int[] TickedRandom = getTickedrandom();          //Return Ticked random Number For Validation
                for(int i = 0; i < HALFSHEET.Length; i++)
                {
                    int TicketNoGen = 3 * HALFSHEET[i];
                    int subMax = TicketNoGen - 2;
                    int countValidatedSheet = 0;
                    int check = 0;
                    int[] Tickets = new int[15];
                    string CustomerName = "";
                    string CustomerPhone = "";

                    //check corresponding three tickets with same name and phone number
                    for (int c = 0; c < 3; c++)
                    { 
                        int incrementTicketValue = subMax + c;
                        string Ticketname = "TicketNo" + incrementTicketValue;
                        var data = connection.Query<CustomerDetails>("sp_getCustomerNamePhoneHalfsheetVal @TicketName", new { TicketName = Ticketname }).ToList();
                        if (c == 0)
                        {
                            CustomerName = data[0].Name;
                            CustomerPhone = data[0].Phone;
                        }
                        if( data[0].Name==CustomerName && data[0].Phone == CustomerPhone)
                        {
                            check++;
                            CustomerName = data[0].Name;
                            CustomerPhone = data[0].Phone;
                        }
                    }
                    if (check == 3)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int incrementTicketValue = subMax + j;
                            string Ticketname = "TicketNo" + incrementTicketValue;
                            var data = connection.Query<halfSheetmodel>("dbo.sp_getValidationTickets @TicketName", new { TicketName = Ticketname }).ToList();
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
                            if (countexist >= 2)
                            {
                                countValidatedSheet++;
                            }

                        }
                    }
                       
                    if (countValidatedSheet==3 && check==3)
                    { 
                        Winners.Add(HALFSHEET[i]);
                        AddHalfSheetWinner(HALFSHEET[i],TickedRandom.Length);
                    }
                }
                return Winners;
            }
        }

        private void AddHalfSheetWinner(int k,int serialNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_AddHalfSheetWinner @SheetNumber,@SerialNo", new
                {
                    SheetNumber = k,
                    SerialNo=serialNo
                });
            }
        }

        public int[] ReturnHalfSheetCount()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_getHalfSheetCount");
                int c = data.First();
                var getHalfsheet = connection.Query<int>("dbo.sp_SelectHalfSheetOwner @SheetCount", new { SheetCount = c }).ToList();
                int[] sheet = new int[getHalfsheet.Count];
                for (int i = 0; i < sheet.Length; i++)
                {
                    sheet[i] = getHalfsheet[i];
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
    }
}