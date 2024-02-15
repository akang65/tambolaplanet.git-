using FormUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tambola.Classes;

namespace syndicate.Classes.Tickets
{
    public class GenerateTicket
    {
        public void TicketGenerator(int TicketCount)
        {
            int countOriginalTickets = 0;
            //Divide Tickets into Different sheets
            int divide = TicketCount / 6;
            int modulus=TicketCount % 6; ;
            for(int i=1;i<=divide; i++)
            {
                int a = 1;
                MakeFullSheetTickets(a, i);
                countOriginalTickets = 6 * i;

            }
            MakeFullSheetTickets(countOriginalTickets, modulus);

        }
        public void MakeFullSheetTickets(int choose, int TicketCount)
        { 
            //collect used numbers to delete while retriving random 
            int[] trashCollect = new int[90];
            int loop = 0;
            if(choose==1)
            {
               loop = 6;
            }
            else if(choose!=0)
            {
                loop = TicketCount;
            }
            for (int ticket = 1; ticket <= loop; ticket++)
            {
                string TicketName;
                //Make Tickets Name
               
                if(loop==6)
                {
                    int TicketNoMultiplier = TicketCount * 6;
                    int Temp = TicketNoMultiplier - 6;
                    int ticketNo = Temp + ticket;
                    TicketName = "TicketNo" + ticketNo;
                    DataAccess tk = new DataAccess();
                    tk.CreateTable(TicketName);
                }
                else
                {
                    int increment = choose + ticket;
                    TicketName = "TicketNo" + increment;
                    DataAccess tk = new DataAccess();
                    tk.CreateTable(TicketName);
                }
                //Tickets
                int[,] Ticket = new int[3, 9];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Ticket[i, j] = 0;
                    }
                }
                //Check if ticket filled or not if not do it again
                int countItems = 0;
                //VALIDATE TICKET COUNT 
                while (countItems < 15)
                {
                    //For each column of the ticket, randomly choose a row and number from the grouped list above
                    // Select a random Row
                    Random ran = new Random();
                    int RandomRow = ran.Next(0, 3);
                    int R = RandomRow;

                    // Select a random Column
                    int ranC = ran.Next(0, 9);
                    int rC = ranC;
                    //Random col number
                    int RandomNumber = ColumnNumber(rC, trashCollect);

                    //If the row is not already full (<5) and the number in that location is 0
                    //count row item (Validate)
                    int Rowcounter = 0;
                    for (int row = 0; row < 9; row++)
                    {
                        int temp = Ticket[R, row];
                        if (temp != 0)
                        {
                            Rowcounter++;
                        }
                    }
                    //count column item (Validate)
                    int columnCounter = 0;
                    for (int col = 0; col < 3; col++)
                    {
                        if (Ticket[col, rC] != 0)
                        {
                            columnCounter++;
                        }
                    }

                    //Add if row  count is <5
                    if (Rowcounter < 5 && columnCounter < 2 && Ticket[R, rC] == 0)
                    {
                        Ticket[R, rC] = RandomNumber;
                        trashCollect[countItems] = RandomNumber;
                        countItems++;
                    }
                    //Putting Trash On an array
                }
                
                int R0c1 = Ticket[0, 0], R0c2 = Ticket[0, 1], R0c3 = Ticket[0, 2],
               R0c4 = Ticket[0, 3], R0c5 = Ticket[0, 4], R0c6 = Ticket[0, 5],
               R0c7 = Ticket[0, 6], R0c8 = Ticket[0, 7], R0c9 = Ticket[0, 8];

                int R1c1 = Ticket[1, 0], R1c2 = Ticket[1, 1], R1c3 = Ticket[1, 2],
                    R1c4 = Ticket[1, 3], R1c5 = Ticket[1, 4], R1c6 = Ticket[1, 5],
                    R1c7 = Ticket[1, 6], R1c8 = Ticket[1, 7], R1c9 = Ticket[1, 8];

                int R2c1 = Ticket[2, 0], R2c2 = Ticket[2, 1], R2c3 = Ticket[2, 2],
                    R2c4 = Ticket[2, 3], R2c5 = Ticket[2, 4], R2c6 = Ticket[2, 5],
                    R2c7 = Ticket[2, 6], R2c8 = Ticket[2, 7], R2c9 = Ticket[2, 8];



                DataAccess D = new DataAccess();
                D.InsertData(TicketName, R0c1, R0c2, R0c3, R0c4, R0c5, R0c6, R0c7, R0c8, R0c9,
                   R1c1, R1c2, R1c3, R1c4, R1c5, R1c6, R1c7, R1c8, R1c9,
                   R2c1, R2c2, R2c3, R2c4, R2c5, R2c6, R2c7, R2c8, R2c9);


                //Create A Duplicate Table for winning validatioins without zero
                WinningValidationTable validationTable = new WinningValidationTable();
                validationTable.validateWinner(TicketName, R0c1, R0c2, R0c3, R0c4, R0c5, R0c6, R0c7, R0c8, R0c9,
                       R1c1, R1c2, R1c3, R1c4, R1c5, R1c6, R1c7, R1c8, R1c9,
                       R2c1, R2c2, R2c3, R2c4, R2c5, R2c6, R2c7, R2c8, R2c9);
                //print ticket            
            }
        }


        public int ColumnNumber(int columnNumber, int[] Delete)
        {
            Random ran = new Random();
            int c = 0;
            switch (columnNumber)
            {
                case 0:
                    {
                        var COLUMN = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;

                        break;
                    }
                case 1:
                    {
                        var COLUMN = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;

                    }
                case 2:
                    {
                        var COLUMN = new List<int> { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 3:
                    {
                        var COLUMN = new List<int> { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 4:
                    {
                        var COLUMN = new List<int> { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 5:
                    {
                        var COLUMN = new List<int> { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 6:
                    {
                        var COLUMN = new List<int> { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 7:
                    {
                        var COLUMN = new List<int> { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
                case 8:
                    {
                        var COLUMN = new List<int> { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
                        foreach (int items in Delete)
                        {
                            COLUMN.Remove(items);
                        }
                        int Number = ran.Next(COLUMN.Count);
                        int RandomNumber = COLUMN[Number];
                        c = RandomNumber;
                        break;
                    }
            }
            return c;
        }


    }
}